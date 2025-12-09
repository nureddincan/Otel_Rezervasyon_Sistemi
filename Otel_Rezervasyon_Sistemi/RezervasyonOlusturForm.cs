using Npgsql;
using System.Data;

namespace Otel_Rezervasyon_Sistemi
{
    public partial class RezervasyonOlusturForm : Form
    {
        public RezervasyonOlusturForm()
        {
            InitializeComponent();
        }

        RezervasyonIslemleri islemler = new RezervasyonIslemleri();
        private void RezervasyonOlusturForm_Load(object sender, EventArgs e)
        {

            // 1. ÖNCE VERİTABANINI GÜNCELLE (Tarihi geçenleri pasif yap)
            islemler.GecmisRezervasyonlariGuncelle();

            // 2. Müşteri Listesini Doldur
            DataTable dtMusteri = islemler.MusteriListesiGetir();
            musteriKimlikNoComboBox.DataSource = dtMusteri;
            musteriKimlikNoComboBox.DisplayMember = "kimlikNo";
            musteriKimlikNoComboBox.SelectedIndex = -1;

            // 3. Tarih Sınırlarını Ayarla
            cikisDateTimePicker.MinDate = DateTime.Now.AddDays(1);

            // 4. Misafir Kutularını Başlangıçta Kapat
            misafirKimlikNoComboBox1.Enabled = false;
            misafirKimlikNoComboBox2.Enabled = false;

            // 5. İlk Listeleme
            ListeyiYenile();
            // Form açıldığında varsayılan tarihe göre oda listesini güncellemeye çalış
            OdalariGuncelle();
        }

        private void ListeyiYenile()
        {
            rezervasyonlarDataGridView.DataSource = islemler.RezervasyonlariListele();
            rezervasyonlarDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // --- MÜŞTERİ SEÇİLİNCE MİSAFİRLERİ GETİR ---
        private void musteriKimlikNoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (musteriKimlikNoComboBox.SelectedIndex != -1 && !string.IsNullOrEmpty(musteriKimlikNoComboBox.Text))
            {
                string secilenTC = musteriKimlikNoComboBox.Text;

                // Müşteriye ait misafirleri çek
                DataTable dtMisafir = islemler.MusteriyeAitMisafirleriGetir(secilenTC);

                // ComboBox 1'i doldur
                misafirKimlikNoComboBox1.DataSource = dtMisafir.Copy();
                misafirKimlikNoComboBox1.DisplayMember = "kimlikNo";
                misafirKimlikNoComboBox1.SelectedIndex = -1;

                // ComboBox 2'yi doldur
                misafirKimlikNoComboBox2.DataSource = dtMisafir.Copy();
                misafirKimlikNoComboBox2.DisplayMember = "kimlikNo";
                misafirKimlikNoComboBox2.SelectedIndex = -1;
            }
        }

        // --- ODALARI GÜNCELLEME METODU (KRİTİK) ---
        private void OdalariGuncelle()
        {
            DateTime giris = girisDateTimePicker.Value.Date;
            DateTime cikis = cikisDateTimePicker.Value.Date;

            // Tarih hatası varsa listeyi boşalt
            if (cikis <= giris) { odaNoComboBox.DataSource = null; return; }

            // TOPLAM KİŞİ SAYISINI BUL
            // Müşteri (1) + Seçilen Misafir Sayısı
            int toplamKisi = 1 + (int)misafirSayisiNumericUpDown.Value;

            // Veritabanından buna uygun odaları çek
            DataTable dtOda = islemler.MusaitOdalariGetir(giris, cikis, toplamKisi);

            odaNoComboBox.DataSource = dtOda;
            odaNoComboBox.DisplayMember = "odaNo";
            odaNoComboBox.SelectedIndex = -1;
        }

        // --- TARİH DEĞİŞİNCE ---
        private void TarihDegisti(object sender, EventArgs e)
        {
            OdalariGuncelle();
        }

        // --- MİSAFİR SAYISI DEĞİŞİNCE ---
        private void misafirSayisiNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            int sayi = (int)misafirSayisiNumericUpDown.Value;

            // Kutuları Aç/Kapat
            misafirKimlikNoComboBox1.Enabled = (sayi >= 1);
            misafirKimlikNoComboBox2.Enabled = (sayi >= 2);

            // Sayı düşerse seçimi temizle
            if (sayi < 2) misafirKimlikNoComboBox2.SelectedIndex = -1;
            if (sayi < 1) misafirKimlikNoComboBox1.SelectedIndex = -1;

            // En önemlisi: ODA LİSTESİNİ YENİ KAPASİTEYE GÖRE GÜNCELLE
            OdalariGuncelle();
        }

        // --- REZERVASYON OLUŞTUR BUTONU ---
        private void rezervasyonOlusturButton_Click(object sender, EventArgs e)
        {
            // 1. Validasyonlar
            if (string.IsNullOrEmpty(musteriKimlikNoComboBox.Text) || string.IsNullOrEmpty(odaNoComboBox.Text))
            {
                MessageBox.Show("Lütfen Müşteri ve Oda seçimini yapınız.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cikisDateTimePicker.Value.Date <= girisDateTimePicker.Value.Date)
            {
                MessageBox.Show("Çıkış tarihi, giriş tarihinden sonra olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Misafir Seçimi Kontrolü
            int misafirSayisi = (int)misafirSayisiNumericUpDown.Value;
            if (misafirSayisi >= 1 && string.IsNullOrEmpty(misafirKimlikNoComboBox1.Text))
            {
                MessageBox.Show("1. Misafir için TCKN seçmelisiniz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (misafirSayisi >= 2 && string.IsNullOrEmpty(misafirKimlikNoComboBox2.Text))
            {
                MessageBox.Show("2. Misafir için TCKN seçmelisiniz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Verileri Topla
            List<int> secilenHizmetler = new List<int>();
            if (ogleYemegiCheckBox.Checked) secilenHizmetler.Add(1);
            if (kahvaltiCheckBox.Checked) secilenHizmetler.Add(2);
            if (aksamYemegiCheckBox.Checked) secilenHizmetler.Add(3);
            if (odaServisiCheckBox.Checked) secilenHizmetler.Add(4);
            if (odaTemizligiCheckBox.Checked) secilenHizmetler.Add(5);

            List<string> secilenMisafirTCleri = new List<string>();
            if (misafirSayisi >= 1) secilenMisafirTCleri.Add(misafirKimlikNoComboBox1.Text);
            if (misafirSayisi >= 2) secilenMisafirTCleri.Add(misafirKimlikNoComboBox2.Text);

            try
            {
                // 3. Veritabanı İşlemi
                int yeniID = islemler.RezervasyonYap(
                    musteriKimlikNoComboBox.Text,
                    girisDateTimePicker.Value,
                    cikisDateTimePicker.Value,
                    Convert.ToInt32(odaNoComboBox.Text),
                    secilenHizmetler,
                    secilenMisafirTCleri
                );

                MessageBox.Show("Rezervasyon başarıyla oluşturuldu!\nRezervasyon No: " + yeniID, "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                rezervasyonIDTextBox.Text = yeniID.ToString();

                // 4. Temizle ve Listele
                Temizle();
                ListeyiYenile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- TEMİZLEME METODU ---
        private void Temizle()
        {
            musteriKimlikNoComboBox.SelectedIndex = -1;
            odaNoComboBox.DataSource = null; // Oda listesini sıfırla

            // Tarihleri varsayılana çek
            girisDateTimePicker.Value = DateTime.Now;
            cikisDateTimePicker.Value = DateTime.Now.AddDays(1);

            // Checkboxları temizle
            ogleYemegiCheckBox.Checked = false;
            kahvaltiCheckBox.Checked = false;
            aksamYemegiCheckBox.Checked = false;
            odaServisiCheckBox.Checked = false;
            odaTemizligiCheckBox.Checked = false;

            // Misafir alanlarını temizle
            misafirSayisiNumericUpDown.Value = 0;
            misafirKimlikNoComboBox1.SelectedIndex = -1;
            misafirKimlikNoComboBox2.SelectedIndex = -1;
            misafirKimlikNoComboBox1.Enabled = false;
            misafirKimlikNoComboBox2.Enabled = false;

            // Oda listesini tekrar güncelle (Varsayılan duruma göre)
            OdalariGuncelle();
        }

        private void faturaOlusturButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rezervasyonIDTextBox.Text))
            {
                MessageBox.Show("Fatura oluşturmak için lütfen bir rezervasyon seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(rezervasyonIDTextBox.Text);

            try
            {
                // RezervasyonIslemleri sınıfındaki FaturaOlustur metodunu çağırıyoruz.
                // Bu metod veritabanındaki "sp_FaturaOlustur" saklı yordamını tetikler.
                islemler.FaturaOlustur(id);

                MessageBox.Show("Fatura başarıyla hesaplandı ve oluşturuldu.\nFatura No: " + id,
                                "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (PostgresException ex)
            {
                // Hata Kodu 23505: Unique Constraint Violation (Aynı fatura nosu zaten var)
                if (ex.SqlState == "23505")
                {
                    MessageBox.Show("Bu rezervasyon için zaten bir fatura oluşturulmuş! Aynı faturayı tekrar oluşturamazsınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Veritabanı Hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beklenmedik Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}