namespace Otel_Rezervasyon_Sistemi
{
    public partial class PersonelYonetimForm : Form
    {
        public PersonelYonetimForm()
        {
            InitializeComponent();
        }
        private void personelIslemleriButton_Click(object sender, EventArgs e)
        {
            PersonelIslemleriForm personelIslemleriForm = new PersonelIslemleriForm();
            personelIslemleriForm.ShowDialog();
        }
        private void personelYakiniIslemleriButton_Click(object sender, EventArgs e)
        {
            PersonelYakinIslemleriForm personelYakinIslemleriForm = new PersonelYakinIslemleriForm();
            personelYakinIslemleriForm.ShowDialog();
        }
        private void gunSonuRaporuButton_Click(object sender, EventArgs e)
        {
            GunSonuIslemleri raporIslemleri = new GunSonuIslemleri();

            DateTime bugun = DateTime.Now.Date;

            try
            {
                float ciro = raporIslemleri.GunlukCiroGetir(bugun);
                int yeniRezervasyonSayisi = raporIslemleri.GunlukYeniRezervasyonSayisiGetir(bugun);
                int toplamMisafir = raporIslemleri.GunlukToplamMisafirSayisiGetir(bugun);

                string raporMetni = "=================================\n" +
                                    "       GÜN SONU RAPORU       \n" +
                                    "=================================\n\n" +
                                    $"TARİH: {bugun.ToShortDateString()}\n\n" +
                                    $"- Günlük Ciro            : {ciro.ToString("C2")}\n" +
                                    $"- Yeni Rezervasyon       : {yeniRezervasyonSayisi} Adet\n" +
                                    $"- Konaklayan Kişi Sayısı : {toplamMisafir} Kişi\n\n" +
                                    "=================================\n" +
                                    "Veriler veritabanından başarıyla çekildi.";

                MessageBox.Show(raporMetni, "Gün Sonu Özeti", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Rapor oluşturulurken hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fiyatGuncellemeButton_Click(object sender, EventArgs e)
        {
            FiyatGuncellemeForm fiyatGuncellemeForm = new FiyatGuncellemeForm();    
            fiyatGuncellemeForm.ShowDialog();
        }
    }
}