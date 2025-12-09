using Npgsql;
using System.Data;

namespace Otel_Rezervasyon_Sistemi
{
    public class PersonelYakiniIslemleri
    {
        // 1. İLÇE ID BUL
        public int IlceIdGetir(string ilceAdi)
        {   // İlçe adından ilceNo'yu al
            int id = -1;
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {   // İlçe adına göre ilceNo'yu al
                string sql = "SELECT \"ilceNo\" FROM \"Ilce\" WHERE \"ilceAdi\" = @ad LIMIT 1";
                using (var cmd = new NpgsqlCommand(sql, baglanti))
                {
                    cmd.Parameters.AddWithValue("@ad", ilceAdi); // İlçe adı parametresi
                    object sonuc = cmd.ExecuteScalar(); // Sadece bir değer döner
                    if (sonuc != null) id = Convert.ToInt32(sonuc); // ilceNo'yu al
                }
            }
            return id;
        }

        // 2. PERSONEL ID BUL (TCKN İLE)
        public int PersonelIdGetir(string tckn)
        {
            int id = -1; // Varsayılan olarak -1 (bulunamadı)
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {   // TCKN'ye göre personelID'yi al
                string sql = @"
                    SELECT p.""personelID"" 
                    FROM ""Personel"" p
                    JOIN ""Kisi"" k ON p.""personelID"" = k.""kisiID""
                    WHERE k.""kimlikNo"" = @tc";

                using (var cmd = new NpgsqlCommand(sql, baglanti))
                {
                    cmd.Parameters.AddWithValue("@tc", tckn); // TCKN parametresi
                    object sonuc = cmd.ExecuteScalar(); // Sadece bir değer döner
                    if (sonuc != null) id = Convert.ToInt32(sonuc); // personelID'yi al
                }
            }
            return id;
        }

        // 3. PERSONEL YAKINI EKLE
        public bool PersonelYakiniEkle(string tckn, string ad, string soyad, string cinsiyet, string tel, string email, string adres, int ilceNo, int personelID)
        {
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {
                using (var islem = baglanti.BeginTransaction()) // İşlem başlat
                {
                    try
                    {
                        // Kişi Ekle
                        string kisiSql = "INSERT INTO \"Kisi\" (\"kimlikNo\", \"kisiAdi\", \"kisiSoyadi\", \"cinsiyet\", \"kisiTuru\") " +
                                         "VALUES (@tckn, @ad, @soyad, @cinsiyet, 'PersonelYakini') RETURNING \"kisiID\";";

                        int yeniID;
                        using (var cmd = new NpgsqlCommand(kisiSql, baglanti))
                        {
                            cmd.Parameters.AddWithValue("@tckn", tckn);
                            cmd.Parameters.AddWithValue("@ad", ad);
                            cmd.Parameters.AddWithValue("@soyad", soyad);
                            cmd.Parameters.AddWithValue("@cinsiyet", cinsiyet);
                            yeniID = (int)cmd.ExecuteScalar();
                        }

                        // Personel Yakını Ekle
                        string yakinSql = "INSERT INTO \"PersonelYakini\" (\"personelYakinID\", \"personelID\") VALUES (@yid, @pid);";
                        using (var cmd = new NpgsqlCommand(yakinSql, baglanti))
                        {
                            cmd.Parameters.AddWithValue("@yid", yeniID);
                            cmd.Parameters.AddWithValue("@pid", personelID);
                            cmd.ExecuteNonQuery();
                        }

                        // İletişim Ekle
                        string iletisimSql = "INSERT INTO \"IletisimBilgisi\" (\"telNo\", \"eMail\", \"adres\", \"ilceNo\", \"kisiID\") " +
                                             "VALUES (@tel, @mail, @adres, @ilce, @kisiID);";
                        using (var cmd = new NpgsqlCommand(iletisimSql, baglanti))
                        {
                            cmd.Parameters.AddWithValue("@tel", tel);
                            cmd.Parameters.AddWithValue("@mail", email);
                            cmd.Parameters.AddWithValue("@adres", adres);
                            cmd.Parameters.AddWithValue("@ilce", ilceNo);
                            cmd.Parameters.AddWithValue("@kisiID", yeniID);
                            cmd.ExecuteNonQuery();
                        }

                        islem.Commit(); // İşlemi onayla
                        return true;
                    }
                    catch (Exception ex)
                    {
                        islem.Rollback(); // Hata durumunda işlemi geri al
                        MessageBox.Show("Ekleme Hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }

        // 4. LİSTELEME
        public DataTable PersonelYakinlariniListele()
        {
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {   // Tüm personel yakınlarını listele
                string sql = @"
                    SELECT 
                        k.""kimlikNo"" AS ""TC Kimlik"",
                        k.""kisiAdi"" || ' ' || k.""kisiSoyadi"" AS ""Ad Soyad"",
                        i.""telNo"" AS ""Telefon"",
                        kp.""kisiAdi"" || ' ' || kp.""kisiSoyadi"" AS ""Yakını Olduğu Personel"",
                        p.""sicilNo"" AS ""Personel Sicil""
                    FROM ""PersonelYakini"" py
                    JOIN ""Kisi"" k ON py.""personelYakinID"" = k.""kisiID""
                    JOIN ""Personel"" p ON py.""personelID"" = p.""personelID""
                    JOIN ""Kisi"" kp ON p.""personelID"" = kp.""kisiID""
                    LEFT JOIN ""IletisimBilgisi"" i ON k.""kisiID"" = i.""kisiID""
                    ORDER BY py.""personelYakinID"" DESC";

                using (var cmd = new NpgsqlCommand(sql, baglanti))
                {
                    DataTable dt = new DataTable(); // Sonuçları tutacak DataTable
                    new NpgsqlDataAdapter(cmd).Fill(dt); // Verileri doldur
                    return dt;
                }
            }
        }

        // 5. SİLME (TCKN İLE)
        public bool PersonelYakiniSil(string tckn)
        {
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {
                // TCKN'ye göre Kişi tablosundan siler. CASCADE sayesinde diğer tablolardan da silinir.
                // Güvenlik için 'kisiTuru' kontrolü de ekliyoruz ki yanlışlıkla Personel silinmesin.
                string sql = "DELETE FROM \"Kisi\" WHERE \"kimlikNo\" = @tc AND \"kisiTuru\" = 'PersonelYakini'";

                using (var cmd = new NpgsqlCommand(sql, baglanti))
                {
                    cmd.Parameters.AddWithValue("@tc", tckn); // TCKN parametresi
                    return cmd.ExecuteNonQuery() > 0; // Silinen satır sayısı > 0 ise başarılı
                }
            }
        }

        // 6. BİLGİ GETİRME (TCKN İLE)
        public DataTable PersonelYakiniBilgileriniGetir(string tckn)
        {
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {   // TCKN'ye göre personel yakını bilgilerini getir
                string sql = @"
                    SELECT 
                        py.""personelYakinID"", py.""personelID"",
                        k.""kimlikNo"", k.""kisiAdi"", k.""kisiSoyadi"", k.""cinsiyet"",
                        i.""telNo"", i.""eMail"", i.""adres"",
                        il.""ilceAdi"",
                        kp.""kimlikNo"" AS ""personelTC""
                    FROM ""PersonelYakini"" py
                    JOIN ""Kisi"" k ON py.""personelYakinID"" = k.""kisiID""
                    JOIN ""Personel"" p ON py.""personelID"" = p.""personelID""
                    JOIN ""Kisi"" kp ON p.""personelID"" = kp.""kisiID""
                    LEFT JOIN ""IletisimBilgisi"" i ON k.""kisiID"" = i.""kisiID""
                    LEFT JOIN ""Ilce"" il ON i.""ilceNo"" = il.""ilceNo""
                    WHERE k.""kimlikNo"" = @tc";

                using (var cmd = new NpgsqlCommand(sql, baglanti))
                {
                    cmd.Parameters.AddWithValue("@tc", tckn); // TCKN parametresi
                    DataTable dt = new DataTable(); // Sonuçları tutacak DataTable
                    new NpgsqlDataAdapter(cmd).Fill(dt); // Verileri doldur
                    return dt;
                }
            }
        }

        // 7. GÜNCELLEME
        public bool PersonelYakiniGuncelle(int id, string tckn, string ad, string soyad, string cinsiyet, string tel, string email, string adres, int ilceNo, int personelID)
        {
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {
                using (var islem = baglanti.BeginTransaction()) // İşlem başlat
                {
                    try
                    {   // Kişi Güncelle
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
                        // Personel Yakını Güncelle
                        string yakinSql = "UPDATE \"PersonelYakini\" SET \"personelID\"=@pid WHERE \"personelYakinID\"=@id";
                        using (var cmd = new NpgsqlCommand(yakinSql, baglanti))
                        {
                            cmd.Parameters.AddWithValue("@pid", personelID);
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }
                        // İletişim Güncelle
                        string iletSql = "UPDATE \"IletisimBilgisi\" SET \"telNo\"=@tel, \"eMail\"=@mail, \"adres\"=@adres, \"ilceNo\"=@ilce WHERE \"kisiID\"=@id";
                        using (var cmd = new NpgsqlCommand(iletSql, baglanti))
                        {
                            cmd.Parameters.AddWithValue("@tel", tel);
                            cmd.Parameters.AddWithValue("@mail", email);
                            cmd.Parameters.AddWithValue("@adres", adres);
                            cmd.Parameters.AddWithValue("@ilce", ilceNo);
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }

                        islem.Commit(); // İşlemi onayla
                        return true;
                    }
                    catch (Exception ex)
                    {
                        islem.Rollback(); // Hata durumunda işlemi geri al
                        MessageBox.Show("Güncelleme Hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }

        // 8. ARAMA
        public DataTable PersonelYakiniAra(string ad)
        {
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {   // Ad'a göre personel yakınlarını ara
                string sql = @"
                    SELECT 
                        k.""kimlikNo"" AS ""TC Kimlik"",
                        k.""kisiAdi"" || ' ' || k.""kisiSoyadi"" AS ""Ad Soyad"",
                        i.""telNo"" AS ""Telefon"",
                        kp.""kisiAdi"" || ' ' || kp.""kisiSoyadi"" AS ""Yakını Olduğu Personel"",
                        p.""sicilNo"" AS ""Personel Sicil""
                    FROM ""PersonelYakini"" py
                    JOIN ""Kisi"" k ON py.""personelYakinID"" = k.""kisiID""
                    JOIN ""Personel"" p ON py.""personelID"" = p.""personelID""
                    JOIN ""Kisi"" kp ON p.""personelID"" = kp.""kisiID""
                    LEFT JOIN ""IletisimBilgisi"" i ON k.""kisiID"" = i.""kisiID""
                    WHERE k.""kisiAdi"" ILIKE @ad
                    ORDER BY py.""personelYakinID"" ASC";

                using (var cmd = new NpgsqlCommand(sql, baglanti))
                {
                    cmd.Parameters.AddWithValue("@ad", ad + "%"); // Ad parametresi
                    DataTable dt = new DataTable(); // Sonuçları tutacak DataTable
                    new NpgsqlDataAdapter(cmd).Fill(dt); // Verileri doldur
                    return dt;
                }
            }
        }
    }
}