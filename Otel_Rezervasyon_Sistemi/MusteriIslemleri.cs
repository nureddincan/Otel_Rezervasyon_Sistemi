using Npgsql;
using System.Data;

namespace Otel_Rezervasyon_Sistemi
{
    public class MusteriIslemleri
    {
        public bool MusteriEkle(string tckn, string ad, string soyad, string cinsiyet, string tel, string email, string adres, int ilceNo)
        {
            // Bağlantıyı al
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {
                // Transaction (İşlem Bütünlüğü) Başlat
                // Hata olursa yapılan tüm işlemleri geri almamızı sağlar
                using (var islem = baglanti.BeginTransaction())
                {
                    try
                    {
                        // 1. ADIM: Kişi Tablosuna Ekleme ve ID'yi Alma
                        // RETURNING "kisiID" diyerek eklenen ID'yi geri istiyoruz
                        string kisiSql = "INSERT INTO \"Kisi\" (\"kimlikNo\", \"kisiAdi\", \"kisiSoyadi\", \"cinsiyet\", \"kisiTuru\") " +
                                         "VALUES (@tckn, @ad, @soyad, @cinsiyet, 'Musteri') RETURNING \"kisiID\";";

                        int yeniKisiID;

                        using (var cmd = new NpgsqlCommand(kisiSql, baglanti))
                        {
                            cmd.Parameters.AddWithValue("@tckn", tckn);
                            cmd.Parameters.AddWithValue("@ad", ad);
                            cmd.Parameters.AddWithValue("@soyad", soyad);
                            cmd.Parameters.AddWithValue("@cinsiyet", cinsiyet); // 'E' veya 'K'

                            // Sorguyu çalıştır ve dönen ID'yi al
                            yeniKisiID = (int)cmd.ExecuteScalar();
                        }

                        // 2. ADIM: Müşteri Tablosuna Ekleme (Kalıtım)
                        // Müşteri ID'si Kişi ID'si ile aynıdır
                        string musteriSql = "INSERT INTO \"Musteri\" (\"musteriID\") VALUES (@id);";
                        using (var cmd = new NpgsqlCommand(musteriSql, baglanti))
                        {
                            cmd.Parameters.AddWithValue("@id", yeniKisiID);
                            cmd.ExecuteNonQuery();
                        }

                        // 3. ADIM: İletişim Bilgisi Ekleme
                        string iletisimSql = "INSERT INTO \"IletisimBilgisi\" (\"telNo\", \"eMail\", \"adres\", \"ilceNo\", \"kisiID\") " +
                                             "VALUES (@tel, @mail, @adres, @ilce, @kisiID);";
                        using (var cmd = new NpgsqlCommand(iletisimSql, baglanti))
                        {
                            cmd.Parameters.AddWithValue("@tel", tel);
                            cmd.Parameters.AddWithValue("@mail", email);
                            cmd.Parameters.AddWithValue("@adres", adres);
                            cmd.Parameters.AddWithValue("@ilce", ilceNo);
                            cmd.Parameters.AddWithValue("@kisiID", yeniKisiID);
                            cmd.ExecuteNonQuery();
                        }

                        // Hata çıkmadıysa her şeyi onayla (Veritabanına işle)
                        islem.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        // Bir hata olduysa yapılan her şeyi geri al (Rollback)
                        islem.Rollback();
                        MessageBox.Show("Veritabanı Hatası: " + ex.Message);
                        return false;
                    }
                }
            }
        }
        public int IlceIdGetir(string ilceAdi)
        {
            int id = -1; // Bulunamazsa -1 dönsün
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {   // İlçe adından ilçe numarasını getiren sorgu
                string sql = "SELECT \"ilceNo\" FROM \"Ilce\" WHERE \"ilceAdi\" = @ad LIMIT 1";

                using (var cmd = new NpgsqlCommand(sql, baglanti))
                {
                    cmd.Parameters.AddWithValue("@ad", ilceAdi); // İlçe adını parametre olarak ekle
                    object sonuc = cmd.ExecuteScalar(); // Tek bir değer döner

                    if (sonuc != null)
                    {
                        id = Convert.ToInt32(sonuc); // İlçe ID'sini al
                    }
                }
            }
            return id;
        }
        public DataTable MusterileriListele()
        {
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {
                // 4 Tabloyu Birleştiren SQL Sorgusu
                // Müşteri ID, TCKN, Ad, Soyad, Cinsiyet, Telefon, Email ve İlçe Adını getirir
                string sql = @"
                        SELECT 
                            m.""musteriID"" AS ""Müşteri No"",
                            k.""kimlikNo"" AS ""TC Kimlik"",
                            k.""kisiAdi"" AS ""Ad"",
                            k.""kisiSoyadi"" AS ""Soyad"",
                            k.""cinsiyet"" AS ""Cinsiyet"",
                            i.""telNo"" AS ""Telefon"",
                            i.""eMail"" AS ""E-Posta"",
                            il.""ilceAdi"" AS ""İlçe""
                        FROM ""Musteri"" m
                        JOIN ""Kisi"" k ON m.""musteriID"" = k.""kisiID""
                        LEFT JOIN ""IletisimBilgisi"" i ON k.""kisiID"" = i.""kisiID""
                        LEFT JOIN ""Ilce"" il ON i.""ilceNo"" = il.""ilceNo""
                        ORDER BY m.""musteriID"" DESC"; // En son eklenen en üstte görünsün

                using (var cmd = new NpgsqlCommand(sql, baglanti))
                {
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd); // Veri adaptörü
                    DataTable dt = new DataTable(); // Sonuçları tutacak tablo
                    da.Fill(dt); // Verileri tabloya doldur
                    return dt;
                }
            }
        }
        public bool MusteriSil(string kimlikNo)
        {
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {
                // CASCADE sayesinde sadece Kisi tablosundan silmemiz yeterli.
                // Diğer tablolardan (Müşteri, İletişim vb.) otomatik silinir.
                string sql = "DELETE FROM \"Kisi\" WHERE \"kimlikNo\" = @tc";

                using (var cmd = new NpgsqlCommand(sql, baglanti))
                {
                    cmd.Parameters.AddWithValue("@tc", kimlikNo);

                    // ExecuteNonQuery etkilenen satır sayısını döndürür.
                    // Eğer 0'dan büyükse silme başarılı demektir.
                    int etkilenen = cmd.ExecuteNonQuery();
                    return etkilenen > 0;
                }
            }
        }
        public DataTable MusteriAra(string aranacakAd)
        {
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {
                // İsim içinde geçen ifadeyi arayan SQL sorgusu
                string sql = @"
                        SELECT 
                            m.""musteriID"" AS ""Müşteri No"",
                            k.""kimlikNo"" AS ""TC Kimlik"",
                            k.""kisiAdi"" AS ""Ad"",
                            k.""kisiSoyadi"" AS ""Soyad"",
                            k.""cinsiyet"" AS ""Cinsiyet"",
                            i.""telNo"" AS ""Telefon"",
                            i.""eMail"" AS ""E-Posta"",
                            il.""ilceAdi"" AS ""İlçe""
                        FROM ""Musteri"" m
                        JOIN ""Kisi"" k ON m.""musteriID"" = k.""kisiID""
                        LEFT JOIN ""IletisimBilgisi"" i ON k.""kisiID"" = i.""kisiID""
                        LEFT JOIN ""Ilce"" il ON i.""ilceNo"" = il.""ilceNo""
                        WHERE k.""kisiAdi"" ILIKE @ad  -- ILIKE: Büyük/Küçük harf duyarsız arama
                        ORDER BY k.""kisiAdi"" ASC";

                using (var cmd = new NpgsqlCommand(sql, baglanti))
                {
                    // Sadece sonuna % koyuyoruz. Başına koymuyoruz.
                    cmd.Parameters.AddWithValue("@ad", aranacakAd + "%");
                    // "el" yazarsan -> el% -> Sadece Elif, Elmas vb. gelir.

                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        // Güncellenecek kişinin mevcut bilgilerini getirir
        public DataTable MusteriBilgileriniGetir(string tckn)
        {
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {   // 4 Tabloyu Birleştiren SQL Sorgusu
                string sql = @"
            SELECT 
                m.""musteriID"",
                k.""kimlikNo"", k.""kisiAdi"", k.""kisiSoyadi"", k.""cinsiyet"",
                i.""telNo"", i.""eMail"", i.""adres"",
                il.""ilceAdi""
            FROM ""Musteri"" m
            JOIN ""Kisi"" k ON m.""musteriID"" = k.""kisiID""
            LEFT JOIN ""IletisimBilgisi"" i ON k.""kisiID"" = i.""kisiID""
            LEFT JOIN ""Ilce"" il ON i.""ilceNo"" = il.""ilceNo""
            WHERE k.""kimlikNo"" = @tc";

                using (var cmd = new NpgsqlCommand(sql, baglanti))
                {
                    cmd.Parameters.AddWithValue("@tc", tckn); // TCKN parametresi
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd); // Veri adaptörü
                    DataTable dt = new DataTable(); // Sonuçları tutacak tablo
                    da.Fill(dt); // Verileri tabloya doldur
                    return dt;
                }
            }
        }
        public bool MusteriGuncelle(int id, string tckn, string ad, string soyad, string cinsiyet, string tel, string email, string adres, int ilceNo)
        {
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {
                using (var islem = baglanti.BeginTransaction())
                {
                    try
                    {
                        // 1. KİŞİ TABLOSUNU GÜNCELLE
                        string kisiSql = "UPDATE \"Kisi\" SET \"kimlikNo\"=@tc, \"kisiAdi\"=@ad, \"kisiSoyadi\"=@soyad, \"cinsiyet\"=@cinsiyet WHERE \"kisiID\"=@id";
                        using (var cmd = new NpgsqlCommand(kisiSql, baglanti))
                        {
                            cmd.Parameters.AddWithValue("@tc", tckn);
                            cmd.Parameters.AddWithValue("@ad", ad);
                            cmd.Parameters.AddWithValue("@soyad", soyad);
                            cmd.Parameters.AddWithValue("@cinsiyet", cinsiyet);
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }

                        // 2. İLETİŞİM TABLOSUNU GÜNCELLE
                        string iletisimSql = "UPDATE \"IletisimBilgisi\" SET \"telNo\"=@tel, \"eMail\"=@mail, \"adres\"=@adres, \"ilceNo\"=@ilce WHERE \"kisiID\"=@id";
                        using (var cmd = new NpgsqlCommand(iletisimSql, baglanti))
                        {
                            cmd.Parameters.AddWithValue("@tel", tel);
                            cmd.Parameters.AddWithValue("@mail", email);
                            cmd.Parameters.AddWithValue("@adres", adres);
                            cmd.Parameters.AddWithValue("@ilce", ilceNo);
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }

                        islem.Commit(); // Hata yoksa onayla
                        return true;
                    }
                    catch (Exception ex)
                    {
                        islem.Rollback(); // Hata varsa geri al
                        MessageBox.Show("Güncelleme Hatası: " + ex.Message);
                        return false;
                    }
                }
            }
        }

    }
}