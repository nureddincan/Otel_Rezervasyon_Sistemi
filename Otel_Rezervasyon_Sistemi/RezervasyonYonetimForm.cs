namespace Otel_Rezervasyon_Sistemi
{
    public partial class RezervasyonYonetimForm : Form
    {
        public RezervasyonYonetimForm()
        {
            InitializeComponent();
        }
        private void musteriIslemleriButton_Click(object sender, EventArgs e)
        {
            MusteriIslemleriForm musteriIslemleriForm = new MusteriIslemleriForm();
            musteriIslemleriForm.ShowDialog();
        }
        private void misafirIslemleriButton_Click(object sender, EventArgs e)
        {
            MisafirIslemleriForm misafirIslemleriForm = new MisafirIslemleriForm();
            misafirIslemleriForm.ShowDialog();
        }
        private void rezervasyonOlusturButton_Click(object sender, EventArgs e)
        {
            RezervasyonOlusturForm rezervasyonOlusturForm = new RezervasyonOlusturForm();
            rezervasyonOlusturForm.ShowDialog();
        }
        private void rezervasyonSilButton_Click(object sender, EventArgs e)
        {
            RezervasyonSilForm rezervasyonSilForm = new RezervasyonSilForm();
            rezervasyonSilForm.ShowDialog();
        }
        private void faturalarButton_Click(object sender, EventArgs e)
        {
            FaturalarForm faturalarForm = new FaturalarForm();
            faturalarForm.ShowDialog();
        }
        private void hizmetleriGoruntuleButton_Click(object sender, EventArgs e)
        {
            HizmetlerForm hizmetlerForm = new HizmetlerForm();
            hizmetlerForm.ShowDialog();
        }
    }
}
