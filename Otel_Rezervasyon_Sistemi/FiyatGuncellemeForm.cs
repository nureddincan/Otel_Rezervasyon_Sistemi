namespace Otel_Rezervasyon_Sistemi
{
    public partial class FiyatGuncellemeForm : Form
    {
        public FiyatGuncellemeForm()
        {
            InitializeComponent();
        }

        // -------------------------------------------------------------------
        // FORM YÜKLENİRKEN ÇALIŞACAK KODLAR
        // -------------------------------------------------------------------
        private void FiyatGuncellemeForm_Load(object sender, EventArgs e)
        {
            // Form açıldığında her iki tabloyu da dolduruyoruz
            PersonelListesiniYenile();
            OdaListesiniYenile();
        }

        // -------------------------------------------------------------------
        // YARDIMCI METOTLAR (LİSTE YENİLEME)
        // -------------------------------------------------------------------
        private void PersonelListesiniYenile()
        {
            FiyatIslemleri islem = new FiyatIslemleri();
            personelTurleriDataGridView.DataSource = islem.PersonelTurleriListele();

            // Sütun Başlıklarını Düzenle
            if (personelTurleriDataGridView.Columns.Count > 0)
            {
                personelTurleriDataGridView.Columns["personelTurID"].HeaderText = "Personel Tur ID";
                personelTurleriDataGridView.Columns["personelTurAdi"].HeaderText = "Personel Tür Adı";
                personelTurleriDataGridView.Columns["personelMaas"].HeaderText = "Personel Maaş";
            }
            personelTurleriDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void OdaListesiniYenile()
        {
            FiyatIslemleri islem = new FiyatIslemleri();
            odaTurleriDataGridView.DataSource = islem.OdaTurleriListele();

            // Sütun Başlıklarını Düzenle
            if (odaTurleriDataGridView.Columns.Count > 0)
            {
                odaTurleriDataGridView.Columns["odaTurID"].HeaderText = "Oda Tür ID";
                odaTurleriDataGridView.Columns["odaTurAdi"].HeaderText = "Oda Tür Adı";
                odaTurleriDataGridView.Columns["odaFiyati"].HeaderText = "Oda Fiyatı";
                odaTurleriDataGridView.Columns["odaKapasite"].HeaderText = "Oda Kapasite";
                odaTurleriDataGridView.Columns["odaMetrekare"].HeaderText = "Oda Metrekare";
            }
            odaTurleriDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        // -------------------------------------------------------------------
        // BÖLÜM 1: PERSONEL MAAŞ GÜNCELLEME İŞLEMLERİ
        // -------------------------------------------------------------------
        private void personelMaasGuncelleButton_Click(object sender, EventArgs e)
        {
            // 1. Boş Alan Kontrolü
            if (string.IsNullOrWhiteSpace(personelTurIDTextBox.Text) ||
                string.IsNullOrWhiteSpace(yeniMaasTextBox.Text))
            {
                MessageBox.Show("Lütfen Personel Tür ID ve Yeni Maaş alanlarını doldurunuz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Veri Tipi Dönüştürme
            if (!short.TryParse(personelTurIDTextBox.Text, out short turID))
            {
                MessageBox.Show("Personel Tür ID sayısal bir değer olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!float.TryParse(yeniMaasTextBox.Text, out float yeniMaas))
            {
                MessageBox.Show("Maaş geçerli bir sayı olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Veritabanı İşlemi
            FiyatIslemleri islem = new FiyatIslemleri();
            bool sonuc = islem.PersonelMaasGuncelle(turID, yeniMaas);

            if (sonuc)
            {
                MessageBox.Show("Personel maaşı başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PersonelListesiniYenile(); // Tabloyu yenile

                // Kutuları Temizle
                personelTurIDTextBox.Clear();
                yeniMaasTextBox.Clear();
            }
        }

        // Listeden seçilen personelin bilgilerini kutucuklara doldurur
        private void personelTurleriDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = personelTurleriDataGridView.Rows[e.RowIndex];
                personelTurIDTextBox.Text = row.Cells["personelTurID"].Value.ToString();
                yeniMaasTextBox.Text = row.Cells["personelMaas"].Value.ToString();
            }
        }

        // -------------------------------------------------------------------
        // BÖLÜM 2: ODA FİYATI GÜNCELLEME İŞLEMLERİ
        // -------------------------------------------------------------------
        private void odaFiyatGuncelleButton_Click(object sender, EventArgs e)
        {
            // 1. Boş Alan Kontrolü
            if (string.IsNullOrWhiteSpace(odaTurIDTextBox.Text) ||
                string.IsNullOrWhiteSpace(yeniFiyatTextBox.Text))
            {
                MessageBox.Show("Lütfen Oda Tür ID ve Yeni Fiyat alanlarını doldurunuz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Veri Tipi Dönüştürme
            if (!short.TryParse(odaTurIDTextBox.Text, out short odaTurID))
            {
                MessageBox.Show("Oda Tür ID sayısal bir değer olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!float.TryParse(yeniFiyatTextBox.Text, out float yeniFiyat))
            {
                MessageBox.Show("Fiyat geçerli bir sayı olmalıdır.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Veritabanı İşlemi
            FiyatIslemleri islem = new FiyatIslemleri();
            bool sonuc = islem.OdaFiyatGuncelle(odaTurID, yeniFiyat);

            if (sonuc)
            {
                MessageBox.Show("Oda fiyatı başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OdaListesiniYenile(); // Tabloyu yenile

                // Kutuları Temizle
                odaTurIDTextBox.Clear();
                yeniFiyatTextBox.Clear();
            }
        }

    }
}