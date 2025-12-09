using Npgsql;
using System.Data;

namespace Otel_Rezervasyon_Sistemi
{
    public class FiyatIslemleri
    {
        // 1. DataGridView'i doldurmak için Personel Türlerini Çekme Fonksiyonu
        public DataTable PersonelTurleriListele()
        {
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {
                // Listeleme işlemi SELECT olduğu için normal sorgu ile çekiyoruz
                string sql = "SELECT \"personelTurID\", \"personelTurAdi\", \"personelMaas\" FROM \"PersonelTur\" ORDER BY \"personelTurID\" ASC";

                using (var cmd = new NpgsqlCommand(sql, baglanti))
                {
                    DataTable dt = new DataTable();
                    new NpgsqlDataAdapter(cmd).Fill(dt);
                    return dt;
                }
            }
        }

        // 2. MAAŞ GÜNCELLEME (SAKLI YORDAM - 3 ÇAĞRISI)
        public bool PersonelMaasGuncelle(short turID, float yeniMaas)
        {
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {
                try
                {
                    // Prosedür ismi ve parametreler aynı olduğu için burası değişmez
                    using (var cmd = new NpgsqlCommand("CALL \"sp_PersonelMaasGuncelle\"(@id, @maas)", baglanti))
                    {
                        cmd.Parameters.AddWithValue("@id", turID);
                        cmd.Parameters.AddWithValue("@maas", yeniMaas);

                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Maaş güncellenirken hata oluştu: " + ex.Message);
                    return false;
                }
            }
        }

        // 3. Oda Türlerini Listeleme Fonksiyonu
        public DataTable OdaTurleriListele()
        {
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {
                string sql = "SELECT \"odaTurID\", \"odaTurAdi\", \"odaFiyati\", \"odaKapasite\", \"odaMetrekare\" FROM \"OdaTur\" ORDER BY \"odaTurID\" ASC";

                using (var cmd = new NpgsqlCommand(sql, baglanti))
                {
                    DataTable dt = new DataTable();
                    new NpgsqlDataAdapter(cmd).Fill(dt);
                    return dt;
                }
            }
        }

        // 4. ODA FİYATI GÜNCELLEME (SAKLI YORDAM - 4 ÇAĞRISI)
        public bool OdaFiyatGuncelle(short odaTurID, float yeniFiyat)
        {
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {
                try
                {
                    // Hocanın kuralına uygun: CALL komutu ile prosedür çağrısı
                    using (var cmd = new NpgsqlCommand("CALL \"sp_OdaFiyatGuncelle\"(@id, @fiyat)", baglanti))
                    {
                        cmd.Parameters.AddWithValue("@id", odaTurID);
                        cmd.Parameters.AddWithValue("@fiyat", yeniFiyat);

                        cmd.ExecuteNonQuery(); // İşlemi yap
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Oda fiyatı güncellenirken hata oluştu: " + ex.Message);
                    return false;
                }
            }
        }
    }
}