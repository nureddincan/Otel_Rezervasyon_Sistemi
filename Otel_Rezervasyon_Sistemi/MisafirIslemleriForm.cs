using System.Data;

namespace Otel_Rezervasyon_Sistemi
{
    public partial class MisafirIslemleriForm : Form
    {
        public MisafirIslemleriForm()
        {
            InitializeComponent();
        }

        int guncellenecekMisafirID = 0;
        private void MisafirIslemleriForm_Load(object sender, EventArgs e)
        {
            ListeyiYenile();
            cinsiyetComboBox.SelectedIndex = 0; // Erkek/Kadın varsayılan
            ilceComboBox.SelectedIndex = 0; // İlçe combobox varsayılan
        }
        private void ListeyiYenile()
        {
            MisafirIslemleri islemler = new MisafirIslemleri();
            misafirlerDataGridView.DataSource = islemler.MisafirleriListele(); // Misafirleri listele
            misafirlerDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Sütun genişliklerini otomatik ayarla
        }
        private void Temizle()
        {
            kimlikNoTextBox.Clear();
            adTextBox.Clear();
            soyadTextBox.Clear();
            telefonNoTextBox.Clear();
            ePostaTextBox.Clear();
            adresTextBox.Clear();
            musteriKimlikNoTextBox.Clear();
        }
        private void misafirEkleButton_Click(object sender, EventArgs e)
        {
            // 1. TÜM ALANLARI KONTROL ET (Eksiksiz)
            if (string.IsNullOrWhiteSpace(kimlikNoTextBox.Text) ||
                string.IsNullOrWhiteSpace(adTextBox.Text) ||
                string.IsNullOrWhiteSpace(soyadTextBox.Text) ||
                string.IsNullOrWhiteSpace(cinsiyetComboBox.Text) ||
                string.IsNullOrWhiteSpace(telefonNoTextBox.Text) ||
                string.IsNullOrWhiteSpace(ePostaTextBox.Text) ||
                string.IsNullOrWhiteSpace(adresTextBox.Text) ||
                string.IsNullOrWhiteSpace(ilceComboBox.Text) ||
                string.IsNullOrWhiteSpace(musteriKimlikNoTextBox.Text)) // Misafir için bu da zorunlu
            {
                MessageBox.Show("Lütfen tüm alanları eksiksiz doldurunuz!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MisafirIslemleri islemler = new MisafirIslemleri();

            // 2. İLÇE KONTROLÜ
            int ilceNo = islemler.IlceIdGetir(ilceComboBox.Text);
            if (ilceNo == -1)
            {
                MessageBox.Show("Seçilen ilçe veritabanında bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. BAĞLI MÜŞTERİ KONTROLÜ
            int musteriID = islemler.MusteriIdGetir(musteriKimlikNoTextBox.Text);
            if (musteriID == -1)
            {
                MessageBox.Show("Girilen TCKN'ye sahip kayıtlı bir MÜŞTERİ bulunamadı!\nMisafir eklemek için önce ana müşterinin kayıtlı olması gerekir.", "Müşteri Bulunamadı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. KAYIT İŞLEMİ
            string cinsiyet = cinsiyetComboBox.Text == "Erkek" ? "E" : "K";

            bool sonuc = islemler.MisafirEkle(
                kimlikNoTextBox.Text,
                adTextBox.Text,
                soyadTextBox.Text,
                cinsiyet,
                telefonNoTextBox.Text,
                ePostaTextBox.Text,
                adresTextBox.Text,
                ilceNo,
                musteriID
            );

            if (sonuc)
            {
                MessageBox.Show("Misafir başarıyla sisteme kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListeyiYenile();
                Temizle();
            }
        }
        private void misafirAraButton_Click(object sender, EventArgs e)
        {
            string aranan = adAraTextBox.Text.Trim(); 
            MisafirIslemleri islemler = new MisafirIslemleri();
            if (string.IsNullOrEmpty(aranan)) // Boşsa tüm misafirleri listele
                misafirlerDataGridView.DataSource = islemler.MisafirleriListele();
            else
                misafirlerDataGridView.DataSource = islemler.MisafirAra(aranan); // Arama yap
        }
        private void misafirSilButton_Click(object sender, EventArgs e)
        {
            string tc = misafirSilGuncelleKimlikNoTextBox.Text;

            if (string.IsNullOrWhiteSpace(tc))
            {
                MessageBox.Show("Lütfen silinecek misafirin Kimlik Numarasını giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult onay = MessageBox.Show(tc + " kimlik numaralı misafiri silmek istediğinize emin misiniz?",
                                                "Silme Onayı",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

            if (onay == DialogResult.Yes)
            {
                MisafirIslemleri islemler = new MisafirIslemleri();
                if (islemler.MisafirSil(tc))
                {
                    MessageBox.Show("Misafir başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ListeyiYenile();
                    misafirSilGuncelleKimlikNoTextBox.Clear();
                }
                else
                {
                    MessageBox.Show("Bu kimlik numarasına sahip bir misafir bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void misafirGuncelleButton_Click(object sender, EventArgs e)
        {
            string tc = misafirSilGuncelleKimlikNoTextBox.Text;
            MisafirIslemleri islemler = new MisafirIslemleri();
            DataTable dt = islemler.MisafirBilgileriniGetir(tc);

            if (dt.Rows.Count > 0) // Misafir bulundu
            {
                DataRow row = dt.Rows[0];
                guncellenecekMisafirID = Convert.ToInt32(row["misafirID"]);

                kimlikNoTextBox.Text = row["kimlikNo"].ToString();
                adTextBox.Text = row["kisiAdi"].ToString();
                soyadTextBox.Text = row["kisiSoyadi"].ToString();
                telefonNoTextBox.Text = row["telNo"].ToString();
                ePostaTextBox.Text = row["eMail"].ToString();
                adresTextBox.Text = row["adres"].ToString();
                ilceComboBox.Text = row["ilceAdi"].ToString();
                musteriKimlikNoTextBox.Text = row["musteriKimlikNo"].ToString(); // Bağlı olduğu müşteriyi de getir

                string c = row["cinsiyet"].ToString();
                cinsiyetComboBox.Text = (c == "E") ? "Erkek" : "Kadın";

                MessageBox.Show("Bilgiler yüklendi. Değişiklikleri yapıp kaydedebilirsiniz.");
            }
            else
            {
                MessageBox.Show("Misafir bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void degisiklikleriKaydetButton_Click(object sender, EventArgs e)
        {
            if (guncellenecekMisafirID == 0)
            {
                MessageBox.Show("Lütfen önce 'Güncelle' butonuna basarak bir misafir seçiniz.", "İşlem Sırası Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // GÜNCELLEME İÇİN DE TÜM ALANLARI KONTROL EDİYORUZ
            if (string.IsNullOrWhiteSpace(kimlikNoTextBox.Text) ||
                string.IsNullOrWhiteSpace(adTextBox.Text) ||
                string.IsNullOrWhiteSpace(soyadTextBox.Text) ||
                string.IsNullOrWhiteSpace(cinsiyetComboBox.Text) ||
                string.IsNullOrWhiteSpace(telefonNoTextBox.Text) ||
                string.IsNullOrWhiteSpace(ePostaTextBox.Text) ||
                string.IsNullOrWhiteSpace(adresTextBox.Text) ||
                string.IsNullOrWhiteSpace(ilceComboBox.Text) ||
                string.IsNullOrWhiteSpace(musteriKimlikNoTextBox.Text))
            {
                MessageBox.Show("Güncelleme işlemi için tüm alanlar dolu olmalıdır.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MisafirIslemleri islemler = new MisafirIslemleri();

            int ilceNo = islemler.IlceIdGetir(ilceComboBox.Text);
            if (ilceNo == -1)
            {
                MessageBox.Show("Geçersiz ilçe seçimi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int musteriID = islemler.MusteriIdGetir(musteriKimlikNoTextBox.Text);
            if (musteriID == -1)
            {
                MessageBox.Show("Bağlanacak Müşteri bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string cinsiyet = cinsiyetComboBox.Text == "Erkek" ? "E" : "K";

            bool sonuc = islemler.MisafirGuncelle(
                guncellenecekMisafirID,
                kimlikNoTextBox.Text,
                adTextBox.Text,
                soyadTextBox.Text,
                cinsiyet,
                telefonNoTextBox.Text,
                ePostaTextBox.Text,
                adresTextBox.Text,
                ilceNo,
                musteriID
            );

            if (sonuc)
            {
                MessageBox.Show("Misafir bilgileri başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ListeyiYenile();
                Temizle();
                guncellenecekMisafirID = 0;
            }
            else
            {
                MessageBox.Show("Güncelleme işlemi başarısız oldu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}