using System.Data;

namespace Otel_Rezervasyon_Sistemi
{
    public partial class PersonelIslemleriForm : Form
    {
        public PersonelIslemleriForm()
        {
            InitializeComponent();
        }

        PersonelIslemleri islemler = new PersonelIslemleri();
        int guncellenecekPersonelID = 0;
        private void PersonelIslemleriForm_Load(object sender, EventArgs e)
        {
            cinsiyetComboBox.SelectedIndex = 0;
            personelTurComboBox.SelectedIndex = 0;
            ilceComboBox.SelectedIndex = 0;
            ListeyiYenile();
        }
        private void ListeyiYenile()
        {
            personellerDataGridView.DataSource = islemler.PersonelleriListele();
            personellerDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Sütunların genişliğini otomatik ayarla
        }
        private void Temizle()
        {
            kimlikNoTextBox.Clear();
            adTextBox.Clear();
            soyadTextBox.Clear();
            sifreTextBox.Clear();
            telefonNoTextBox.Clear();
            ePostaTextBox.Clear();
            adresTextBox.Clear();
            sicilNoTextBox.Clear();
            ilceComboBox.SelectedIndex = -1;
            personelTurComboBox.SelectedIndex = -1;
            guncellenecekPersonelID = 0;
        }
        private void personelEkleButton_Click(object sender, EventArgs e)
        {
            // EKSİKSİZ KONTROL: Tüm kutucuklar dolu olmalı
            if (string.IsNullOrWhiteSpace(kimlikNoTextBox.Text) ||
                string.IsNullOrWhiteSpace(adTextBox.Text) ||
                string.IsNullOrWhiteSpace(soyadTextBox.Text) ||
                string.IsNullOrWhiteSpace(cinsiyetComboBox.Text) ||
                string.IsNullOrWhiteSpace(personelTurComboBox.Text) ||
                string.IsNullOrWhiteSpace(sifreTextBox.Text) ||
                string.IsNullOrWhiteSpace(telefonNoTextBox.Text) ||
                string.IsNullOrWhiteSpace(ePostaTextBox.Text) ||
                string.IsNullOrWhiteSpace(adresTextBox.Text) ||
                string.IsNullOrWhiteSpace(ilceComboBox.Text))
            {
                MessageBox.Show("Lütfen tüm alanları eksiksiz doldurunuz!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int ilceNo = islemler.IlceIdGetir(ilceComboBox.Text);
            if (ilceNo == -1)
            {
                MessageBox.Show("Geçerli bir ilçe seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string secilenTurAdi = personelTurComboBox.Text;
            int turID = islemler.PersonelTurIdGetir(secilenTurAdi);

            if (turID == -1)
            {
                MessageBox.Show("Seçilen personel türü veritabanında bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string cinsiyet = cinsiyetComboBox.Text == "Erkek" ? "E" : "K";

            bool sonuc = islemler.PersonelEkle(
                kimlikNoTextBox.Text,
                adTextBox.Text,
                soyadTextBox.Text,
                cinsiyet,
                turID,
                sifreTextBox.Text,
                telefonNoTextBox.Text,
                ePostaTextBox.Text,
                adresTextBox.Text,
                ilceNo
            );

            if (sonuc)
            {
                MessageBox.Show("Personel başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListeyiYenile();
                Temizle();
            }
        }
        private void personelSilButton_Click(object sender, EventArgs e)
        {
            string sicil = sicilNoTextBox.Text;
            if (string.IsNullOrWhiteSpace(sicil))
            {
                MessageBox.Show("Silinecek personelin Sicil Numarasını giriniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show(sicil + " sicil numaralı personeli silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (islemler.PersonelSil(sicil))
                {
                    MessageBox.Show("Personel silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListeyiYenile();
                    Temizle();
                }
                else
                {
                    MessageBox.Show("Personel bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void personelGuncelleButton_Click(object sender, EventArgs e)
        {
            string sicil = sicilNoTextBox.Text;
            if (string.IsNullOrWhiteSpace(sicil)) { MessageBox.Show("Sicil No giriniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            DataTable dt = islemler.PersonelBilgileriniGetir(sicil);

            if (dt.Rows.Count > 0) // Kayıt bulundu
            {
                DataRow row = dt.Rows[0];
                guncellenecekPersonelID = Convert.ToInt32(row["personelID"]);

                kimlikNoTextBox.Text = row["kimlikNo"].ToString();
                adTextBox.Text = row["kisiAdi"].ToString();
                soyadTextBox.Text = row["kisiSoyadi"].ToString();
                sifreTextBox.Text = row["sifre"].ToString();
                telefonNoTextBox.Text = row["telNo"].ToString();
                ePostaTextBox.Text = row["eMail"].ToString();
                adresTextBox.Text = row["adres"].ToString();
                ilceComboBox.Text = row["ilceAdi"].ToString();

                personelTurComboBox.Text = row["personelTurAdi"].ToString();

                string c = row["cinsiyet"].ToString();
                cinsiyetComboBox.Text = (c == "E") ? "Erkek" : "Kadın";

                MessageBox.Show("Personel bilgileri yüklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Personel bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void kaydetButton_Click(object sender, EventArgs e)
        {
            if (guncellenecekPersonelID == 0) { MessageBox.Show("Önce personel seçiniz."); return; }

            // GÜNCELLEME İÇİN DE TAM KONTROL
            if (string.IsNullOrWhiteSpace(kimlikNoTextBox.Text) ||
                string.IsNullOrWhiteSpace(adTextBox.Text) ||
                string.IsNullOrWhiteSpace(soyadTextBox.Text) ||
                string.IsNullOrWhiteSpace(personelTurComboBox.Text) ||
                string.IsNullOrWhiteSpace(sifreTextBox.Text) ||
                string.IsNullOrWhiteSpace(telefonNoTextBox.Text) ||
                string.IsNullOrWhiteSpace(ePostaTextBox.Text) ||
                string.IsNullOrWhiteSpace(adresTextBox.Text) ||
                string.IsNullOrWhiteSpace(ilceComboBox.Text))
            {
                MessageBox.Show("Güncelleme yaparken hiçbir alanı boş bırakamazsınız.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int ilceNo = islemler.IlceIdGetir(ilceComboBox.Text);
            string cinsiyet = cinsiyetComboBox.Text == "Erkek" ? "E" : "K";

            int turID = islemler.PersonelTurIdGetir(personelTurComboBox.Text);
            if (turID == -1) { MessageBox.Show("Personel türü geçersiz."); return; }

            bool sonuc = islemler.PersonelGuncelle(
                guncellenecekPersonelID,
                kimlikNoTextBox.Text,
                adTextBox.Text,
                soyadTextBox.Text,
                cinsiyet,
                turID,
                sifreTextBox.Text,
                telefonNoTextBox.Text,
                ePostaTextBox.Text,
                adresTextBox.Text,
                ilceNo
            );

            if (sonuc)
            {
                MessageBox.Show("Güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListeyiYenile();
                Temizle();
            }
        }
        private void personelleriAraButton_Click(object sender, EventArgs e)
        {
            string ad = adAraTextBox.Text.Trim();
            if (string.IsNullOrEmpty(ad)) // Boşsa tüm personelleri listele
                ListeyiYenile();
            else
                personellerDataGridView.DataSource = islemler.PersonelAra(ad); // İsimle arama
        }
    }
}