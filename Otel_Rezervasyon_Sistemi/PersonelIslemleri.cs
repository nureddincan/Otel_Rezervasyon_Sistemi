using Npgsql;
using System.Data;

namespace Otel_Rezervasyon_Sistemi
{
    public class PersonelIslemleri
    {
        // 1. PERSONEL TÜR ID BUL
        public int PersonelTurIdGetir(string turAdi)
        {
            int id = -1;
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {
                string sql = "SELECT \"personelTurID\" FROM \"PersonelTur\" WHERE \"personelTurAdi\" = @ad LIMIT 1"; // SQL sorgusu
                using (var cmd = new NpgsqlCommand(sql, baglanti)) // Komut oluştur
                {
                    cmd.Parameters.AddWithValue("@ad", turAdi); // Parametre ekle
                    object sonuc = cmd.ExecuteScalar(); // Tek bir değer döner
                    if (sonuc != null) id = Convert.ToInt32(sonuc); // int'e dönüştür
                }
            }
            return id;
        }

        // 2. İLÇE ID BUL
        public int IlceIdGetir(string ilceAdi)
        {
            int id = -1;
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {
                string sql = "SELECT \"ilceNo\" FROM \"Ilce\" WHERE \"ilceAdi\" = @ad LIMIT 1"; // SQL sorgusu
                using (var cmd = new NpgsqlCommand(sql, baglanti)) // Komut oluştur
                {
                    cmd.Parameters.AddWithValue("@ad", ilceAdi); // Parametre ekle
                    object sonuc = cmd.ExecuteScalar(); // Tek bir değer döner
                    if (sonuc != null) id = Convert.ToInt32(sonuc); // int'e dönüştür
                }
            }
            return id;
        }

        // 3. PERSONEL EKLE
        public bool PersonelEkle(string tckn, string ad, string soyad, string cinsiyet, int turID, string sifre, string tel, string email, string adres, int ilceNo)
        {
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {
                using (var islem = baglanti.BeginTransaction()) // İşlem başlat
                {
                    try
                    {
                        // A) Kişi Ekle
                        string kisiSql = "INSERT INTO \"Kisi\" (\"kimlikNo\", \"kisiAdi\", \"kisiSoyadi\", \"cinsiyet\", \"kisiTuru\") " +
                                         "VALUES (@tckn, @ad, @soyad, @cinsiyet, 'Personel') RETURNING \"kisiID\";";

                        int yeniPersonelID;
                        using (var cmd = new NpgsqlCommand(kisiSql, baglanti))
                        {
                            cmd.Parameters.AddWithValue("@tckn", tckn);
                            cmd.Parameters.AddWithValue("@ad", ad);
                            cmd.Parameters.AddWithValue("@soyad", soyad);
                            cmd.Parameters.AddWithValue("@cinsiyet", cinsiyet);
                            yeniPersonelID = (int)cmd.ExecuteScalar(); // Yeni eklenen kişinin ID'si
                        }

                        // B) Sicil No Üret (Örn: S-12345)
                        string otomatikSicilNo = "S-" + tckn.Substring(Math.Max(0, tckn.Length - 5));

                        // C) Personel Ekle (Şifre direkt kaydediliyor)
                        string personelSql = "INSERT INTO \"Personel\" (\"personelID\", \"sicilNo\", \"personelTurID\", \"sifre\", \"mudur\") " +
                                             "VALUES (@id, @sicil, @tur, @sifre, NULL);";

                        using (var cmd = new NpgsqlCommand(personelSql, baglanti))
                        {
                            cmd.Parameters.AddWithValue("@id", yeniPersonelID);
                            cmd.Parameters.AddWithValue("@sicil", otomatikSicilNo);
                            cmd.Parameters.AddWithValue("@tur", (short)turID);
                            cmd.Parameters.AddWithValue("@sifre", sifre); // Herkesin şifresi var
                            cmd.ExecuteNonQuery();
                        }

                        // D) İletişim Ekle
                        string iletisimSql = "INSERT INTO \"IletisimBilgisi\" (\"telNo\", \"eMail\", \"adres\", \"ilceNo\", \"kisiID\") " +
                                             "VALUES (@tel, @mail, @adres, @ilce, @kisiID);";
                        using (var cmd = new NpgsqlCommand(iletisimSql, baglanti))
                        {
                            cmd.Parameters.AddWithValue("@tel", tel);
                            cmd.Parameters.AddWithValue("@mail", email);
                            cmd.Parameters.AddWithValue("@adres", adres);
                            cmd.Parameters.AddWithValue("@ilce", ilceNo);
                            cmd.Parameters.AddWithValue("@kisiID", yeniPersonelID);
                            cmd.ExecuteNonQuery();
                        }

                        islem.Commit(); // İşlemi onayla
                        return true;
                    }
                    catch (Exception ex)
                    {
                        islem.Rollback(); // Hata durumunda işlemi geri al
                        MessageBox.Show("Personel Ekleme Hatası: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        // 4. LİSTELEME
        public DataTable PersonelleriListele()
        {
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {
                string sql = @"
                    SELECT 
                        k.""kimlikNo"" AS ""TC Kimlik"",
                        p.""sicilNo"" AS ""Sicil No"",
                        k.""kisiAdi"" || ' ' || k.""kisiSoyadi"" AS ""Ad Soyad"",
                        k.""cinsiyet"" AS ""Cinsiyet"",
                        i.""telNo"" AS ""Telefon"",
                        pt.""personelTurAdi"" AS ""Pozisyon"",
                        pt.""personelMaas"" AS ""Maaş""
                    FROM ""Personel"" p
                    JOIN ""Kisi"" k ON p.""personelID"" = k.""kisiID""
                    JOIN ""PersonelTur"" pt ON p.""personelTurID"" = pt.""personelTurID""
                    LEFT JOIN ""IletisimBilgisi"" i ON k.""kisiID"" = i.""kisiID""
                    ORDER BY p.""sicilNo"" ASC";

                using (var cmd = new NpgsqlCommand(sql, baglanti))
                {
                    DataTable dt = new DataTable(); // Boş DataTable oluştur
                    new NpgsqlDataAdapter(cmd).Fill(dt); // Komutun sonucunu DataTable'a doldur
                    return dt;
                }
            }
        }

        // 5. SİLME
        public bool PersonelSil(string sicilNo)
        {
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {
                string idBulSql = "SELECT \"personelID\" FROM \"Personel\" WHERE \"sicilNo\" = @sicil"; // Silinecek personel ID'sini bul
                int silinecekID = 0;

                using (var cmd = new NpgsqlCommand(idBulSql, baglanti))
                {
                    cmd.Parameters.AddWithValue("@sicil", sicilNo);
                    object sonuc = cmd.ExecuteScalar(); // Tek bir değer döner
                    if (sonuc == null) return false; // Personel bulunamadı
                    silinecekID = (int)sonuc; // Silinecek personel ID'si
                }

                string silSql = "DELETE FROM \"Kisi\" WHERE \"kisiID\" = @id"; // Kişi tablosundan sil (ilişkili tüm veriler de silinir)
                using (var cmd = new NpgsqlCommand(silSql, baglanti))
                {
                    cmd.Parameters.AddWithValue("@id", silinecekID); // Silinecek personel ID'si
                    return cmd.ExecuteNonQuery() > 0; // "Kaç satır silindi?" bilgisini (sayı) döner.
                }
            }
        }

        // 6. BİLGİ GETİR
        public DataTable PersonelBilgileriniGetir(string sicilNo)
        {
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {   // Personel bilgilerini detaylı şekilde getir
                string sql = @"
                    SELECT 
                        p.""personelID"",
                        k.""kimlikNo"", k.""kisiAdi"", k.""kisiSoyadi"", k.""cinsiyet"",
                        p.""sifre"", p.""personelTurID"", pt.""personelTurAdi"",
                        i.""telNo"", i.""eMail"", i.""adres"",
                        il.""ilceAdi""
                    FROM ""Personel"" p
                    JOIN ""Kisi"" k ON p.""personelID"" = k.""kisiID""
                    JOIN ""PersonelTur"" pt ON p.""personelTurID"" = pt.""personelTurID""
                    LEFT JOIN ""IletisimBilgisi"" i ON k.""kisiID"" = i.""kisiID""
                    LEFT JOIN ""Ilce"" il ON i.""ilceNo"" = il.""ilceNo""
                    WHERE p.""sicilNo"" = @sicil";

                using (var cmd = new NpgsqlCommand(sql, baglanti))
                {
                    cmd.Parameters.AddWithValue("@sicil", sicilNo); // Parametre ekle
                    DataTable dt = new DataTable(); // Boş DataTable oluştur
                    new NpgsqlDataAdapter(cmd).Fill(dt); // Komutun sonucunu DataTable'a doldur
                    return dt;
                }
            }
        }

        // 7. GÜNCELLEME
        public bool PersonelGuncelle(int id, string tckn, string ad, string soyad, string cinsiyet, int turID, string sifre, string tel, string email, string adres, int ilceNo)
        {
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {
                using (var islem = baglanti.BeginTransaction()) // İşlem başlat
                {
                    try
                    {
                        // Kişi
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

                        // Personel (Şifre her zaman güncellenir)
                        string perSql = "UPDATE \"Personel\" SET \"personelTurID\"=@tur, \"sifre\"=@sifre WHERE \"personelID\"=@id";
                        using (var cmd = new NpgsqlCommand(perSql, baglanti))
                        {
                            cmd.Parameters.AddWithValue("@tur", (short)turID);
                            cmd.Parameters.AddWithValue("@sifre", sifre);
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }

                        // İletişim
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
                        MessageBox.Show("Güncelleme Hatası: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        // 8. ARAMA
        public DataTable PersonelAra(string ad)
        {
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir()) // Bağlantı aç
            {   // Ad'a göre personel ara
                string sql = @"
                    SELECT 
                        k.""kimlikNo"" AS ""TC Kimlik"",
                        p.""sicilNo"" AS ""Sicil No"",
                        k.""kisiAdi"" || ' ' || k.""kisiSoyadi"" AS ""Ad Soyad"",
                        k.""cinsiyet"" AS ""Cinsiyet"",
                        i.""telNo"" AS ""Telefon"",
                        pt.""personelTurAdi"" AS ""Pozisyon"",
                        pt.""personelMaas"" AS ""Maaş""
                    FROM ""Personel"" p
                    JOIN ""Kisi"" k ON p.""personelID"" = k.""kisiID""
                    JOIN ""PersonelTur"" pt ON p.""personelTurID"" = pt.""personelTurID""
                    LEFT JOIN ""IletisimBilgisi"" i ON k.""kisiID"" = i.""kisiID""
                    WHERE k.""kisiAdi"" ILIKE @ad
                    ORDER BY p.""sicilNo"" ASC";

                using (var cmd = new NpgsqlCommand(sql, baglanti))
                {
                    cmd.Parameters.AddWithValue("@ad", ad + "%"); // Parametre ekle
                    DataTable dt = new DataTable(); // Boş DataTable oluştur
                    new NpgsqlDataAdapter(cmd).Fill(dt); // Komutun sonucunu DataTable'a doldur
                    return dt;
                }
            }
        }
    }
}