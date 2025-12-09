using Npgsql;
using NpgsqlTypes; // NpgsqlDbType için gerekli  

namespace Otel_Rezervasyon_Sistemi
{
    public class GunSonuIslemleri
    {
        // GÜNLÜK CİRO (SAKLI YORDAM-3)
        public float GunlukCiroGetir(DateTime tarih)
        {
            float ciro = 0;
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {
                using (var cmd = new NpgsqlCommand("CALL \"sp_GunlukCiro\"(@tarih, 0)", baglanti))
                {   
                    // Parametre tipini "Date" olarak zorluyoruz
                    cmd.Parameters.Add(new NpgsqlParameter("@tarih", NpgsqlDbType.Date) { Value = tarih }); 

                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read() && dr[0] != DBNull.Value) // Null kontrolü
                        {
                            ciro = Convert.ToSingle(dr[0]); // Float dönüşümü
                        }
                    }
                }
            }
            return ciro;
        }

        // GÜNLÜK YENİ REZERVASYON SAYISI (SAKLI YORDAM-4)
        public int GunlukYeniRezervasyonSayisiGetir(DateTime tarih)
        {
            int sayi = 0;
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {
                using (var cmd = new NpgsqlCommand("CALL \"sp_GunlukYeniRezervasyonSayisi\"(@tarih, 0)", baglanti))
                {
                    // Parametre tipini "Date" olarak zorluyoruz
                    cmd.Parameters.Add(new NpgsqlParameter("@tarih", NpgsqlDbType.Date) { Value = tarih });

                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read() && dr[0] != DBNull.Value) // Null kontrolü
                        {
                            sayi = Convert.ToInt32(dr[0]); // Int dönüşümü
                        }
                    }
                }
            }
            return sayi;
        }

        // GÜNLÜK TOPLAM KONAKLAYAN SAYISI (SAKLI YORDAM-5)
        public int GunlukToplamMisafirSayisiGetir(DateTime tarih)
        {
            int sayi = 0;
            using (var baglanti = VeritabaniBaglantisi.BaglantiGetir())
            {
                using (var cmd = new NpgsqlCommand("CALL \"sp_GunlukToplamMisafir\"(@tarih, 0)", baglanti))
                {
                    // Parametre tipini "Date" olarak zorluyoruz
                    cmd.Parameters.Add(new NpgsqlParameter("@tarih", NpgsqlDbType.Date) { Value = tarih });

                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read() && dr[0] != DBNull.Value) // Null kontrolü
                        {
                            sayi = Convert.ToInt32(dr[0]); // Int dönüşümü
                        }
                    }
                }
            }
            return sayi;
        }
    }
}