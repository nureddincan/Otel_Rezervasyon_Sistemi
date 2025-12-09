using Npgsql; 

namespace Otel_Rezervasyon_Sistemi
{
    public partial class RezervasyonSilForm : Form
    {
        public RezervasyonSilForm()
        {
            InitializeComponent();
        }

        RezervasyonIslemleri islemler = new RezervasyonIslemleri();
        private void RezervasyonSilForm_Load(object sender, EventArgs e)
        {
            ListeyiYenile();
        }
        private void ListeyiYenile()
        {
            // Listeleme metodu RezervasyonIslemleri sınıfından geliyor
            rezervasyonlarDataGridView.DataSource = islemler.RezervasyonlariListele();

            // Sütun genişliklerini ayarla
            rezervasyonlarDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // 2. ARAMA BUTONU (TCKN İLE)
        private void rezervasyonAraButton_Click(object sender, EventArgs e)
        {
            string arananTC = musteriKimlikNoTextBox.Text.Trim();

            if (string.IsNullOrEmpty(arananTC))
            {
                // Kutu boşsa hepsini getir
                ListeyiYenile();
            }
            else
            {
                // Doluysa filtrele
                rezervasyonlarDataGridView.DataSource = islemler.RezervasyonAra(arananTC);
            }
        }

        // 4. SİLME BUTONU (Tigger-1)
        private void rezervasyonSilButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rezervasyonIDTextBox.Text))
            {
                MessageBox.Show("Lütfen silinecek Rezervasyon ID'sini girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int silinecekID = Convert.ToInt32(rezervasyonIDTextBox.Text);

            // Onay Penceresi (Soru İkonlu)
            DialogResult onay = MessageBox.Show(silinecekID + " numaralı rezervasyonu silmek istediğinize emin misiniz?\n\n(DİKKAT: Bu işlem geri alınamaz! Bağlı fatura, misafir ve hizmet kayıtları da otomatik silinecektir.)",
                                                "Silme Onayı",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

            if (onay == DialogResult.Yes)
            {
                try
                {
                    bool sonuc = islemler.RezervasyonSil(silinecekID);

                    if (sonuc)
                    {
                        // Trigger arka planda çalışıp yedeği RezervasyonLog tablosuna aldı.
                        MessageBox.Show("Rezervasyon başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListeyiYenile();
                        rezervasyonIDTextBox.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Rezervasyon bulunamadı veya zaten silinmiş.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Silme işlemi sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 5. FATURA OLUŞTUR BUTONU (SAKLI YORDAM-1)
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