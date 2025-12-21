--
-- PostgreSQL database dump
--

\restrict YqrZz8AuFmtdqvZBqaJ9BiuM3z2WWZ1nh5YfFlrHEncoUqSjmhEZ5ojjczHXGoL

-- Dumped from database version 18.0 (Debian 18.0-1.pgdg13+3)
-- Dumped by pg_dump version 18.0

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: fn_GecmisTarihKontrol(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public."fn_GecmisTarihKontrol"() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
    -- Eğer yeni kaydın başlangıç tarihi bugünden küçükse HATA VER
    -- (Sadece INSERT işlemi için geçerli, güncellemede tarih düzeltilebilir)
    IF (NEW."baslangicTarihi" < CURRENT_DATE) THEN
        RAISE EXCEPTION 'Hata: Geçmiş bir tarihe yeni rezervasyon yapılamaz!';
    END IF;
    
    RETURN NEW;
END;
$$;


ALTER FUNCTION public."fn_GecmisTarihKontrol"() OWNER TO postgres;

--
-- Name: fn_RezervasyonOdaDurumGuncelle(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public."fn_RezervasyonOdaDurumGuncelle"() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
    -- SENARYO A: YENİ REZERVASYON YAPILDI (INSERT)
    -- Yeni bir rezervasyon eklendiyse, odayı "DOLU" (False) yap.
    IF (TG_OP = 'INSERT') THEN
        IF NEW."rezervasyonDurumu" = TRUE THEN
            UPDATE "Oda" 
            SET "durum" = FALSE 
            WHERE "odaNo" = NEW."odaNo";
        END IF;
        RETURN NEW;
    
    -- SENARYO B: REZERVASYON GÜNCELLENDİ (UPDATE)
    -- Sadece "Aktif -> Pasif" olduysa (Süresi dolduysa) odayı "MÜSAİT" (True) yap.
    ELSIF (TG_OP = 'UPDATE') THEN
        IF OLD."rezervasyonDurumu" = TRUE AND NEW."rezervasyonDurumu" = FALSE THEN
            UPDATE "Oda" 
            SET "durum" = TRUE 
            WHERE "odaNo" = NEW."odaNo";
        END IF;
        RETURN NEW;

    -- SENARYO C: REZERVASYON SİLİNDİ (DELETE)
    -- Rezervasyon silindiyse odayı serbest bırak ("MÜSAİT" / True yap).
    ELSIF (TG_OP = 'DELETE') THEN
        UPDATE "Oda" 
        SET "durum" = TRUE 
        WHERE "odaNo" = OLD."odaNo";
        RETURN OLD;
    END IF;
    
    RETURN NULL;
END;
$$;


ALTER FUNCTION public."fn_RezervasyonOdaDurumGuncelle"() OWNER TO postgres;

--
-- Name: fn_RezervasyonSilLog(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public."fn_RezervasyonSilLog"() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
DECLARE
    -- Müşteri bilgilerini geçici tutmak için değişkenler
    degisken_tc VARCHAR(11);
    degisken_ad VARCHAR(40);
    degisken_soyad VARCHAR(40);
    degisken_tel VARCHAR(11);
    degisken_email VARCHAR(40);
BEGIN
    -- Silinen rezervasyondaki "musteriID"yi kullanarak bilgileri buluyoruz
    SELECT 
        "Kisi"."kimlikNo", 
        "Kisi"."kisiAdi", 
        "Kisi"."kisiSoyadi", 
        "IletisimBilgisi"."telNo", 
        "IletisimBilgisi"."eMail"
    INTO 
        degisken_tc, 
        degisken_ad, 
        degisken_soyad, 
        degisken_tel, 
        degisken_email
    FROM "Kisi"
    LEFT JOIN "IletisimBilgisi" ON "Kisi"."kisiID" = "IletisimBilgisi"."kisiID"
    WHERE "Kisi"."kisiID" = OLD."musteriID";

    -- Log tablosuna kayıt atıyoruz
    INSERT INTO "RezervasyonLog" (
        "silinenRezervasyonID", 
        "musteriTC", 
        "musteriAd", 
        "musteriSoyad", 
        "musteriTel", 
        "musteriEmail",
        "odaNo", 
        "baslangicTarihi", 
        "bitisTarihi"
    )
    VALUES (
        OLD."rezervasyonID", 
        degisken_tc, 
        degisken_ad, 
        degisken_soyad, 
        degisken_tel, 
        degisken_email,
        OLD."odaNo", 
        OLD."baslangicTarihi", 
        OLD."bitisTarihi"
    );
    
    RETURN OLD; -- Silme işlemine devam et
END;
$$;


ALTER FUNCTION public."fn_RezervasyonSilLog"() OWNER TO postgres;

--
-- Name: fn_TCKNKontrol(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public."fn_TCKNKontrol"() RETURNS trigger
    LANGUAGE plpgsql
    AS $_$
BEGIN
    -- 1. KONTROL: Uzunluk tam 11 olmalı
    IF LENGTH(NEW."kimlikNo") <> 11 THEN
        RAISE EXCEPTION 'Hata: TC Kimlik Numarası 11 haneli olmak zorundadır!';
    END IF;

    -- 2. KONTROL: Sadece Rakam İçermeli (Regex Kontrolü)
    -- '^[0-9]+$' ifadesi: "Baştan sona sadece 0-9 arası rakamlardan oluşsun" demektir.
    -- !~ ifadesi: "Bu kurala UYMUYORSA" demektir.
    IF NEW."kimlikNo" !~ '^[0-9]+$' THEN
        RAISE EXCEPTION 'Hata: TC Kimlik Numarası sadece rakamlardan oluşmalıdır, harf veya sembol içeremez!';
    END IF;

    RETURN NEW;
END;
$_$;


ALTER FUNCTION public."fn_TCKNKontrol"() OWNER TO postgres;

--
-- Name: sp_FaturaOlustur(integer); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public."sp_FaturaOlustur"(IN gelen_rez_id integer)
    LANGUAGE plpgsql
    AS $$
DECLARE
    gun_sayisi INT;
    oda_fiyati REAL;
    kisi_sayisi INT;    
    hizmet_tutari REAL;
    toplam_tutar REAL;
    -- fatura_no değişkenini kaldırdık çünkü artık metin değil sayı kullanacağız
BEGIN
    -- 1. Gün Sayısını ve Oda Fiyatını Bul
    SELECT 
        ("Rezervasyon"."bitisTarihi" - "Rezervasyon"."baslangicTarihi"), 
        "OdaTur"."odaFiyati"
    INTO 
        gun_sayisi,
        oda_fiyati
    FROM "Rezervasyon"
    JOIN "Oda" ON "Rezervasyon"."odaNo" = "Oda"."odaNo"
    JOIN "OdaTur" ON "Oda"."odaTuruID" = "OdaTur"."odaTurID"
    WHERE "Rezervasyon"."rezervasyonID" = gelen_rez_id;

    -- 2. Kişi Sayısını Bul
    SELECT (COUNT(*) + 1) 
    INTO kisi_sayisi
    FROM "MisafirRezervasyon"
    WHERE "rezervasyonID" = gelen_rez_id;

    -- 3. Hizmetlerin Toplamını Hesapla
    SELECT COALESCE(SUM(
        CASE 
            WHEN "Hizmet"."hizmetNo" = 5 THEN "Hizmet"."hizmetFiyati" * gun_sayisi
            ELSE "Hizmet"."hizmetFiyati" * gun_sayisi * kisi_sayisi
        END
    ), 0)
    INTO hizmet_tutari
    FROM "RezervasyonHizmet"
    JOIN "Hizmet" ON "RezervasyonHizmet"."hizmetNo" = "Hizmet"."hizmetNo"
    WHERE "RezervasyonHizmet"."rezervasyonID" = gelen_rez_id;

    -- 4. Genel Toplamı Hesapla
    toplam_tutar := (oda_fiyati * gun_sayisi) + hizmet_tutari;

    -- 5. Kaydet (DEĞİŞİKLİK BURADA)
    -- 'FTR-' || gelen_rez_id YERİNE sadece gelen_rez_id kullandık.
    INSERT INTO "Fatura" ("faturaNo", "faturaTarihi", "faturaTutari", "rezervasyonID")
    VALUES (gelen_rez_id, CURRENT_DATE, toplam_tutar, gelen_rez_id);

END;
$$;


ALTER PROCEDURE public."sp_FaturaOlustur"(IN gelen_rez_id integer) OWNER TO postgres;

--
-- Name: sp_GecmisRezervasyonlariPasifYap(); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public."sp_GecmisRezervasyonlariPasifYap"()
    LANGUAGE plpgsql
    AS $$
BEGIN
    -- Bitiş tarihi bugünden küçükse (geçmişse) ve durumu hala TRUE ise FALSE yap
    UPDATE "Rezervasyon"
    SET "rezervasyonDurumu" = FALSE
    WHERE "bitisTarihi" < CURRENT_DATE AND "rezervasyonDurumu" = TRUE;
END;
$$;


ALTER PROCEDURE public."sp_GecmisRezervasyonlariPasifYap"() OWNER TO postgres;

--
-- Name: sp_GunlukCiro(date, real); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public."sp_GunlukCiro"(IN gelen_tarih date, INOUT toplam_ciro real DEFAULT 0)
    LANGUAGE plpgsql
    AS $$
BEGIN
    -- O güne ait faturaları topla.
    -- COALESCE: Eğer hiç fatura yoksa (NULL dönerse), sonucu 0 yap.
    SELECT COALESCE(SUM("faturaTutari"), 0)
    INTO toplam_ciro
    FROM "Fatura"
    WHERE "faturaTarihi" = gelen_tarih;
END;
$$;


ALTER PROCEDURE public."sp_GunlukCiro"(IN gelen_tarih date, INOUT toplam_ciro real) OWNER TO postgres;

--
-- Name: sp_GunlukToplamMisafir(date, integer); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public."sp_GunlukToplamMisafir"(IN tarih date, INOUT kisi_sayisi integer DEFAULT 0)
    LANGUAGE plpgsql
    AS $$
DECLARE
    -- Değişkenler
    ana_musteri_sayisi INT;
    yan_misafir_sayisi INT;
BEGIN
    -- 1. O tarihte aktif olan rezervasyonların asıl müşterilerini say (Her oda 1 kişi)
    SELECT COUNT(*)
    INTO ana_musteri_sayisi
    FROM "Rezervasyon"
    WHERE tarih >= "baslangicTarihi" AND tarih < "bitisTarihi" AND "rezervasyonDurumu" = TRUE;

    -- 2. O rezervasyonlara bağlı yan misafirleri say
    SELECT COUNT(*)
    INTO yan_misafir_sayisi
    FROM "MisafirRezervasyon" 
    JOIN "Rezervasyon" ON "MisafirRezervasyon"."rezervasyonID" = "Rezervasyon"."rezervasyonID"
    WHERE tarih >= "Rezervasyon"."baslangicTarihi" AND tarih < "Rezervasyon"."bitisTarihi" AND "Rezervasyon"."rezervasyonDurumu" = TRUE;

    -- 3. Topla
    kisi_sayisi := ana_musteri_sayisi + yan_misafir_sayisi;
END;
$$;


ALTER PROCEDURE public."sp_GunlukToplamMisafir"(IN tarih date, INOUT kisi_sayisi integer) OWNER TO postgres;

--
-- Name: sp_GunlukYeniRezervasyonSayisi(date, integer); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public."sp_GunlukYeniRezervasyonSayisi"(IN p_tarih date, INOUT p_sayi integer DEFAULT 0)
    LANGUAGE plpgsql
    AS $$
BEGIN
    SELECT COUNT(*) 
    INTO p_sayi
    FROM "Rezervasyon"
    WHERE "baslangicTarihi" = p_tarih;
END;
$$;


ALTER PROCEDURE public."sp_GunlukYeniRezervasyonSayisi"(IN p_tarih date, INOUT p_sayi integer) OWNER TO postgres;

--
-- Name: sp_OdaFiyatGuncelle(smallint, real); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public."sp_OdaFiyatGuncelle"(IN oda_tur_id smallint, IN yeni_fiyat real)
    LANGUAGE plpgsql
    AS $$
DECLARE
    -- Kaydın varlığını kontrol etmek için değişken
    kayit_kontrol RECORD; 
BEGIN
    -- 1. Önce bu ID'ye sahip bir oda türü var mı diye bakıyoruz
    SELECT * INTO kayit_kontrol 
    FROM "OdaTur" 
    WHERE "odaTurID" = oda_tur_id;

    -- 2. Eğer kayıt bulunduysa (FOUND) fiyatı güncelle
    IF FOUND THEN
        UPDATE "OdaTur"
        SET "odaFiyati" = yeni_fiyat
        WHERE "odaTurID" = oda_tur_id;
    ELSE
        -- Kayıt yoksa uyarı ver
        RAISE EXCEPTION 'Verilen ID (%) ile eşleşen oda türü bulunamadı.', oda_tur_id;
    END IF;
END;
$$;


ALTER PROCEDURE public."sp_OdaFiyatGuncelle"(IN oda_tur_id smallint, IN yeni_fiyat real) OWNER TO postgres;

--
-- Name: sp_PersonelMaasGuncelle(smallint, real); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public."sp_PersonelMaasGuncelle"(IN tur_id smallint, IN yeni_maas real)
    LANGUAGE plpgsql
    AS $$
DECLARE
    kayit_kontrol RECORD; 
BEGIN
    -- 1. Önce bu ID'ye sahip bir kayıt var mı diye değişkene atıyoruz
    SELECT * INTO kayit_kontrol 
    FROM "PersonelTur" 
    WHERE "personelTurID" = tur_id;

    -- 2. Eğer kayıt bulunduysa (FOUND) güncelleme yap
    IF FOUND THEN
        UPDATE "PersonelTur"
        SET "personelMaas" = yeni_maas
        WHERE "personelTurID" = tur_id;
    ELSE
        -- Kayıt yoksa uyarı fırlat
        RAISE EXCEPTION 'Verilen ID (% ) ile eşleşen personel türü bulunamadı.', tur_id;
    END IF;
END;
$$;


ALTER PROCEDURE public."sp_PersonelMaasGuncelle"(IN tur_id smallint, IN yeni_maas real) OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: Fatura; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Fatura" (
    "faturaNo" integer NOT NULL,
    "faturaTarihi" date NOT NULL,
    "faturaTutari" real NOT NULL,
    "rezervasyonID" integer NOT NULL
);


ALTER TABLE public."Fatura" OWNER TO postgres;

--
-- Name: Fatura_faturaNo_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Fatura_faturaNo_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Fatura_faturaNo_seq" OWNER TO postgres;

--
-- Name: Fatura_faturaNo_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Fatura_faturaNo_seq" OWNED BY public."Fatura"."faturaNo";


--
-- Name: Hizmet; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Hizmet" (
    "hizmetNo" smallint NOT NULL,
    "hizmetAdi" character varying(20) NOT NULL,
    "hizmetFiyati" real NOT NULL
);


ALTER TABLE public."Hizmet" OWNER TO postgres;

--
-- Name: Il; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Il" (
    "ilNo" character(2) NOT NULL,
    "ilAdi" character varying(14) NOT NULL
);


ALTER TABLE public."Il" OWNER TO postgres;

--
-- Name: Ilce; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Ilce" (
    "ilceNo" smallint NOT NULL,
    "ilceAdi" character varying(16) NOT NULL,
    "ilNo" character(2) NOT NULL
);


ALTER TABLE public."Ilce" OWNER TO postgres;

--
-- Name: IletisimBilgisi; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."IletisimBilgisi" (
    "iletisimID" integer NOT NULL,
    "telNo" character(11) NOT NULL,
    "eMail" character varying(40) NOT NULL,
    adres character varying(90) NOT NULL,
    "ilceNo" smallint NOT NULL,
    "kisiID" integer NOT NULL
);


ALTER TABLE public."IletisimBilgisi" OWNER TO postgres;

--
-- Name: IletisimBilgisi_iletisimID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."IletisimBilgisi_iletisimID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."IletisimBilgisi_iletisimID_seq" OWNER TO postgres;

--
-- Name: IletisimBilgisi_iletisimID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."IletisimBilgisi_iletisimID_seq" OWNED BY public."IletisimBilgisi"."iletisimID";


--
-- Name: Kisi; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Kisi" (
    "kisiID" integer NOT NULL,
    "kimlikNo" character(11) NOT NULL,
    "kisiAdi" character varying(40) NOT NULL,
    "kisiSoyadi" character varying(40) NOT NULL,
    cinsiyet character(1) NOT NULL,
    "kisiTuru" character varying(20) NOT NULL,
    CONSTRAINT "cinsiyetKontrol" CHECK ((cinsiyet = ANY (ARRAY['E'::bpchar, 'K'::bpchar])))
);


ALTER TABLE public."Kisi" OWNER TO postgres;

--
-- Name: Kisi_kisiID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Kisi_kisiID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Kisi_kisiID_seq" OWNER TO postgres;

--
-- Name: Kisi_kisiID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Kisi_kisiID_seq" OWNED BY public."Kisi"."kisiID";


--
-- Name: Misafir; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Misafir" (
    "misafirID" integer NOT NULL,
    "musteriID" integer NOT NULL
);


ALTER TABLE public."Misafir" OWNER TO postgres;

--
-- Name: MisafirRezervasyon; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."MisafirRezervasyon" (
    "misafirID" integer NOT NULL,
    "rezervasyonID" integer NOT NULL
);


ALTER TABLE public."MisafirRezervasyon" OWNER TO postgres;

--
-- Name: Musteri; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Musteri" (
    "musteriID" integer NOT NULL
);


ALTER TABLE public."Musteri" OWNER TO postgres;

--
-- Name: Oda; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Oda" (
    "odaNo" smallint NOT NULL,
    kat smallint NOT NULL,
    durum boolean DEFAULT true NOT NULL,
    "odaTuruID" smallint NOT NULL
);


ALTER TABLE public."Oda" OWNER TO postgres;

--
-- Name: OdaTur; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."OdaTur" (
    "odaTurID" smallint NOT NULL,
    "odaTurAdi" character varying(25) NOT NULL,
    "odaFiyati" real NOT NULL,
    "odaKapasite" smallint NOT NULL,
    "odaMetrekare" smallint
);


ALTER TABLE public."OdaTur" OWNER TO postgres;

--
-- Name: Personel; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Personel" (
    "personelID" integer NOT NULL,
    "sicilNo" character varying(11) NOT NULL,
    "personelTurID" smallint NOT NULL,
    mudur integer,
    sifre character varying(40) DEFAULT NULL::character varying
);


ALTER TABLE public."Personel" OWNER TO postgres;

--
-- Name: PersonelTur; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."PersonelTur" (
    "personelTurID" smallint NOT NULL,
    "personelTurAdi" character varying(20) NOT NULL,
    "personelMaas" real DEFAULT 22104 NOT NULL
);


ALTER TABLE public."PersonelTur" OWNER TO postgres;

--
-- Name: PersonelYakini; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."PersonelYakini" (
    "personelYakinID" integer NOT NULL,
    "personelID" integer NOT NULL
);


ALTER TABLE public."PersonelYakini" OWNER TO postgres;

--
-- Name: Rezervasyon; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Rezervasyon" (
    "rezervasyonID" integer NOT NULL,
    "baslangicTarihi" date NOT NULL,
    "bitisTarihi" date NOT NULL,
    "rezervasyonDurumu" boolean DEFAULT true,
    "musteriID" integer NOT NULL,
    "odaNo" smallint NOT NULL,
    CONSTRAINT "tarihKontrol" CHECK (("bitisTarihi" > "baslangicTarihi"))
);


ALTER TABLE public."Rezervasyon" OWNER TO postgres;

--
-- Name: RezervasyonHizmet; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."RezervasyonHizmet" (
    "hizmetNo" smallint NOT NULL,
    "rezervasyonID" integer NOT NULL
);


ALTER TABLE public."RezervasyonHizmet" OWNER TO postgres;

--
-- Name: RezervasyonLog; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."RezervasyonLog" (
    "logID" integer NOT NULL,
    "silinenRezervasyonID" integer,
    "musteriTC" character varying(11),
    "musteriAd" character varying(40),
    "musteriSoyad" character varying(40),
    "musteriTel" character varying(11),
    "musteriEmail" character varying(40),
    "odaNo" integer,
    "baslangicTarihi" date,
    "bitisTarihi" date,
    "silinmeTarihi" timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    "islemiYapan" character varying(50) DEFAULT CURRENT_USER
);


ALTER TABLE public."RezervasyonLog" OWNER TO postgres;

--
-- Name: RezervasyonLog_logID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."RezervasyonLog_logID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."RezervasyonLog_logID_seq" OWNER TO postgres;

--
-- Name: RezervasyonLog_logID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."RezervasyonLog_logID_seq" OWNED BY public."RezervasyonLog"."logID";


--
-- Name: Rezervasyon_rezervasyonID_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public."Rezervasyon_rezervasyonID_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public."Rezervasyon_rezervasyonID_seq" OWNER TO postgres;

--
-- Name: Rezervasyon_rezervasyonID_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public."Rezervasyon_rezervasyonID_seq" OWNED BY public."Rezervasyon"."rezervasyonID";


--
-- Name: Fatura faturaNo; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Fatura" ALTER COLUMN "faturaNo" SET DEFAULT nextval('public."Fatura_faturaNo_seq"'::regclass);


--
-- Name: IletisimBilgisi iletisimID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."IletisimBilgisi" ALTER COLUMN "iletisimID" SET DEFAULT nextval('public."IletisimBilgisi_iletisimID_seq"'::regclass);


--
-- Name: Kisi kisiID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Kisi" ALTER COLUMN "kisiID" SET DEFAULT nextval('public."Kisi_kisiID_seq"'::regclass);


--
-- Name: Rezervasyon rezervasyonID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Rezervasyon" ALTER COLUMN "rezervasyonID" SET DEFAULT nextval('public."Rezervasyon_rezervasyonID_seq"'::regclass);


--
-- Name: RezervasyonLog logID; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RezervasyonLog" ALTER COLUMN "logID" SET DEFAULT nextval('public."RezervasyonLog_logID_seq"'::regclass);


--
-- Data for Name: Fatura; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Fatura" VALUES
	(5001, '2025-12-08', 5400, 5001),
	(5002, '2025-12-08', 19000, 5002),
	(5004, '2025-12-08', 3200, 5004);


--
-- Data for Name: Hizmet; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Hizmet" VALUES
	(1, 'Ögle Yemeği', 300),
	(2, 'Kahvaltı', 200),
	(3, 'Akşam Yemeği', 500),
	(4, 'Oda Servisi', 1000),
	(5, 'Temizlik', 300);


--
-- Data for Name: Il; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Il" VALUES
	('01', 'Adana'),
	('06', 'Ankara'),
	('07', 'Antalya'),
	('16', 'Bursa'),
	('27', 'Gaziantep'),
	('34', 'İstanbul'),
	('35', 'İzmir'),
	('41', 'Kocaeli'),
	('42', 'Konya'),
	('54', 'Sakarya');


--
-- Data for Name: Ilce; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Ilce" VALUES
	(1104, 'Seyhan', '01'),
	(1748, 'Yüreğir', '01'),
	(2033, 'Çukurova', '01'),
	(2032, 'Sarıçam', '01'),
	(1219, 'Ceyhan', '01'),
	(1231, 'Çankaya', '06'),
	(1745, 'Keçiören', '06'),
	(1723, 'Yenimahalle', '06'),
	(1746, 'Mamak', '06'),
	(1922, 'Etimesgut', '06'),
	(2039, 'Muratpaşa', '07'),
	(2038, 'Konyaaltı', '07'),
	(2037, 'Kepez', '07'),
	(2035, 'Aksu', '07'),
	(2036, 'Döşemealtı', '07'),
	(1832, 'Osmangazi', '16'),
	(1859, 'Yıldırım', '16'),
	(1829, 'Nilüfer', '16'),
	(1411, 'İnegöl', '16'),
	(1343, 'Gemlik', '16'),
	(1841, 'Şahinbey', '27'),
	(1844, 'Şehitkamil', '27'),
	(1546, 'Nizip', '27'),
	(1415, 'İslahiye', '27'),
	(1974, 'Nurdağı', '27'),
	(2053, 'Esenyurt', '34'),
	(1823, 'Küçükçekmece', '34'),
	(2004, 'Bağcılar', '34'),
	(1835, 'Pendik', '34'),
	(1852, 'Ümraniye', '34'),
	(1211, 'Buca', '35'),
	(2057, 'Karabağlar', '35'),
	(1203, 'Bornova', '35'),
	(1448, 'Karşıyaka', '35'),
	(1819, 'Konak', '35'),
	(1338, 'Gebze', '41'),
	(2062, 'İzmit', '41'),
	(2060, 'Darıca', '41'),
	(1821, 'Körfez', '41'),
	(1355, 'Gölcük', '41'),
	(1839, 'Selçuklu', '42'),
	(1814, 'Karatay', '42'),
	(1827, 'Meram', '42'),
	(1312, 'Ereğli', '42'),
	(1122, 'Akşehir', '42'),
	(2068, 'Adapazarı', '54'),
	(2071, 'Serdivan', '54'),
	(1123, 'Akyazı', '54'),
	(2070, 'Erenler', '54'),
	(1391, 'Hendek', '54');


--
-- Data for Name: IletisimBilgisi; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."IletisimBilgisi" VALUES
	(1, '5551112233 ', 'ali@otel.com', 'Merkez Mah. No:1', 2053, 101),
	(2, '5554445566 ', 'ayse@otel.com', 'Gül Sok. No:5', 2053, 102),
	(3, '5551000001 ', 'ahmet.yilmaz@otel.com', 'Atatürk Cad. No:1', 2068, 1000),
	(4, '5551000002 ', 'zeynep.kaya@otel.com', 'Bağdat Cad. No:20', 1823, 1001),
	(5, '5551000003 ', 'mehmet.ozturk@otel.com', 'Çark Cad. No:5', 2071, 1002),
	(6, '5552000001 ', 'elif.demir@gmail.com', 'Cumhuriyet Mah. No:10', 1231, 1003),
	(7, '5552000002 ', 'burak.celik@hotmail.com', 'Lale Sok. No:3', 2039, 1004),
	(8, '5552000003 ', 'ayse.yildiz@yahoo.com', 'Gül Sok. No:8', 1211, 1005),
	(9, '5552000004 ', 'can.aslan@outlook.com', 'Menekşe Apt. No:4', 1832, 1006),
	(10, '5552000005 ', 'selin.koc@gmail.com', 'Papatya Sit. A Blok', 2062, 1007),
	(11, '5552000006 ', 'murat.aydin@gmail.com', 'Karanfil Sok. No:12', 1104, 1008),
	(12, '5553000001 ', 'cem.yilmaz@misafir.com', 'Tatil Köyü No:1', 2039, 1009),
	(13, '5553000002 ', 'oya.basar@misafir.com', 'Yazlık Sit. No:5', 1211, 1010),
	(14, '5551000004 ', 'deniz.gezgin@otel.com', 'Kampüs Yolu No:9', 2071, 1011),
	(15, '5559000001 ', 'fatma@yakin.com', 'Merkez Mah. No:10', 2068, 1020),
	(16, '5559000002 ', 'hasan@yakin.com', 'Gül Sok. No:50', 2053, 1021),
	(17, '5559000003 ', 'hatice@yakin.com', 'Atatürk Cad. No:2', 2068, 1022),
	(18, '5559000004 ', 'mustafa@yakin.com', 'Bağdat Cad. No:21', 1823, 1023),
	(19, '5559000005 ', 'emine@yakin.com', 'Çark Cad. No:6', 2071, 1024),
	(20, '5559000006 ', 'kemal@yakin.com', 'Kampüs Yolu No:10', 2071, 1025);


--
-- Data for Name: Kisi; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Kisi" VALUES
	(101, '11111111111', 'Ali', 'Yılmaz', 'E', 'Personel'),
	(102, '22222222222', 'Ayşe', 'Demir', 'K', 'Personel'),
	(1000, '10000000001', 'Ahmet', 'Yılmaz', 'E', 'Personel'),
	(1001, '10000000002', 'Zeynep', 'Kaya', 'K', 'Personel'),
	(1002, '10000000003', 'Mehmet', 'Öztürk', 'E', 'Personel'),
	(1003, '10000000004', 'Elif', 'Demir', 'K', 'Musteri'),
	(1004, '10000000005', 'Burak', 'Çelik', 'E', 'Musteri'),
	(1005, '10000000006', 'Ayşe', 'Yıldız', 'K', 'Musteri'),
	(1006, '10000000007', 'Can', 'Aslan', 'E', 'Musteri'),
	(1007, '10000000008', 'Selin', 'Koç', 'K', 'Musteri'),
	(1008, '10000000009', 'Murat', 'Aydın', 'E', 'Musteri'),
	(1009, '10000000010', 'Cem', 'Yılmaz', 'E', 'Misafir'),
	(1010, '10000000011', 'Oya', 'Başar', 'K', 'Misafir'),
	(1011, '10000000012', 'Deniz', 'Gezgin', 'K', 'Personel'),
	(1020, '10000000020', 'Fatma', 'Yılmaz', 'K', 'PersonelYakini'),
	(1021, '10000000021', 'Hasan', 'Demir', 'E', 'PersonelYakini'),
	(1022, '10000000022', 'Hatice', 'Yılmaz', 'K', 'PersonelYakini'),
	(1023, '10000000023', 'Mustafa', 'Kaya', 'E', 'PersonelYakini'),
	(1024, '10000000024', 'Emine', 'Öztürk', 'K', 'PersonelYakini'),
	(1025, '10000000025', 'Kemal', 'Gezgin', 'E', 'PersonelYakini');


--
-- Data for Name: Misafir; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Misafir" VALUES
	(1009, 1004),
	(1010, 1005);


--
-- Data for Name: MisafirRezervasyon; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."MisafirRezervasyon" VALUES
	(1009, 5002),
	(1010, 5003);


--
-- Data for Name: Musteri; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Musteri" VALUES
	(1003),
	(1004),
	(1005),
	(1006),
	(1007),
	(1008);


--
-- Data for Name: Oda; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Oda" VALUES
	(105, 1, true, 1),
	(107, 1, true, 2),
	(108, 1, true, 2),
	(110, 1, true, 2),
	(202, 2, true, 3),
	(203, 2, true, 3),
	(204, 2, true, 3),
	(206, 2, true, 4),
	(207, 2, true, 4),
	(208, 2, true, 4),
	(209, 2, true, 4),
	(210, 2, true, 4),
	(302, 3, true, 5),
	(303, 3, true, 5),
	(304, 3, true, 5),
	(305, 3, true, 5),
	(306, 3, true, 6),
	(307, 3, true, 6),
	(308, 3, true, 6),
	(309, 3, true, 6),
	(310, 3, true, 6),
	(102, 1, true, 1),
	(109, 1, true, 2),
	(103, 1, true, 1),
	(101, 1, true, 1),
	(104, 1, false, 1),
	(201, 2, false, 3),
	(301, 3, false, 5),
	(106, 1, false, 2),
	(205, 2, false, 3);


--
-- Data for Name: OdaTur; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."OdaTur" VALUES
	(2, 'Deluxe Single', 1300, 1, 17),
	(3, 'Standart Double', 1800, 2, 22),
	(4, 'Deluxe Double', 2000, 2, 24),
	(6, 'Deluxe Triple', 3300, 3, 41),
	(5, 'Standart Triple', 3000, 3, 37),
	(1, 'Standart Single', 1200, 1, 15);


--
-- Data for Name: Personel; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Personel" VALUES
	(101, 'S-001', 8, NULL, '123'),
	(102, 'S-002', 1, 101, '123'),
	(1000, 'S-100', 1, 101, '12345'),
	(1001, 'S-101', 5, 101, '12345'),
	(1002, 'S-102', 6, 101, '12345'),
	(1011, 'S-103', 2, 101, '12345');


--
-- Data for Name: PersonelTur; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."PersonelTur" VALUES
	(2, 'Güvenlik', 25000),
	(3, 'Vale', 25000),
	(4, 'Oda Servis Elemanı', 30000),
	(5, 'Temizlik Görevlisi', 35000),
	(6, 'Garson', 35000),
	(7, 'Aşçı', 40000),
	(8, 'Müdür', 50000),
	(1, 'Resepsiyonist', 25000);


--
-- Data for Name: PersonelYakini; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."PersonelYakini" VALUES
	(1020, 101),
	(1021, 102),
	(1022, 1000),
	(1023, 1001),
	(1024, 1002),
	(1025, 1011);


--
-- Data for Name: Rezervasyon; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Rezervasyon" VALUES
	(5001, '2025-12-08', '2025-12-11', true, 1003, 104),
	(5002, '2025-12-08', '2025-12-13', true, 1004, 201),
	(5003, '2025-12-09', '2025-12-12', true, 1005, 301),
	(5004, '2025-12-08', '2025-12-10', true, 1006, 106),
	(5005, '2025-12-08', '2025-12-15', true, 1007, 205);


--
-- Data for Name: RezervasyonHizmet; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."RezervasyonHizmet" VALUES
	(2, 5001),
	(3, 5001),
	(4, 5002),
	(1, 5004),
	(5, 5005);


--
-- Data for Name: RezervasyonLog; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- Name: Fatura_faturaNo_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Fatura_faturaNo_seq"', 1, false);


--
-- Name: IletisimBilgisi_iletisimID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."IletisimBilgisi_iletisimID_seq"', 22, true);


--
-- Name: Kisi_kisiID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Kisi_kisiID_seq"', 1, false);


--
-- Name: RezervasyonLog_logID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."RezervasyonLog_logID_seq"', 1, true);


--
-- Name: Rezervasyon_rezervasyonID_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public."Rezervasyon_rezervasyonID_seq"', 1, true);


--
-- Name: RezervasyonLog RezervasyonLog_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RezervasyonLog"
    ADD CONSTRAINT "RezervasyonLog_pkey" PRIMARY KEY ("logID");


--
-- Name: IletisimBilgisi eMailUnique; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."IletisimBilgisi"
    ADD CONSTRAINT "eMailUnique" UNIQUE ("eMail");


--
-- Name: Fatura faturaPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Fatura"
    ADD CONSTRAINT "faturaPK" PRIMARY KEY ("faturaNo");


--
-- Name: Hizmet hizmetPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Hizmet"
    ADD CONSTRAINT "hizmetPK" PRIMARY KEY ("hizmetNo");


--
-- Name: Il ilPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Il"
    ADD CONSTRAINT "ilPK" PRIMARY KEY ("ilNo");


--
-- Name: Ilce ilcePK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Ilce"
    ADD CONSTRAINT "ilcePK" PRIMARY KEY ("ilceNo");


--
-- Name: IletisimBilgisi iletisimBilgisiPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."IletisimBilgisi"
    ADD CONSTRAINT "iletisimBilgisiPK" PRIMARY KEY ("iletisimID");


--
-- Name: Kisi kimlikNoUnique; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Kisi"
    ADD CONSTRAINT "kimlikNoUnique" UNIQUE ("kimlikNo");


--
-- Name: Kisi kisiPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Kisi"
    ADD CONSTRAINT "kisiPK" PRIMARY KEY ("kisiID");


--
-- Name: IletisimBilgisi kisiUnique; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."IletisimBilgisi"
    ADD CONSTRAINT "kisiUnique" UNIQUE ("kisiID");


--
-- Name: Misafir misafirPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Misafir"
    ADD CONSTRAINT "misafirPK" PRIMARY KEY ("misafirID");


--
-- Name: MisafirRezervasyon misafirRezervasyonPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."MisafirRezervasyon"
    ADD CONSTRAINT "misafirRezervasyonPK" PRIMARY KEY ("misafirID", "rezervasyonID");


--
-- Name: Musteri musteriPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Musteri"
    ADD CONSTRAINT "musteriPK" PRIMARY KEY ("musteriID");


--
-- Name: Oda odaPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Oda"
    ADD CONSTRAINT "odaPK" PRIMARY KEY ("odaNo");


--
-- Name: OdaTur odaTurPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."OdaTur"
    ADD CONSTRAINT "odaTurPK" PRIMARY KEY ("odaTurID");


--
-- Name: Personel personelPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Personel"
    ADD CONSTRAINT "personelPK" PRIMARY KEY ("personelID");


--
-- Name: PersonelTur personelTurPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PersonelTur"
    ADD CONSTRAINT "personelTurPK" PRIMARY KEY ("personelTurID");


--
-- Name: PersonelYakini personelYakiniPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PersonelYakini"
    ADD CONSTRAINT "personelYakiniPK" PRIMARY KEY ("personelYakinID", "personelID");


--
-- Name: RezervasyonHizmet rezervasyonHizmetPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RezervasyonHizmet"
    ADD CONSTRAINT "rezervasyonHizmetPK" PRIMARY KEY ("hizmetNo", "rezervasyonID");


--
-- Name: Fatura rezervasyonIDUnique; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Fatura"
    ADD CONSTRAINT "rezervasyonIDUnique" UNIQUE ("rezervasyonID");


--
-- Name: Rezervasyon rezervasyonPK; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Rezervasyon"
    ADD CONSTRAINT "rezervasyonPK" PRIMARY KEY ("rezervasyonID");


--
-- Name: Personel sicilNoUnique; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Personel"
    ADD CONSTRAINT "sicilNoUnique" UNIQUE ("sicilNo");


--
-- Name: IletisimBilgisi telNoUnique; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."IletisimBilgisi"
    ADD CONSTRAINT "telNoUnique" UNIQUE ("telNo");


--
-- Name: Rezervasyon trg_OdaDurumOtomatik; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER "trg_OdaDurumOtomatik" AFTER INSERT OR DELETE OR UPDATE ON public."Rezervasyon" FOR EACH ROW EXECUTE FUNCTION public."fn_RezervasyonOdaDurumGuncelle"();


--
-- Name: Rezervasyon trg_RezervasyonSilinince; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER "trg_RezervasyonSilinince" AFTER DELETE ON public."Rezervasyon" FOR EACH ROW EXECUTE FUNCTION public."fn_RezervasyonSilLog"();


--
-- Name: Kisi trg_TCKNUzunluk; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER "trg_TCKNUzunluk" BEFORE INSERT OR UPDATE ON public."Kisi" FOR EACH ROW EXECUTE FUNCTION public."fn_TCKNKontrol"();


--
-- Name: Rezervasyon trg_TarihKontrol; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER "trg_TarihKontrol" BEFORE INSERT ON public."Rezervasyon" FOR EACH ROW EXECUTE FUNCTION public."fn_GecmisTarihKontrol"();


--
-- Name: Personel PersonelKisi; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Personel"
    ADD CONSTRAINT "PersonelKisi" FOREIGN KEY ("personelID") REFERENCES public."Kisi"("kisiID") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: RezervasyonHizmet hizmetFK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RezervasyonHizmet"
    ADD CONSTRAINT "hizmetFK" FOREIGN KEY ("hizmetNo") REFERENCES public."Hizmet"("hizmetNo") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: Ilce ilFK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Ilce"
    ADD CONSTRAINT "ilFK" FOREIGN KEY ("ilNo") REFERENCES public."Il"("ilNo");


--
-- Name: IletisimBilgisi ilceFK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."IletisimBilgisi"
    ADD CONSTRAINT "ilceFK" FOREIGN KEY ("ilceNo") REFERENCES public."Ilce"("ilceNo");


--
-- Name: IletisimBilgisi kisiFK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."IletisimBilgisi"
    ADD CONSTRAINT "kisiFK" FOREIGN KEY ("kisiID") REFERENCES public."Kisi"("kisiID") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: MisafirRezervasyon misafirFK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."MisafirRezervasyon"
    ADD CONSTRAINT "misafirFK" FOREIGN KEY ("misafirID") REFERENCES public."Misafir"("misafirID") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: Misafir misafirKisi; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Misafir"
    ADD CONSTRAINT "misafirKisi" FOREIGN KEY ("misafirID") REFERENCES public."Kisi"("kisiID") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: Misafir musteriFK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Misafir"
    ADD CONSTRAINT "musteriFK" FOREIGN KEY ("musteriID") REFERENCES public."Musteri"("musteriID") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: Rezervasyon musteriFK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Rezervasyon"
    ADD CONSTRAINT "musteriFK" FOREIGN KEY ("musteriID") REFERENCES public."Musteri"("musteriID") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: Musteri musteriKisi; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Musteri"
    ADD CONSTRAINT "musteriKisi" FOREIGN KEY ("musteriID") REFERENCES public."Kisi"("kisiID") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: Rezervasyon odaFK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Rezervasyon"
    ADD CONSTRAINT "odaFK" FOREIGN KEY ("odaNo") REFERENCES public."Oda"("odaNo") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: Oda odaTurFK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Oda"
    ADD CONSTRAINT "odaTurFK" FOREIGN KEY ("odaTuruID") REFERENCES public."OdaTur"("odaTurID");


--
-- Name: Personel personelFK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Personel"
    ADD CONSTRAINT "personelFK" FOREIGN KEY (mudur) REFERENCES public."Personel"("personelID");


--
-- Name: PersonelYakini personelFK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PersonelYakini"
    ADD CONSTRAINT "personelFK" FOREIGN KEY ("personelID") REFERENCES public."Personel"("personelID") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: Personel personelTurFK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Personel"
    ADD CONSTRAINT "personelTurFK" FOREIGN KEY ("personelTurID") REFERENCES public."PersonelTur"("personelTurID");


--
-- Name: PersonelYakini personelYakiniKisi; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."PersonelYakini"
    ADD CONSTRAINT "personelYakiniKisi" FOREIGN KEY ("personelYakinID") REFERENCES public."Kisi"("kisiID") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: Fatura rezervasyonFK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Fatura"
    ADD CONSTRAINT "rezervasyonFK" FOREIGN KEY ("rezervasyonID") REFERENCES public."Rezervasyon"("rezervasyonID") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: MisafirRezervasyon rezervasyonFK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."MisafirRezervasyon"
    ADD CONSTRAINT "rezervasyonFK" FOREIGN KEY ("rezervasyonID") REFERENCES public."Rezervasyon"("rezervasyonID") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- Name: RezervasyonHizmet rezervasyonFK; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RezervasyonHizmet"
    ADD CONSTRAINT "rezervasyonFK" FOREIGN KEY ("rezervasyonID") REFERENCES public."Rezervasyon"("rezervasyonID") ON UPDATE CASCADE ON DELETE CASCADE;


--
-- PostgreSQL database dump complete
--

\unrestrict YqrZz8AuFmtdqvZBqaJ9BiuM3z2WWZ1nh5YfFlrHEncoUqSjmhEZ5ojjczHXGoL

