using Npgsql;
using System.Data;

namespace Otel_Rezervasyon_Sistemi
{
    public class RezervasyonIslemleri
    {
        // 1. MÜŞTERİ LİSTESİ (ComboBox Doldurmak İçin)
        public DataTable MusteriListesiGetir()
        {
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {
                string sql = @"SELECT k.""kimlikNo"" 
                               FROM ""Musteri"" m 
                               JOIN ""Kisi"" k ON m.""musteriID"" = k.""kisiID"" 
                               ORDER BY k.""kisiAdi""";
                using (var cmd = new NpgsqlCommand(sql, baglanti))
                {
                    DataTable dt = new DataTable();
                    new NpgsqlDataAdapter(cmd).Fill(dt);
                    return dt;
                }
            }
        }

        // 2. MÜŞTERİYE AİT MİSAFİRLERİ GETİR (Alt Sorgu Yöntemi - En Garantisi)
        public DataTable MusteriyeAitMisafirleriGetir(string musteriTCKN)
        {
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {
                // Müşterinin TCKN'sine göre ID'sini bulup, o ID'ye bağlı misafirleri çekiyoruz.
                string sql = @"
                    SELECT k.""kimlikNo""
                    FROM ""Misafir"" m
                    JOIN ""Kisi"" k ON m.""misafirID"" = k.""kisiID""
                    WHERE m.""musteriID"" = (
                        SELECT ""kisiID"" FROM ""Kisi"" WHERE ""kimlikNo"" = @tc LIMIT 1
                    )";

                using (var cmd = new NpgsqlCommand(sql, baglanti))
                {
                    cmd.Parameters.AddWithValue("@tc", musteriTCKN.Trim());
                    DataTable dt = new DataTable();
                    new NpgsqlDataAdapter(cmd).Fill(dt);
                    return dt;
                }
            }
        }

        // 3. MÜSAİT ODALARI GETİR (Kapasite ve Tarih Kontrollü)
        public DataTable MusaitOdalariGetir(DateTime giris, DateTime cikis, int kisiSayisi)
        {
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {
                // MANTIK: 
                // 1. Tarih çakışması olmayan odaları bul.
                // 2. Bu odaların kapasitesi, toplam kişi sayısına (Müşteri + Misafirler) TAM EŞİT olsun.
                string sql = @"
                    SELECT o.""odaNo"" 
                    FROM ""Oda"" o
                    JOIN ""OdaTur"" ot ON o.""odaTuruID"" = ot.""odaTurID""
                    WHERE o.""odaNo"" NOT IN (
                        SELECT ""odaNo"" FROM ""Rezervasyon""
                        WHERE 
                            (@giris < ""bitisTarihi"" AND @cikis > ""baslangicTarihi"")
                            AND ""rezervasyonDurumu"" = TRUE
                    )
                    AND ot.""odaKapasite"" = @kisi 
                    ORDER BY o.""odaNo"" ASC";

                using (var cmd = new NpgsqlCommand(sql, baglanti))
                {
                    cmd.Parameters.AddWithValue("@giris", giris);
                    cmd.Parameters.AddWithValue("@cikis", cikis);
                    cmd.Parameters.AddWithValue("@kisi", kisiSayisi);

                    DataTable dt = new DataTable();
                    new NpgsqlDataAdapter(cmd).Fill(dt);
                    return dt;
                }
            }
        }

        // 4. REZERVASYON YAP (Transaction ile Güvenli Kayıt)
        public int RezervasyonYap(string musteriTCKN, DateTime giris, DateTime cikis, int odaNo, List<int> hizmetIDleri, List<string> misafirTCKNleri)
        {
            int yeniRezervasyonID = 0;

            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {
                using (var islem = baglanti.BeginTransaction())
                {
                    try
                    {
                        // A) Müşteri ID Bul
                        int musteriID = 0;
                        string idSql = @"SELECT ""kisiID"" FROM ""Kisi"" WHERE ""kimlikNo""=@tc";
                        using (var cmd = new NpgsqlCommand(idSql, baglanti))
                        {
                            cmd.Parameters.AddWithValue("@tc", musteriTCKN);
                            object sonuc = cmd.ExecuteScalar();
                            if (sonuc == null) throw new Exception("Seçilen müşteri veritabanında bulunamadı!");
                            musteriID = (int)sonuc;
                        }

                        // B) Rezervasyon Tablosuna Ekle
                        string rezSql = @"INSERT INTO ""Rezervasyon"" (""baslangicTarihi"", ""bitisTarihi"", ""rezervasyonDurumu"", ""musteriID"", ""odaNo"") 
                                          VALUES (@giris, @cikis, TRUE, @mid, @oda) RETURNING ""rezervasyonID""";

                        using (var cmd = new NpgsqlCommand(rezSql, baglanti))
                        {
                            cmd.Parameters.AddWithValue("@giris", giris);
                            cmd.Parameters.AddWithValue("@cikis", cikis);
                            cmd.Parameters.AddWithValue("@mid", musteriID);
                            cmd.Parameters.AddWithValue("@oda", (short)odaNo);
                            yeniRezervasyonID = (int)cmd.ExecuteScalar();
                        }

                        // C) Hizmetleri Ekle
                        foreach (int hizmetID in hizmetIDleri)
                        {
                            string hizmetSql = @"INSERT INTO ""RezervasyonHizmet"" (""hizmetNo"", ""rezervasyonID"") 
                                                 VALUES (@hid, @rid)";
                            using (var cmd = new NpgsqlCommand(hizmetSql, baglanti))
                            {
                                cmd.Parameters.AddWithValue("@hid", (short)hizmetID);
                                cmd.Parameters.AddWithValue("@rid", yeniRezervasyonID);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // D) Misafirleri Ekle (MisafirRezervasyon tablosuna)
                        foreach (string misafirTC in misafirTCKNleri)
                        {
                            // 1. Misafir ID'sini Bul
                            int misafirID = 0;
                            string mIdSql = @"SELECT ""kisiID"" FROM ""Kisi"" WHERE ""kimlikNo""=@mtc";

                            using (var cmd = new NpgsqlCommand(mIdSql, baglanti))
                            {
                                cmd.Parameters.AddWithValue("@mtc", misafirTC);
                                object sonuc = cmd.ExecuteScalar();
                                if (sonuc != null) misafirID = (int)sonuc;
                                else continue; // Eğer misafir bulunamazsa atla (Hata vermesin)
                            }

                            // 2. Ara Tabloya Ekle
                            string mrSql = @"INSERT INTO ""MisafirRezervasyon"" (""misafirID"", ""rezervasyonID"") VALUES (@mid, @rid)";
                            using (var cmd = new NpgsqlCommand(mrSql, baglanti))
                            {
                                cmd.Parameters.AddWithValue("@mid", misafirID);
                                cmd.Parameters.AddWithValue("@rid", yeniRezervasyonID);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        islem.Commit(); // Hata yoksa işlemi onayla
                    }
                    catch (Exception ex)
                    {
                        islem.Rollback(); // Hata varsa her şeyi geri al
                        throw ex;
                    }
                }
            }
            return yeniRezervasyonID;
        }

        // 5. REZERVASYONLARI LİSTELE (Durum Bilgisi Dahil)
        public DataTable RezervasyonlariListele()
        {
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {
                string sql = @"
                    SELECT 
                        r.""rezervasyonID"" AS ""ID"",
                        k.""kisiAdi"" || ' ' || k.""kisiSoyadi"" AS ""Müşteri"",
                        r.""odaNo"" AS ""Oda"",
                        r.""baslangicTarihi"" AS ""Giriş"",
                        r.""bitisTarihi"" AS ""Çıkış"",
                        CASE WHEN r.""rezervasyonDurumu"" = TRUE THEN 'Aktif' ELSE 'Pasif' END AS ""Durum""
                    FROM ""Rezervasyon"" r
                    JOIN ""Kisi"" k ON r.""musteriID"" = k.""kisiID""
                    ORDER BY r.""rezervasyonID"" DESC";

                using (var cmd = new NpgsqlCommand(sql, baglanti))
                {
                    DataTable dt = new DataTable(); // Tablo oluştur
                    new NpgsqlDataAdapter(cmd).Fill(dt); // Verileri doldur
                    return dt;
                }
            }
        }

        // 6. REZERVASYON ARA (TCKN İle)
        public DataTable RezervasyonAra(string tckn)
        {
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {   // TCKN ile başlayan kayıtları getir
                string sql = @"
                    SELECT 
                        r.""rezervasyonID"" AS ""ID"",
                        k.""kisiAdi"" || ' ' || k.""kisiSoyadi"" AS ""Müşteri"",
                        k.""kimlikNo"" AS ""TCKN"",
                        r.""odaNo"" AS ""Oda"",
                        r.""baslangicTarihi"" AS ""Giriş"",
                        r.""bitisTarihi"" AS ""Çıkış"",
                        CASE WHEN r.""rezervasyonDurumu"" = TRUE THEN 'Aktif' ELSE 'Pasif' END AS ""Durum""
                    FROM ""Rezervasyon"" r
                    JOIN ""Kisi"" k ON r.""musteriID"" = k.""kisiID""
                    WHERE k.""kimlikNo"" LIKE @tc
                    ORDER BY r.""rezervasyonID"" DESC";

                using (var cmd = new NpgsqlCommand(sql, baglanti))
                {
                    cmd.Parameters.AddWithValue("@tc", tckn + "%"); // Başlangıç ile eşleşenler
                    DataTable dt = new DataTable(); // Tablo oluştur
                    new NpgsqlDataAdapter(cmd).Fill(dt); // Verileri doldur
                    return dt;
                }
            }
        }

        // 7. REZERVASYON SİL (Trigger-1 Otomatik Çalışır)
        public bool RezervasyonSil(int id)
        {
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {   // RezervasyonID'ye göre sil
                string sql = @"DELETE FROM ""Rezervasyon"" WHERE ""rezervasyonID"" = @id";
                using (var cmd = new NpgsqlCommand(sql, baglanti)) // Komut oluştur
                {
                    cmd.Parameters.AddWithValue("@id", id); // Parametre ekle
                    return cmd.ExecuteNonQuery() > 0; // Etkilenen satır sayısını döndür
                }
            }
        }

        // 8. FATURA OLUŞTUR (SAKLI YORDAM-1 Çağırır)
        public void FaturaOlustur(int rezervasyonID)
        {
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {
                // SQL'de yazdığımız prosedürü çağırıyoruz
                using (var cmd = new NpgsqlCommand("CALL \"sp_FaturaOlustur\"(@id)", baglanti)) // Komut oluştur
                {
                    cmd.Parameters.AddWithValue("@id", rezervasyonID); // Parametre ekle
                    cmd.ExecuteNonQuery();
                }
            }
        }
        // 9. FATURA ARAMA (TCKN ve Tarih Aralığı)
        public DataTable FaturaAra(string tckn, DateTime baslangic, DateTime bitis)
        {
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {   // 
                string sql = @"
                    SELECT 
                        f.""faturaNo"" AS ""Fatura No"",
                        k.""kimlikNo"" AS ""Müşteri TC"",
                        k.""kisiAdi"" || ' ' || k.""kisiSoyadi"" AS ""Ad Soyad"",
                        r.""odaNo"" AS ""Oda"",
                        f.""faturaTarihi"" AS ""Tarih"",
                        f.""faturaTutari"" AS ""Tutar""
                    FROM ""Fatura"" f
                    JOIN ""Rezervasyon"" r ON f.""rezervasyonID"" = r.""rezervasyonID""
                    JOIN ""Kisi"" k ON r.""musteriID"" = k.""kisiID""
                    WHERE f.""faturaTarihi"" BETWEEN @bas AND @bit ";

                // Eğer TCKN doluysa onu da filtreye ekle
                if (!string.IsNullOrEmpty(tckn))
                {
                    sql += " AND k.\"kimlikNo\" LIKE @tc";
                }

                sql += " ORDER BY f.\"faturaTarihi\" DESC";

                using (var cmd = new NpgsqlCommand(sql, baglanti))
                {
                    cmd.Parameters.AddWithValue("@bas", baslangic.Date);
                    cmd.Parameters.AddWithValue("@bit", bitis.Date);

                    if (!string.IsNullOrEmpty(tckn))
                        cmd.Parameters.AddWithValue("@tc", tckn + "%");

                    DataTable dt = new DataTable(); // Tablo oluştur
                    new NpgsqlDataAdapter(cmd).Fill(dt); // Verileri doldur
                    return dt;
                }
            }
        }
        // 10. FATURA DETAYI GETİR
        public string FaturaDetayGetir(int faturaNo)
        {
            string detay = "";
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {
                // Ana müşterinin adını saklamak için değişken (Listeye ekleyeceğiz)
                string anaMusteriAd = "";

                // 1. ADIM: GENEL BİLGİLERİ VE TARİHLERİ AL
                string sqlGenel = @"
                        SELECT 
                            k.""kisiAdi"" || ' ' || k.""kisiSoyadi"" AS ""MusteriAd"",
                            k.""kimlikNo"",
                            i.""telNo"", i.""eMail"",
                            f.""faturaTarihi"", 
                            r.""baslangicTarihi"", r.""bitisTarihi"", r.""odaNo"",
                            r.""rezervasyonID""
                        FROM ""Fatura"" f
                        JOIN ""Rezervasyon"" r ON f.""rezervasyonID"" = r.""rezervasyonID""
                        JOIN ""Kisi"" k ON r.""musteriID"" = k.""kisiID""
                        LEFT JOIN ""IletisimBilgisi"" i ON k.""kisiID"" = i.""kisiID""
                        WHERE f.""faturaNo"" = @fno";

                int rezervasyonID = 0;
                int gunSayisi = 0;
                int kisiSayisi = 0;

                using (var cmd = new NpgsqlCommand(sqlGenel, baglanti))
                {
                    cmd.Parameters.AddWithValue("@fno", faturaNo); // Fatura Numarası Parametresi
                    using (var dr = cmd.ExecuteReader()) // Veri Okuyucu
                    {
                        if (dr.Read())
                        {
                            rezervasyonID = Convert.ToInt32(dr["rezervasyonID"]);
                            anaMusteriAd = dr["MusteriAd"].ToString(); // Müşteri adını aldık

                            // DateOnly Dönüşümleri
                            DateOnly giris = (DateOnly)dr["baslangicTarihi"];
                            DateOnly cikis = (DateOnly)dr["bitisTarihi"];
                            DateOnly faturaTarih = (DateOnly)dr["faturaTarihi"];
                            gunSayisi = cikis.DayNumber - giris.DayNumber;

                            detay += "=======================================\n";
                            detay += "            OTEL FATURASI               \n";
                            detay += "=======================================\n\n";
                            detay += $"Fatura No : {faturaNo}\n";
                            detay += $"Tarih     : {faturaTarih}\n\n";

                            detay += "--- MÜŞTERİ BİLGİLERİ ---\n";
                            detay += $"Ad Soyad  : {anaMusteriAd}\n";
                            detay += $"TCKN      : {dr["kimlikNo"]}\n";
                            detay += $"Telefon   : {dr["telNo"]}\n";
                            detay += $"E-Posta   : {dr["eMail"]}\n\n";

                            detay += "--- KONAKLAMA DETAYLARI ---\n";
                            detay += $"Oda No    : {dr["odaNo"]}\n";
                            detay += $"Giriş     : {giris}\n";
                            detay += $"Çıkış     : {cikis}\n";
                            detay += $"Süre      : {gunSayisi} Gece / Gün\n\n";
                        }
                        else
                        {
                            return "Fatura bulunamadı.";
                        }
                    }
                }

                // 2. ADIM: KİŞİ SAYISINI HESAPLA
                string sqlKisiSayisi = "SELECT COUNT(*) FROM \"MisafirRezervasyon\" WHERE \"rezervasyonID\" = @rid";
                using (var cmd = new NpgsqlCommand(sqlKisiSayisi, baglanti))
                {
                    cmd.Parameters.AddWithValue("@rid", rezervasyonID);
                    kisiSayisi = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
                }

                // 3. ADIM: KONAKLAYANLAR LİSTESİ (Müşteri + Misafirler)
                string sqlMisafir = @"
                            SELECT k.""kisiAdi"" || ' ' || k.""kisiSoyadi"" AS ""Ad""
                            FROM ""MisafirRezervasyon"" mr
                            JOIN ""Kisi"" k ON mr.""misafirID"" = k.""kisiID""
                            WHERE mr.""rezervasyonID"" = @rid";

                detay += $"--- KONAKLAYANLAR ({kisiSayisi} Kişi) ---\n";

                // Önce Ana Müşteriyi listeye manuel ekliyoruz
                detay += $"- {anaMusteriAd} (Rezervasyon Sahibi)\n";

                // Sonra Misafirleri ekliyoruz
                using (var cmd = new NpgsqlCommand(sqlMisafir, baglanti))
                {
                    cmd.Parameters.AddWithValue("@rid", rezervasyonID);
                    using (var dr = cmd.ExecuteReader()) // Veri Okuyucu
                    {
                        while (dr.Read())
                        {
                            detay += $"- {dr["Ad"]}\n";
                        }
                    }
                }
                detay += "\n";

                // 4. ADIM: HİZMET VE FİYAT DÖKÜMÜ
                string sqlHizmet = @"
                            SELECT h.""hizmetAdi"", h.""hizmetFiyati"", h.""hizmetNo""
                            FROM ""RezervasyonHizmet"" rh
                            JOIN ""Hizmet"" h ON rh.""hizmetNo"" = h.""hizmetNo""
                            WHERE rh.""rezervasyonID"" = @rid";

                detay += "--- HİZMET VE ÜCRET DETAYLARI ---\n";

                using (var cmd = new NpgsqlCommand(sqlHizmet, baglanti))
                {
                    cmd.Parameters.AddWithValue("@rid", rezervasyonID);
                    using (var dr = cmd.ExecuteReader()) // Veri Okuyucu
                    {
                        bool hizmetVarMi = false;
                        while (dr.Read()) // Her hizmet için
                        {
                            hizmetVarMi = true;
                            string ad = dr["hizmetAdi"].ToString();
                            decimal fiyat = Convert.ToDecimal(dr["hizmetFiyati"]);
                            int hNo = Convert.ToInt32(dr["hizmetNo"]);

                            decimal toplam = 0;

                            // Temizlik (ID=5) ise Kişi sayısıyla çarpılmaz
                            if (hNo == 5)
                            {
                                toplam = fiyat * gunSayisi;
                                detay += $"{ad,-15}: {fiyat} TL x {gunSayisi} Gün = {toplam} TL\n";
                            }
                            else
                            {
                                toplam = fiyat * gunSayisi * kisiSayisi;
                                detay += $"{ad,-15}: {fiyat} TL x {gunSayisi} Gün x {kisiSayisi} Kişi = {toplam} TL\n";
                            }
                        }
                        if (!hizmetVarMi) detay += "(Ekstra Hizmet Yok)\n";
                    }
                }

                // 5. ADIM: GENEL TOPLAM
                using (var cmd = new NpgsqlCommand("SELECT \"faturaTutari\" FROM \"Fatura\" WHERE \"faturaNo\"=@fno", baglanti))
                {
                    cmd.Parameters.AddWithValue("@fno", faturaNo);
                    object tutar = cmd.ExecuteScalar();

                    detay += "\n=======================================\n";
                    detay += $"GENEL TOPLAM : {tutar} TL\n";
                    detay += "=======================================\n";
                }
            }
            return detay;
        }
        // 11. ODA LİSTESİ (Sadece numaralar)
        public DataTable OdaNumaralariniGetir()
        {
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {
                string sql = "SELECT \"odaNo\" FROM \"Oda\" ORDER BY \"odaNo\" ASC";
                using (var cmd = new NpgsqlCommand(sql, baglanti))
                {
                    DataTable dt = new DataTable();
                    new NpgsqlDataAdapter(cmd).Fill(dt);
                    return dt;
                }
            }
        }
        // 12. HİZMET DÖKÜMÜ (Oda Numarasına Göre Filtreli)
        // odaNo parametresi 0 veya -1 gelirse "Tüm Odalar" demektir.
        public DataTable HizmetleriListele(int odaNo)
        {
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {   
                string sql = @"
                        SELECT 
                            r.""rezervasyonID"" AS ""Rezervasyon ID"",
                            r.""odaNo"" AS ""Oda No"",
                            h.""hizmetAdi"" AS ""Hizmet Adı"",
                            h.""hizmetFiyati"" AS ""Fiyat"",
                            i.""telNo"" AS ""Müşteri Telefon""
                        FROM ""RezervasyonHizmet"" rh
                        JOIN ""Rezervasyon"" r ON rh.""rezervasyonID"" = r.""rezervasyonID""
                        JOIN ""Hizmet"" h ON rh.""hizmetNo"" = h.""hizmetNo""
                        JOIN ""Kisi"" k ON r.""musteriID"" = k.""kisiID""
                        LEFT JOIN ""IletisimBilgisi"" i ON k.""kisiID"" = i.""kisiID""
                        WHERE 1=1 ";

                // Eğer belirli bir oda seçildiyse filtrele (0 değilse)
                if (odaNo > 0)
                {
                    sql += " AND r.\"odaNo\" = @oda";
                }

                sql += " ORDER BY r.\"odaNo\", r.\"rezervasyonID\" DESC";

                using (var cmd = new NpgsqlCommand(sql, baglanti))
                {
                    if (odaNo > 0) cmd.Parameters.AddWithValue("@oda", (short)odaNo);

                    DataTable dt = new DataTable();
                    new NpgsqlDataAdapter(cmd).Fill(dt);
                    return dt;
                }
            }
        }

        // 13. GEÇMİŞ REZERVASYONLARI PASİF YAP (SAKLI YORDAM-2 Çağırır)
        public void GecmisRezervasyonlariGuncelle()
        {
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {
                // SQL'de yazdığımız prosedürü çağırıyoruz
                using (var cmd = new NpgsqlCommand("CALL \"sp_GecmisRezervasyonlariPasifYap\"()", baglanti))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}