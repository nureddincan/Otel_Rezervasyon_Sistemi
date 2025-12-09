using System.Data;

namespace Otel_Rezervasyon_Sistemi
{
    public partial class MusteriIslemleriForm : Form
    {
        public MusteriIslemleriForm()
        {
            InitializeComponent();
        }

        // Güncellenecek kişinin ID'sini burada saklayacağız.
        int guncellenecekMusteriID = 0;
        private void ListeyiYenile()
        {
            MusteriIslemleri islemler = new MusteriIslemleri();

            // Verileri çek
            musterilerDataGridView.DataSource = islemler.MusterileriListele();

            // Sütunları tablo genişliğine yay (Fill)
            musterilerDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        void MusteriIslemleriForm_Load(object sender, EventArgs e)
        {
            cinsiyetComboBox.SelectedIndex = 0;
            ilceComboBox.SelectedIndex = 0;
            ListeyiYenile();
        }
        private void musteriEkleButton_Click(object sender, EventArgs e)
        {
            // Tüm alanları kontrol et herhangi biri boşsa veya sadece boşluk karakteri varsa hata ver
            if (string.IsNullOrWhiteSpace(kimlikNoTextBox.Text) ||
                string.IsNullOrWhiteSpace(adTextBox.Text) ||
                string.IsNullOrWhiteSpace(soyadTextBox.Text) ||
                string.IsNullOrWhiteSpace(cinsiyetComboBox.Text) ||
                string.IsNullOrWhiteSpace(telefonNoTextBox.Text) ||
                string.IsNullOrWhiteSpace(ePostaTextBox.Text) ||
                string.IsNullOrWhiteSpace(adresTextBox.Text) ||
                string.IsNullOrWhiteSpace(ilceComboBox.Text))
            {
                MessageBox.Show("Lütfen tüm alanları eksiksiz doldurunuz!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // İşlemi durdur
            }

            // 2. Müşteri İşlemleri Sınıfını Çağır
            MusteriIslemleri islemler = new MusteriIslemleri();

            // 3. Seçilen İlçenin ID'sini Bul
            string secilenIlceAdi = ilceComboBox.Text;
            int ilceNo = islemler.IlceIdGetir(secilenIlceAdi);

            if (ilceNo == -1)
            {
                MessageBox.Show("Seçilen ilçe veritabanında bulunamadı! Lütfen listeden geçerli bir ilçe seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. Cinsiyet Dönüşümü
            string cinsiyet = cinsiyetComboBox.Text == "Erkek" ? "E" : "K";

            // 5. Kayıt İşlemini Başlat
            bool basariliMi = islemler.MusteriEkle(
                kimlikNoTextBox.Text,
                adTextBox.Text,
                soyadTextBox.Text,
                cinsiyet,
                telefonNoTextBox.Text,
                ePostaTextBox.Text,
                adresTextBox.Text,
                ilceNo
            );

            // 6. Sonuç Bildirimi ve Listeyi Yenileme
            if (basariliMi)
            {
                MessageBox.Show("Müşteri başarıyla sisteme kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temizle();       // Kutuları boşalt
                ListeyiYenile(); // Listeyi güncelle
            }
        }

        // Formu temizlemek için yardımcı bir metot
        private void Temizle()
        {
            kimlikNoTextBox.Clear();
            adTextBox.Clear();
            soyadTextBox.Clear();
            telefonNoTextBox.Clear();
            ePostaTextBox.Clear();
            adresTextBox.Clear();
        }
        private void musteriSilButton_Click(object sender, EventArgs e)
        {
            // 1. TCKN Girilmiş mi Kontrol Et
            string silinecekTC = musteriSilGuncelleKimlikNoTextBox.Text;

            if (string.IsNullOrWhiteSpace(silinecekTC))
            {
                MessageBox.Show("Lütfen silinecek müşterinin Kimlik Numarasını giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kullanıcıdan Onay Al (Yanlışlıkla silmeyi önlemek için)
            DialogResult onay = MessageBox.Show(silinecekTC + " kimlik numaralı müşteriyi ve tüm bağlı kayıtlarını silmek istediğinize emin misiniz?",
                                                "Silme Onayı",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

            if (onay == DialogResult.Yes)
            {
                MusteriIslemleri islemler = new MusteriIslemleri();
                bool sonuc = islemler.MusteriSil(silinecekTC);

                if (sonuc)
                {
                    MessageBox.Show("Müşteri başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Listeyi yeniliyoruz ki silinen kişi tablodan gitsin
                    ListeyiYenile();

                    // Kutucuğu temizle
                    musteriSilGuncelleKimlikNoTextBox.Clear();
                }
                else
                {
                    MessageBox.Show("Bu kimlik numarasına sahip bir müşteri bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void musteriAraButton_Click(object sender, EventArgs e)
        {
            string arananIsim = adAraTextBox.Text.Trim(); // .Trim() baştaki/sondaki boşlukları siler

            MusteriIslemleri islemler = new MusteriIslemleri();

            // Eğer kutu boşsa tüm listeyi getir, doluysa filtrele
            if (string.IsNullOrEmpty(arananIsim))
            {
                // Kutu boşsa normal listeleme yap (Hepsini göster)
                musterilerDataGridView.DataSource = islemler.MusterileriListele();
            }
            else
            {
                // Kutu doluysa isme göre arama yap
                musterilerDataGridView.DataSource = islemler.MusteriAra(arananIsim);
            }
        }
        private void musteriGuncelleButton_Click(object sender, EventArgs e)
        {
            string tckn = musteriSilGuncelleKimlikNoTextBox.Text;

            if (string.IsNullOrWhiteSpace(tckn))
            {
                MessageBox.Show("Lütfen güncellenecek müşterinin TC Kimlik Numarasını girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MusteriIslemleri islemler = new MusteriIslemleri();
            DataTable dt = islemler.MusteriBilgileriniGetir(tckn);

            if (dt.Rows.Count > 0)
            {
                // Gelen veriyi değişkenlere al
                DataRow satir = dt.Rows[0];
                guncellenecekMusteriID = Convert.ToInt32(satir["musteriID"]); // ID'yi hafızaya al

                // Kutucukları doldur
                kimlikNoTextBox.Text = satir["kimlikNo"].ToString();
                adTextBox.Text = satir["kisiAdi"].ToString();
                soyadTextBox.Text = satir["kisiSoyadi"].ToString();
                telefonNoTextBox.Text = satir["telNo"].ToString();
                ePostaTextBox.Text = satir["eMail"].ToString();
                adresTextBox.Text = satir["adres"].ToString();
                ilceComboBox.Text = satir["ilceAdi"].ToString();

                // Cinsiyet Seçimi
                string c = satir["cinsiyet"].ToString();
                cinsiyetComboBox.Text = (c == "E") ? "Erkek" : "Kadın";

                MessageBox.Show("Bilgiler yüklendi. Aşağıdaki kutucuklardan değişiklikleri yapıp 'Değişiklikleri Kaydet' butonuna basın.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Bu kimlik numarasına sahip kayıt bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void degisiklikleriKaydetButton_Click(object sender, EventArgs e)
        {
            if (guncellenecekMusteriID == 0)
            {
                MessageBox.Show("Lütfen önce yukarıdan bir müşteri getiriniz (Güncelle butonuna basınız).", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MusteriIslemleri islemler = new MusteriIslemleri();

            // İlçe ID'sini bul
            int ilceNo = islemler.IlceIdGetir(ilceComboBox.Text);
            if (ilceNo == -1) return; // İlçe bulunamadıysa dur

            string cinsiyet = cinsiyetComboBox.Text == "Erkek" ? "E" : "K";

            // Güncelleme Fonksiyonunu Çağır
            bool sonuc = islemler.MusteriGuncelle(
                guncellenecekMusteriID, // Hafızadaki ID'yi kullanıyoruz
                kimlikNoTextBox.Text,
                adTextBox.Text,
                soyadTextBox.Text,
                cinsiyet,
                telefonNoTextBox.Text,
                ePostaTextBox.Text,
                adresTextBox.Text,
                ilceNo
            );

            if (sonuc)
            {
                MessageBox.Show("Müşteri bilgileri başarıyla güncellendi.");
                ListeyiYenile(); // Listeyi güncelle
                Temizle();       // Kutuları temizle
                guncellenecekMusteriID = 0; // ID'yi sıfırla
            }
            else
            {
                MessageBox.Show("Güncelleme işlemi başarısız oldu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
