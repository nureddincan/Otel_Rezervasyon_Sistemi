using Npgsql;

namespace Otel_Rezervasyon_Sistemi
{
    public class GirisIslemleri
    {
        // GİRİŞ KONTROLÜ
        // Geriye personelin türünü (Müdür, Resepsiyonist) döndürür.
        // Hatalıysa boş string "" döner.
        public string GirisYap(string email, string sifre)
        {
            string rol = "";
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {
                // E-Posta ve Şifreye göre personelin tür adını çekiyoruz
                string sql = @"
                    SELECT pt.""personelTurAdi""
                    FROM ""Personel"" p
                    JOIN ""PersonelTur"" pt ON p.""personelTurID"" = pt.""personelTurID""
                    JOIN ""Kisi"" k ON p.""personelID"" = k.""kisiID""
                    JOIN ""IletisimBilgisi"" i ON k.""kisiID"" = i.""kisiID""
                    WHERE i.""eMail"" = @mail AND p.""sifre"" = @pass";

                using (var cmd = new NpgsqlCommand(sql, baglanti))
                {
                    cmd.Parameters.AddWithValue("@mail", email); // SQL enjeksiyonuna karşı parametre kullanımı
                    cmd.Parameters.AddWithValue("@pass", sifre); // SQL enjeksiyonuna karşı parametre kullanımı

                    object sonuc = cmd.ExecuteScalar(); // Tek bir değer döndüren sorgular için ExecuteScalar kullanılır
                    if (sonuc != null)
                    {
                        rol = sonuc.ToString(); // Personel tür adını alıyoruz
                    }
                }
            }
            return rol;
        }
    }
}