using Npgsql;
using System.Data;

namespace Otel_Rezervasyon_Sistemi
{
    public class VeritabaniBaglantisi
    {
        private static string baglantiAdresi = "Host=localhost;Port=5432;Username=postgres;Password=0913;Database=OtelRezervasyonSistemi";

        public static NpgsqlConnection BaglantiGetir()
        {
            NpgsqlConnection baglanti = new NpgsqlConnection(baglantiAdresi);

            // Bağlantı kapalıysa aç, açıksa dokunma
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            return baglanti;
        }
    }
}