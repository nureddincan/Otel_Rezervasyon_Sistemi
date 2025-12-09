using System.Data;

namespace Otel_Rezervasyon_Sistemi
{
    public partial class HizmetlerForm : Form
    {
        public HizmetlerForm()
        {
            InitializeComponent();
        }

        RezervasyonIslemleri islemler = new RezervasyonIslemleri();
        private void HizmetlerForm_Load(object sender, EventArgs e)
        {
            OdaListesiniDoldur(); // Başlangıçta oda numaralarını doldur
            ListeyiYenile(0); // 0 = Tüm Odalar
        }

        // COMBOBOX DOLDURMA (Tüm Odalar Seçeneği İle)
        private void OdaListesiniDoldur()
        {
            DataTable dtOdalar = islemler.OdaNumaralariniGetir();

            // ComboBox'a "Tüm Odalar" seçeneğini en başa eklemek için:
            // Yeni bir satır oluşturup tablonun başına ekliyoruz.
            DataRow dr = dtOdalar.NewRow(); // Yeni satır
            dr["odaNo"] = 0; // Oda Numarası 0 (Tümü için)
            dtOdalar.Rows.InsertAt(dr, 0); // En başa ekle

            odaNoComboBox.DataSource = dtOdalar; // Veri kaynağını ayarla
            odaNoComboBox.DisplayMember = "odaNo"; // Görüntülenecek alan
            odaNoComboBox.ValueMember = "odaNo"; // Değer alanı

            // Basitçe kullanıcı 0'ı "Tümü" olarak bilir. 
        }
        private void hizmetleriAraButton_Click(object sender, EventArgs e)
        {
            if (odaNoComboBox.SelectedValue != null)
            {
                int secilenOda = Convert.ToInt32(odaNoComboBox.SelectedValue); // Seçilen oda numarasını al
                ListeyiYenile(secilenOda); // Listeyi yenile
            }
        }
        private void ListeyiYenile(int odaNo)
        {
            DataTable dt = islemler.HizmetleriListele(odaNo); // Oda numarasına göre listeleme
            hizmetlerDataGridView.DataSource = dt; // Veri kaynağını ayarla
            hizmetlerDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Sütun genişliklerini ayarla

            if (dt.Rows.Count == 0) // Kayıt yoksa bilgi ver
            {
                MessageBox.Show("Kayıtlı hizmet bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}