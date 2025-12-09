using System.Data;

namespace Otel_Rezervasyon_Sistemi
{
    public partial class FaturalarForm : Form
    {
        public FaturalarForm()
        {
            InitializeComponent();
        }

        RezervasyonIslemleri islemler = new RezervasyonIslemleri();
        private void faturaAraButton_Click(object sender, EventArgs e)
        {
            ListeyiYenile();
        }
        private void ListeyiYenile()
        {
            string tckn = musteriKimlikNoTextBox.Text.Trim(); // TCKN'yi aldık
            DateTime baslangic = baslangicDateTimePicker.Value; // Başlangıç tarihini aldık
            DateTime bitis = bitisDateTimePicker.Value; // Bitiş tarihini aldık

            DataTable dt = islemler.FaturaAra(tckn, baslangic, bitis);
            faturalarDataGridView.DataSource = dt; // Filtrelenmiş verileri atadık
            faturalarDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Sütun genişliklerini ayarladık

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Seçilen kriterlere uygun fatura bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void faturayiGoruntuleButton_Click(object sender, EventArgs e)
        {
            string faturaNoStr = faturaNoTextBox.Text.Trim(); // Fatura numarasını aldık

            if (string.IsNullOrEmpty(faturaNoStr)) // Boşsa uyarı ver
            {
                MessageBox.Show("Lütfen görüntülemek için bir Fatura Numarası girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // YAZIYI SAYIYA ÇEVİRİYORUZ
                int faturaNo = Convert.ToInt32(faturaNoStr);

                // Detayları veritabanından çek 
                string detaylar = islemler.FaturaDetayGetir(faturaNo);

                if (detaylar == "Fatura bulunamadı.")
                {
                    MessageBox.Show("Bu numaraya ait bir fatura bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(detaylar, "Fatura Detayı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Fatura numarası sadece rakamlardan oluşmalıdır!", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}