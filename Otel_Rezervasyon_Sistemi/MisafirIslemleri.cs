using Npgsql;
using System.Data;

namespace Otel_Rezervasyon_Sistemi
{
    public class MisafirIslemleri
    {
        // 1. YARDIMCI METOT: İlçe Adından ID Bulma
        public int IlceIdGetir(string ilceAdi)
        {
            int id = -1;
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {
                string sql = "SELECT \"ilceNo\" FROM \"Ilce\" WHERE \"ilceAdi\" = @ad LIMIT 1";
                using (var cmd = new NpgsqlCommand(sql, baglanti))
                {
                    cmd.Parameters.AddWithValue("@ad", ilceAdi);
                    object sonuc = cmd.ExecuteScalar();
                    if (sonuc != null) id = Convert.ToInt32(sonuc);
                }
            }
            return id;
        }

        // 2. YARDIMCI METOT: Müşteri TCKN'den Müşteri ID Bulma (Misafiri bağlamak için)
        public int MusteriIdGetir(string tckn)
        {
            int id = -1;
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {
                // Kişi tablosundan ID'yi bul, ama bu kişinin Müşteri tablosunda da kaydı var mı kontrol et
                string sql = @"SELECT m.""musteriID"" 
                               FROM ""Musteri"" m 
                               JOIN ""Kisi"" k ON m.""musteriID"" = k.""kisiID"" 
                               WHERE k.""kimlikNo"" = @tc";

                using (var cmd = new NpgsqlCommand(sql, baglanti))
                {
                    cmd.Parameters.AddWithValue("@tc", tckn);
                    object sonuc = cmd.ExecuteScalar();
                    if (sonuc != null) id = Convert.ToInt32(sonuc);
                }
            }
            return id;
        }

        // 3. EKLEME (Transaction ile: Kisi -> Misafir -> Iletisim)
        public bool MisafirEkle(string tckn, string ad, string soyad, string cinsiyet, string tel, string email, string adres, int ilceNo, int musteriID)
        {
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {
                using (var islem = baglanti.BeginTransaction())
                {
                    try
                    {
                        // A) Kişi Ekle
                        string kisiSql = "INSERT INTO \"Kisi\" (\"kimlikNo\", \"kisiAdi\", \"kisiSoyadi\", \"cinsiyet\", \"kisiTuru\") " +
                                         "VALUES (@tckn, @ad, @soyad, @cinsiyet, 'Misafir') RETURNING \"kisiID\";";

                        int yeniMisafirID;
                        using (var cmd = new NpgsqlCommand(kisiSql, baglanti))
                        {
                            cmd.Parameters.AddWithValue("@tckn", tckn);
                            cmd.Parameters.AddWithValue("@ad", ad);
                            cmd.Parameters.AddWithValue("@soyad", soyad);
                            cmd.Parameters.AddWithValue("@cinsiyet", cinsiyet);
                            yeniMisafirID = (int)cmd.ExecuteScalar();
                        }

                        // B) Misafir Ekle (Müşteri ID ile bağla)
                        string misafirSql = "INSERT INTO \"Misafir\" (\"misafirID\", \"musteriID\") VALUES (@id, @mID);";
                        using (var cmd = new NpgsqlCommand(misafirSql, baglanti))
                        {
                            cmd.Parameters.AddWithValue("@id", yeniMisafirID);
                            cmd.Parameters.AddWithValue("@mID", musteriID); // Bağlı olduğu müşteri
                            cmd.ExecuteNonQuery();
                        }

                        // C) İletişim Ekle
                        string iletisimSql = "INSERT INTO \"IletisimBilgisi\" (\"telNo\", \"eMail\", \"adres\", \"ilceNo\", \"kisiID\") " +
                                             "VALUES (@tel, @mail, @adres, @ilce, @kisiID);";
                        using (var cmd = new NpgsqlCommand(iletisimSql, baglanti))
                        {
                            cmd.Parameters.AddWithValue("@tel", tel);
                            cmd.Parameters.AddWithValue("@mail", email);
                            cmd.Parameters.AddWithValue("@adres", adres);
                            cmd.Parameters.AddWithValue("@ilce", ilceNo);
                            cmd.Parameters.AddWithValue("@kisiID", yeniMisafirID);
                            cmd.ExecuteNonQuery();
                        }

                        islem.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        islem.Rollback();
                        MessageBox.Show("Hata: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        // 4. LİSTELEME
        public DataTable MisafirleriListele()
        {
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {
                // Misafir bilgileri + Bağlı olduğu Müşterinin Adı Soyadı
                string sql = @"
                    SELECT 
                        ms.""misafirID"" AS ""No"",
                        k.""kimlikNo"" AS ""TC Kimlik"",
                        k.""kisiAdi"" AS ""Ad"",
                        k.""kisiSoyadi"" AS ""Soyad"",
                        i.""telNo"" AS ""Telefon"",
                        concat(mk.""kisiAdi"", ' ', mk.""kisiSoyadi"") AS ""Bağlı Müşteri"" 
                    FROM ""Misafir"" ms
                    JOIN ""Kisi"" k ON ms.""misafirID"" = k.""kisiID""
                    LEFT JOIN ""IletisimBilgisi"" i ON k.""kisiID"" = i.""kisiID""
                    JOIN ""Kisi"" mk ON ms.""musteriID"" = mk.""kisiID"" -- Müşteri ismini çekmek için join
                    ORDER BY ms.""misafirID"" DESC";

                using (var cmd = new NpgsqlCommand(sql, baglanti))
                {
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // 5. SİLME
        public bool MisafirSil(string tckn)
        {
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {
                string sql = "DELETE FROM \"Kisi\" WHERE \"kimlikNo\" = @tc AND \"kisiTuru\" = 'Misafir'";
                using (var cmd = new NpgsqlCommand(sql, baglanti))
                {
                    cmd.Parameters.AddWithValue("@tc", tckn);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        // 6. ARAMA
        public DataTable MisafirAra(string ad)
        {
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {   
                string sql = @"
                    SELECT 
                        ms.""misafirID"" AS ""No"",
                        k.""kimlikNo"" AS ""TC Kimlik"",
                        k.""kisiAdi"" AS ""Ad"",
                        k.""kisiSoyadi"" AS ""Soyad"",
                        i.""telNo"" AS ""Telefon"",
                        concat(mk.""kisiAdi"", ' ', mk.""kisiSoyadi"") AS ""Bağlı Müşteri""
                    FROM ""Misafir"" ms
                    JOIN ""Kisi"" k ON ms.""misafirID"" = k.""kisiID""
                    LEFT JOIN ""IletisimBilgisi"" i ON k.""kisiID"" = i.""kisiID""
                    JOIN ""Kisi"" mk ON ms.""musteriID"" = mk.""kisiID""
                    WHERE k.""kisiAdi"" ILIKE @ad
                    ORDER BY k.""kisiAdi"" ASC";

                using (var cmd = new NpgsqlCommand(sql, baglanti))
                {
                    cmd.Parameters.AddWithValue("@ad", ad + "%"); // Başlangıç eşleşmesi için
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd); // Veri adaptörü
                    DataTable dt = new DataTable(); // Sonuçları tutacak tablo
                    da.Fill(dt); // Verileri tabloya doldur
                    return dt;
                }
            }
        }

        // 7. GÜNCELLEME İÇİN VERİ GETİR
        public DataTable MisafirBilgileriniGetir(string tckn)
        {
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {
                // Müşteri TCKN'sini de getirmemiz lazım ki güncelleme ekranında görünsün
                string sql = @"
                    SELECT 
                        ms.""misafirID"",
                        k.""kimlikNo"", k.""kisiAdi"", k.""kisiSoyadi"", k.""cinsiyet"",
                        i.""telNo"", i.""eMail"", i.""adres"", il.""ilceAdi"",
                        mk.""kimlikNo"" AS ""musteriKimlikNo""
                    FROM ""Misafir"" ms
                    JOIN ""Kisi"" k ON ms.""misafirID"" = k.""kisiID""
                    LEFT JOIN ""IletisimBilgisi"" i ON k.""kisiID"" = i.""kisiID""
                    LEFT JOIN ""Ilce"" il ON i.""ilceNo"" = il.""ilceNo""
                    JOIN ""Kisi"" mk ON ms.""musteriID"" = mk.""kisiID""
                    WHERE k.""kimlikNo"" = @tc";

                using (var cmd = new NpgsqlCommand(sql, baglanti))
                {
                    cmd.Parameters.AddWithValue("@tc", tckn);
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // 8. GÜNCELLEME
        public bool MisafirGuncelle(int id, string tckn, string ad, string soyad, string cinsiyet, string tel, string email, string adres, int ilceNo, int musteriID)
        {
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {
                using (var islem = baglanti.BeginTransaction()) // Transaction başlat
                {
                    try
                    {
                        // Kisi tablosu
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

                        // Misafir tablosu (Bağlı olduğu müşteri değişmiş olabilir)
                        string misafirSql = "UPDATE \"Misafir\" SET \"musteriID\"=@mid WHERE \"misafirID\"=@id";
                        using (var cmd = new NpgsqlCommand(misafirSql, baglanti))
                        {
                            cmd.Parameters.AddWithValue("@mid", musteriID);
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }

                        // İletişim tablosu
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

                        islem.Commit(); // Değişiklikleri onayla
                        return true;
                    }
                    catch (Exception ex)
                    {
                        islem.Rollback(); // Hata durumunda geri al
                        MessageBox.Show("Güncelleme Hatası: " + ex.Message);
                        return false;
                    }
                }
            }
        }
    }
}