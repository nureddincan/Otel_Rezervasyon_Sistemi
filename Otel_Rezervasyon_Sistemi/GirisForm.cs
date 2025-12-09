namespace Otel_Rezervasyon_Sistemi
{
    public partial class GirisForm : Form
    {
        public GirisForm()
        {
            InitializeComponent();
        }
        private void girisButton_Click(object sender, EventArgs e)
        {
            string email = eMailTextBox.Text.Trim();
            string sifre = sifreTextBox.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(sifre))
            {
                MessageBox.Show("Lütfen E-Posta ve Þifre alanlarýný doldurunuz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            GirisIslemleri islemler = new GirisIslemleri();
            string rol = islemler.GirisYap(email, sifre);

            if (!string.IsNullOrEmpty(rol))
            {
                MessageBox.Show("Giriþ Baþarýlý! Hoþgeldiniz, " + rol, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide(); // Giriþ ekranýný gizle
                eMailTextBox.Clear();
                sifreTextBox.Clear();

                if (rol == "Müdür")
                {
                    // Personel Yönetim Ekranýný Aç
                    PersonelYonetimForm personelForm = new PersonelYonetimForm();
                    personelForm.ShowDialog();
                }
                else if (rol == "Resepsiyonist")
                {
                    // Rezervasyon Yönetim Ekranýný Aç
                    RezervasyonYonetimForm rezervasyonForm = new RezervasyonYonetimForm();
                    rezervasyonForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Bu personel türünün sisteme giriþ yetkisi tanýmlanmamýþ.", "Yetki Hatasý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Show(); // Geri aç
                }
                this.Show();
            }
            else
            {
                MessageBox.Show("Hatalý E-Posta veya Þifre!", "Giriþ Baþarýsýz", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}