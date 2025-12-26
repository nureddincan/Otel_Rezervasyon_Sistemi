# 🏨 Otel Rezervasyon Sistemi

**Sakarya Üniversitesi - Bilgisayar Mühendisliği**
**BSM 211 - Veritabanı Yönetim Sistemleri Dersi Projesi**

Bu proje, otellerin günlük operasyonlarını (rezervasyon, müşteri kaydı, personel yönetimi, faturalandırma) dijital ortamda verimli bir şekilde yönetmelerini sağlayan kapsamlı bir masaüstü uygulamasıdır. **Database-First** yaklaşımı kullanılarak geliştirilmiştir.

---

## 🚀 Proje Hakkında

**Otel Rezervasyon Sistemi**

Ülkemiz, turistik, kültürel ve tarihi açıdan oldukça zengin bir yapıya sahiptir. Bu sayede ülkemizde bulunan oteller her yıl binlerce yabancı ve yerli turisti ağırlamaktadır. Bu durum, otellerin rezervasyon süreçlerini daha kolay ve verimli bir şekilde yönetebilecekleri bir sisteme duydukları ihtiyacı artırmaktadır.

Bu ihtiyaç doğrultusunda geliştirilen bu sistem, otellerin müşterilerini pratik ve sorunsuz bir şekilde sisteme kaydetmelerine ve rezervasyon sürecinde yaşanabilecek olumsuz durumları en aza indirgelemelerine yardımcı olmayı hedefler.

Ayrıca sistem; sadece müşteri ve rezervasyon işlemlerini değil, buna ek olarak **personelin kayıt, iletişim ve maaş süreçlerinin takibini** sağlayarak temel düzeyde bir personel yönetim işlevini de yerine getirmektedir.

## 📐 Veritabanı Tasarımı (ER Diyagramı)

Projenin veritabanı mimarisi, **Crow's Foot** notasyonu kullanılarak tasarlanmış ve **Kalıtım (Inheritance)** yapısı üzerine kurulmuştur.
![VBD](https://github.com/user-attachments/assets/9800216e-d2ad-4139-a3c1-dea864e8ae2f)

## 📋 İş Kuralları ve Veritabanı Mantığı

Veritabanı, aşağıdaki 33 temel iş kuralına sadık kalınarak tasarlanmıştır:

<details>
<summary><strong>İş Kurallarını Görüntülemek İçin Tıklayınız</strong></summary>

1. Odaların oda numarası, kat ve oda durumu bilgileri mevcuttur.
2. Odaların fiyatı ve kapasitesi oda türüne göre belirlenir.
3. Oda Türünün oda tür ID’si, oda tür adı, oda fiyatı, oda kapasitesi ve oda metrekare bilgileri mevcuttur.
4. Kişilerin kişi ID’si, kimlik numarası, adı, soyadı, cinsiyeti ve kişi türü bilgisi vardır.
5. İletişim Bilgisinde iletişim ID’si, telefon numarası, e-posta, adres, ilçe bilgileri mevcuttur.
6. İlçe, ilçe numarası, ilçe adı, il bilgisinden oluşur.
7. İl, il numarası ve il adından oluşur.
8. Personeller kişiden kalıtım alır, personellerin sicil numarası ve şifre bilgileri mevcuttur.
9. Personellerin maaşı personelin türüne göre belirlenir.
10. Personel Türü personel tür ID’si, personel tür adı ve personel maaş bilgilerinden oluşur.
11. Personel Yakını kişiden kalıtım alır.
12. Müşteri kişiden kalıtım alır.
13. Misafir kişiden kalıtım alır.
14. Rezervasyonun ID’si, başlangıç tarihi, bitiş tarihi ve rezervasyon durumu bilgileri mevcuttur.
15. Faturanın fatura numarası, fatura tarihi ve fatura tutarı bilgileri mevcuttur.
16. Fatura tutarı, rezervasyonun oda ücreti ve ek hizmet ücretlerinin toplamından oluşur.
17. Hizmetin hizmet numarası, hizmet adı ve hizmet fiyatı bilgileri mevcuttur.
18. Bir oda yalnızca bir oda türüne ait olabilir. Bir oda türünden en az bir en çok çok sayıda oda bulunabilir.
19. Bir kişinin yalnızca bir iletişim bilgisi var olabilir. Bir iletişim bilgisi yalnızca bir kişiye ait olabilir.
20. Bir iletişim bilgisinde yalnızca bir ilçe bilgisi bulunur. Bir ilçe en az sıfır en çok çok sayıda iletişim bilgisinde bulunabilir.
21. Bir ilçe yalnızca bir ile aittir. Bir il en az bir en çok çok sayıda ilçeden oluşur.
22. Bir personelin en az sıfır en çok çok sayıda yakını olabilir. Bir personel yakını yalnızca bir personele aittir.
23. Bir personele bağlı olmayan personel yakını bulunamaz.
24. Bir müşterinin en az sıfır en çok çok sayıda misafiri olabilir. Bir misafir yalnızca bir müşteriye ait olabilir.
25. Bir personel yalnızca bir personel türüne ait olabilir. Bir personel türünden en az bir en çok sayıda personel bulunabilir.
26. Bir rezervasyonun yalnızca bir faturası vardır. Bir fatura yalnızca bir rezervasyona aittir.
27. Bir müşteri en az sıfır en çok çok sayıda rezervasyon yapabilir. Bir rezervasyonu yalnızca bir müşteri yapabilir.
28. Bir misafir en az sıfır en çok çok sayıda rezervasyona ait olabilir. Bir rezervasyonun en az sıfır en çok iki misafir bilgisi vardır.
29. Bir oda en az sıfır en çok çok sayıda rezervasyona ait olabilir. Bir rezervasyonda yalnızca bir oda bulunur.
30. Bir oda aynı tarih aralığında birden fazla rezervasyona ait olamaz.
31. Bir rezervasyonda en az sıfır en çok çok sayıda hizmet olabilir. Bir hizmet en az sıfır en çok çok sayıda rezervasyona ait olabilir.
32. Bir personel, sıfır veya daha fazla personelin aynı zamanda yöneticisidir. Bir personelin sıfır ya da bir yöneticisi olmalıdır.
33. **Loglama:** Silinen rezervasyonların kayıtları tutulacak. Müşteri T.C., ad, soyad, telefon, email; rezervasyon oda numarası, başlangıç tarihi, bitiş tarihi, silinme tarihi ve işlemi yapan bilgileri tutulacaktır.

</details>

## 🗂️ İlişkisel Şema (Metinsel Gösterim)

Projenin veritabanı tabloları, veri tipleri ve kısıtlamaları (constraints) aşağıdaki gibidir:

```text
Oda(odaNo:smallint, kat:smallint, durum:boolean, odaTuruID:smallint)
OdaTur(odaTurID:smallint, odaTurAdi: varchar(25), odaFiyati:real, odaKapasite:smallint, odaMetrekare: smallint)
Kisi(kisiID:serial, kimlikNo: char(11), kisiAdi:varchar(40), kisiSoyadi:varchar(40), cinsiyet:char(1), kisiTuru:varchar(25))
IletisimBilgisi(iletisimID:serial, telNo:char(11), eMail:varchar(40), adres:varchar(90), ilceNo:smallint, kisiID:int)
Ilce(ilceNo:smallint, ilceAdi:varchar(16), ilNo:char(2))
Il(ilNo:char(2), ilAdi:varchar(14))
Personel(personelID:int, sicilNo:varchar(11), personelTurID:smallint, mudur:int, sifre:varchar(40))
PersonelTur(personelTurID:smallint, personelTurAdi:varchar(20), personelMaas:real)
PersonelYakini(personelYakinID:int, personelID:int)
Musteri(musteriID:int)
Misafir(misafirID:int, musteriID:int)
Rezervasyon(rezervasyonID:serial, baslangicTarihi:date, bitisTarihi: date, rezervasyonDurumu:boolean, musteriID:int, odaNo:smallint)
MisafirRezervasyon(misafirID:int, rezervasyonID:int)
Fatura(faturaNo:serial, faturaTarihi:date, faturaTutari:real, rezervasyonID:int)
Hizmet(hizmetNo:smallint, hizmetAdi:varchar(20), hizmetFiyati:real)
RezervasyonHizmet(rezervasyonID:int, hizmetNo:smallint)
RezervasyonLog(logID: integer, silinenRezervasyonID: integer, musteriTC: string, musteriAd: string, musteriSoyad: string, musteriTel: string, musteriEmail: string, odaNo: integer, baslangicTarihi: date, bitisTarihi: date, silinmeTarihi: timestamp, islemiYapan: string)

---

## 👤 Geliştirici
* **Ad Soyad:** Nureddin Can Erdeğer
* **Öğrenci No:** B231210041

---

## 🛠️ Kullanılan Teknolojiler

* **Programlama Dili:** C# (.NET)
* **Arayüz:** Windows Forms Application (WinForms)
* **Veritabanı:** PostgreSQL
* **Veritabanı Sürücüsü:** Npgsql
* **Yaklaşım:** Database-First

---

## ✨ Özellikler

### 1. 🔐 Yetkilendirme ve Giriş
* Personel türüne göre (Müdür, Resepsiyonist vb.) sisteme giriş.
* Rol bazlı yetkilendirme.

### 2. 👥 Personel Yönetimi
* Personel Ekleme, Silme, Güncelleme ve Arama.
* Personel yakınlarının (acil durum kişileri) takibi.
* **Maaş Güncelleme Modülü:** Personel türüne göre toplu maaş zammı yapabilme.

### 3. 🛏️ Oda ve Rezervasyon Yönetimi
* Oda türlerine göre (Single, Double, Suite vb.) dinamik fiyatlandırma.
* **Oda Fiyat Güncelleme Modülü:** Oda türlerinin taban fiyatlarını toplu güncelleme.
* Rezervasyon oluşturma, iptal etme ve sorgulama.
* Müsaitlik durumuna göre oda filtreleme.

### 4. 🧾 Fatura ve Muhasebe
* Konaklama süresi ve ekstra hizmetlere (Yemek, Oda Servisi vb.) göre otomatik fatura hesaplama.
* Günlük ciro ve misafir sayısı raporlama.

### 5. ⚙️ Veritabanı Otomasyonları
* **Otomatik Durum Güncelleme:** Rezervasyon yapıldığında odanın durumu otomatik "DOLU" olur, çıkış yapıldığında "BOŞ" olur.
* **Loglama:** Silinen rezervasyonlar güvenlik amacıyla 'RezervasyonLog' tablosuna kaydedilir.
* **Validasyon:** TCKN doğruluğu ve geçmişe dönük tarih kontrolü veritabanı seviyesinde engellenir.

---

## 🗄️ Veritabanı Mimarisi

Veritabanı tasarımında **Genelleme/Kalıtım (Inheritance)** yapısı kullanılmıştır.
* **Ana Tablo:** 'Kisi'
* **Türetilen Tablolar:** 'Personel', 'Musteri', 'Misafir', 'PersonelYakini2

### Kullanılan Saklı Yordamlar (Stored Procedures)
Sistem içerisinde iş mantığını yöneten 7 adet temel prosedür bulunmaktadır:
1.  **sp_FaturaOlustur**: Rezervasyon süresi ve hizmetleri hesaplayıp fatura keser.
2.  **sp_GecmisRezervasyonlariPasifYap**: Tarihi geçen rezervasyonları otomatik pasife çeker.
3.  **sp_PersonelMaasGuncelle**: Belirli bir pozisyondaki personellerin maaşını günceller.
4.  **sp_OdaFiyatGuncelle**: Oda türlerinin fiyatlarını günceller.
5.  **sp_GunlukCiro**: Belirtilen tarihteki toplam ciroyu hesaplar.
6.  **sp_GunlukYeniRezervasyonSayisi**: Günlük yeni rezervasyon istatistiğini döndürür.
7.  **sp_GunlukToplamMisafir**: Oteldeki anlık misafir sayısını (yanındakiler dahil) hesaplar.

### Kullanılan Tetikleyiciler (Triggers)
Veri tutarlılığı için 4 adet tetikleyici aktiftir:
1.  **trg_RezervasyonSilinince**: Silinen kaydı Log tablosuna taşır.
2.  **trg_TCKNUzunluk**: TC Kimlik numarasının 11 hane ve rakam olmasını zorunlu kılar.
3.  **trg_OdaDurumOtomatik**: Rezervasyon eklenince/silinince oda durumunu (Dolu/Boş) günceller.
4.  **trg_TarihKontrol`**: Geçmiş tarihe rezervasyon yapılmasını engeller.

---

## 🚀 Kurulum

1.  Bu repoyu klonlayın:
    ```bash
    git clone [https://github.com/nureddincan/Otel_Rezervasyon_Sistemi.git](https://github.com/nureddincan/Otel_Rezervasyon_Sistemi.git)
    ```
2.  PostgreSQL üzerinde yeni bir veritabanı oluşturun.
3.  `OtelRezervasyonSistemi.sql` dosyasını bu veritabanına import edin (Restore).
4.  Visual Studio ile projeyi açın.
5.  `VeritabaniBaglantisi.cs` sınıfındaki bağlantı cümlesini (Connection String) kendi PostgreSQL ayarlarınıza göre düzenleyin.
6.  Projeyi derleyin ve çalıştırın.

---

## 📄 Lisans

Bu proje Sakarya Üniversitesi BSM 211 dersi kapsamında hazırlanmıştır. Kaynak gösterilerek eğitim amaçlı kullanılabilir.
