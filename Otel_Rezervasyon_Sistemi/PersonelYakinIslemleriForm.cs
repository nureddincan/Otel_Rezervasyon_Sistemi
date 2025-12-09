using System.Data;

namespace Otel_Rezervasyon_Sistemi
{
    public partial class PersonelYakinIslemleriForm : Form
    {
        public PersonelYakinIslemleriForm()
        {
            InitializeComponent();
        }

        PersonelYakiniIslemleri islemler = new PersonelYakiniIslemleri();
        int guncellenecekYakinID = 0; // ID'yi hala arka planda saklıyoruz

        private void PersonelYakinIslemleriForm_Load(object sender, EventArgs e)
        {
            cinsiyetComboBox.SelectedIndex = 0;
            ilceComboBox.SelectedIndex = 0;
            ListeyiYenile();
        }

        private void ListeyiYenile()
        {
            personelYakinlariDataGridView.DataSource = islemler.PersonelYakinlariniListele();
            personelYakinlariDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void Temizle()
        {
            kimlikNoTextBox.Clear();
            adTextBox.Clear();
            soyadTextBox.Clear();
            telefonNoTextBox.Clear();
            ePostaTextBox.Clear();
            adresTextBox.Clear();
            yakinTCTextBox.Clear();
            personelTCTextBox.Clear();
            ilceComboBox.SelectedIndex = -1;
            cinsiyetComboBox.SelectedIndex = 0;
            guncellenecekYakinID = 0;
        }

        // 2. EKLE BUTONU (TÜM ALANLAR KONTROL EDİLİYOR)
        private void personelYakiniEkleButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(kimlikNoTextBox.Text) ||
                string.IsNullOrWhiteSpace(adTextBox.Text) ||
                string.IsNullOrWhiteSpace(soyadTextBox.Text) ||
                string.IsNullOrWhiteSpace(cinsiyetComboBox.Text) ||
                string.IsNullOrWhiteSpace(telefonNoTextBox.Text) ||
                string.IsNullOrWhiteSpace(ePostaTextBox.Text) ||
                string.IsNullOrWhiteSpace(adresTextBox.Text) ||
                string.IsNullOrWhiteSpace(ilceComboBox.Text) ||
                string.IsNullOrWhiteSpace(personelTCTextBox.Text))
            {
                MessageBox.Show("Lütfen tüm alanları (Adres, Telefon, İlçe vb. dahil) eksiksiz doldurunuz!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int ilceNo = islemler.IlceIdGetir(ilceComboBox.Text);
            if (ilceNo == -1)
            {
                MessageBox.Show("Seçilen ilçe veritabanında bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Personel TC'den ID Bul
            int personelID = islemler.PersonelIdGetir(personelTCTextBox.Text);
            if (personelID == -1)
            {
                MessageBox.Show("Girilen TCKN'ye sahip bir personel bulunamadı!", "Hatalı Personel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string cinsiyet = cinsiyetComboBox.Text == "Erkek" ? "E" : "K";

            bool sonuc = islemler.PersonelYakiniEkle(
                kimlikNoTextBox.Text,
                adTextBox.Text,
                soyadTextBox.Text,
                cinsiyet,
                telefonNoTextBox.Text,
                ePostaTextBox.Text,
                adresTextBox.Text,
                ilceNo,
                personelID
            );

            if (sonuc)
            {
                MessageBox.Show("Personel yakını başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListeyiYenile();
                Temizle();
            }
        }

        // 3. SİL BUTONU (TC İLE)
        private void yakinSilButton_Click(object sender, EventArgs e)
        {
            string tc = yakinTCTextBox.Text; // ID yerine TC alıyoruz
            if (string.IsNullOrWhiteSpace(tc))
            {
                MessageBox.Show("Silinecek Yakının TC Kimlik Numarasını giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show(tc + " kimlik numaralı kaydı silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // TC ile silme metodunu çağırıyoruz
                if (islemler.PersonelYakiniSil(tc))
                {
                    MessageBox.Show("Kayıt başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListeyiYenile();
                    Temizle();
                }
                else
                {
                    MessageBox.Show("Bu TC numarasına sahip bir personel yakını bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 4. GÜNCELLEME İÇİN VERİ GETİR (TC İLE)
        private void yakinGuncelleButton_Click(object sender, EventArgs e)
        {
            string tc = yakinTCTextBox.Text;
            if (string.IsNullOrWhiteSpace(tc))
            {
                MessageBox.Show("Lütfen TC Kimlik No giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // TC ile bilgileri getir
            DataTable dt = islemler.PersonelYakiniBilgileriniGetir(tc);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                // ID'yi arka planda saklıyoruz (Güncelleme için gerekli)
                guncellenecekYakinID = Convert.ToInt32(row["personelYakinID"]);

                kimlikNoTextBox.Text = row["kimlikNo"].ToString();
                adTextBox.Text = row["kisiAdi"].ToString();
                soyadTextBox.Text = row["kisiSoyadi"].ToString();
                telefonNoTextBox.Text = row["telNo"].ToString();
                ePostaTextBox.Text = row["eMail"].ToString();
                adresTextBox.Text = row["adres"].ToString();
                ilceComboBox.Text = row["ilceAdi"].ToString();
                personelTCTextBox.Text = row["personelTC"].ToString();

                string c = row["cinsiyet"].ToString();
                cinsiyetComboBox.Text = (c == "E") ? "Erkek" : "Kadın";

                MessageBox.Show("Bilgiler yüklendi. Düzenleyip kaydedebilirsiniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kayıt bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 5. DEĞİŞİKLİKLERİ KAYDET BUTONU
        private void degisiklikleriKaydetButton_Click(object sender, EventArgs e)
        {
            if (guncellenecekYakinID == 0)
            {
                MessageBox.Show("Önce güncelleme için veri getirin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // EKSİKSİZ KONTROL
            if (string.IsNullOrWhiteSpace(kimlikNoTextBox.Text) ||
                string.IsNullOrWhiteSpace(adTextBox.Text) ||
                string.IsNullOrWhiteSpace(soyadTextBox.Text) ||
                string.IsNullOrWhiteSpace(cinsiyetComboBox.Text) ||
                string.IsNullOrWhiteSpace(telefonNoTextBox.Text) ||
                string.IsNullOrWhiteSpace(ePostaTextBox.Text) ||
                string.IsNullOrWhiteSpace(adresTextBox.Text) ||
                string.IsNullOrWhiteSpace(ilceComboBox.Text) ||
                string.IsNullOrWhiteSpace(personelTCTextBox.Text))
            {
                MessageBox.Show("Güncelleme işleminde hiçbir alanı boş bırakamazsınız!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int ilceNo = islemler.IlceIdGetir(ilceComboBox.Text);
            if (ilceNo == -1) { MessageBox.Show("İlçe geçersiz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            int personelID = islemler.PersonelIdGetir(personelTCTextBox.Text);
            if (personelID == -1)
            {
                MessageBox.Show("Personel bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string cinsiyet = cinsiyetComboBox.Text == "Erkek" ? "E" : "K";

            bool sonuc = islemler.PersonelYakiniGuncelle(
                guncellenecekYakinID, // Hafızadaki ID ile güncelleme yapılıyor
                kimlikNoTextBox.Text,
                adTextBox.Text,
                soyadTextBox.Text,
                cinsiyet,
                telefonNoTextBox.Text,
                ePostaTextBox.Text,
                adresTextBox.Text,
                ilceNo,
                personelID
            );

            if (sonuc)
            {
                MessageBox.Show("Güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListeyiYenile();
                Temizle();
            }
        }

        // 6. ARA BUTONU
        private void yakinAdAraButton_Click(object sender, EventArgs e)
        {
            string ad = yakinAdAraTextBox.Text.Trim();
            if (string.IsNullOrEmpty(ad))
                ListeyiYenile();
            else
                personelYakinlariDataGridView.DataSource = islemler.PersonelYakiniAra(ad);
        }

    }
}