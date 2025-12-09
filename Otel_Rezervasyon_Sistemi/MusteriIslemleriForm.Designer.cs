namespace Otel_Rezervasyon_Sistemi
{
    partial class MusteriIslemleriForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MusteriIslemleriForm));
            ilceComboBox = new ComboBox();
            ilceLabel = new Label();
            adresTextBox = new TextBox();
            adresLabel = new Label();
            ePostaTextBox = new TextBox();
            ePostaLabel = new Label();
            telefonNoTextBox = new TextBox();
            telefonNoLabel = new Label();
            cinsiyetComboBox = new ComboBox();
            cinsiyetLabel = new Label();
            soyadTextBox = new TextBox();
            soyadLabel = new Label();
            adTextBox = new TextBox();
            adLabel = new Label();
            kimlikNoTextBox = new TextBox();
            kimlikNoLabel = new Label();
            musteriEkleButton = new Button();
            musteriSilButton = new Button();
            adAraTextBox = new TextBox();
            adAraLabel = new Label();
            musteriAraButton = new Button();
            musteriSilGuncelleKimlikNoTextBox = new TextBox();
            musteriSilGuncelleKimlikNoNoLabel = new Label();
            musterilerDataGridView = new DataGridView();
            musteriLabel = new Label();
            musteriGuncelleButton = new Button();
            degisiklikleriKaydetButton = new Button();
            ((System.ComponentModel.ISupportInitialize)musterilerDataGridView).BeginInit();
            SuspendLayout();
            // 
            // ilceComboBox
            // 
            ilceComboBox.DropDownHeight = 150;
            ilceComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ilceComboBox.FormattingEnabled = true;
            ilceComboBox.IntegralHeight = false;
            ilceComboBox.ItemHeight = 28;
            ilceComboBox.Items.AddRange(new object[] { "Esenyurt", "Küçükçekmece", "Bağcılar", "Pendik", "Ümraniye", "Çankaya", "Keçiören", "Yenimahalle", "Mamak", "Etimesgut", "Buca", "Karabağlar", "Bornova", "Karşıyaka", "Konak", "Osmangazi", "Yıldırım", "Nilüfer", "İnegöl", "Gemlik", "Muratpaşa", "Konyaaltı", "Kepez", "Aksu", "Döşemealtı", "Gebze", "İzmit", "Darıca", "Körfez", "Gölcük", "Adapazarı", "Serdivan", "Akyazı", "Erenler", "Hendek", "Seyhan", "Yüreğir", "Çukurova", "Sarıçam", "Ceyhan", "Şahinbey", "Şehitkamil", "Nizip", "İslahiye", "Nurdağı", "Selçuklu", "Karatay", "Meram", "Ereğli", "Akşehir" });
            ilceComboBox.Location = new Point(137, 499);
            ilceComboBox.Name = "ilceComboBox";
            ilceComboBox.Size = new Size(189, 36);
            ilceComboBox.TabIndex = 23;
            // 
            // ilceLabel
            // 
            ilceLabel.AutoSize = true;
            ilceLabel.Location = new Point(12, 502);
            ilceLabel.Name = "ilceLabel";
            ilceLabel.Size = new Size(45, 28);
            ilceLabel.TabIndex = 22;
            ilceLabel.Text = "İlçe:";
            ilceLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // adresTextBox
            // 
            adresTextBox.BorderStyle = BorderStyle.FixedSingle;
            adresTextBox.Location = new Point(137, 459);
            adresTextBox.MaxLength = 90;
            adresTextBox.Name = "adresTextBox";
            adresTextBox.Size = new Size(189, 34);
            adresTextBox.TabIndex = 21;
            // 
            // adresLabel
            // 
            adresLabel.AutoSize = true;
            adresLabel.Location = new Point(12, 461);
            adresLabel.Name = "adresLabel";
            adresLabel.Size = new Size(66, 28);
            adresLabel.TabIndex = 20;
            adresLabel.Text = "Adres:";
            adresLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ePostaTextBox
            // 
            ePostaTextBox.BorderStyle = BorderStyle.FixedSingle;
            ePostaTextBox.Location = new Point(137, 419);
            ePostaTextBox.MaxLength = 40;
            ePostaTextBox.Name = "ePostaTextBox";
            ePostaTextBox.PlaceholderText = "abc@gmail.com";
            ePostaTextBox.Size = new Size(189, 34);
            ePostaTextBox.TabIndex = 19;
            // 
            // ePostaLabel
            // 
            ePostaLabel.AutoSize = true;
            ePostaLabel.Location = new Point(12, 421);
            ePostaLabel.Name = "ePostaLabel";
            ePostaLabel.Size = new Size(81, 28);
            ePostaLabel.TabIndex = 18;
            ePostaLabel.Text = "E-Posta:";
            ePostaLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // telefonNoTextBox
            // 
            telefonNoTextBox.BorderStyle = BorderStyle.FixedSingle;
            telefonNoTextBox.Location = new Point(137, 379);
            telefonNoTextBox.MaxLength = 11;
            telefonNoTextBox.Name = "telefonNoTextBox";
            telefonNoTextBox.Size = new Size(189, 34);
            telefonNoTextBox.TabIndex = 17;
            // 
            // telefonNoLabel
            // 
            telefonNoLabel.AutoSize = true;
            telefonNoLabel.Location = new Point(12, 381);
            telefonNoLabel.Name = "telefonNoLabel";
            telefonNoLabel.Size = new Size(110, 28);
            telefonNoLabel.TabIndex = 16;
            telefonNoLabel.Text = "Telefon No:";
            telefonNoLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cinsiyetComboBox
            // 
            cinsiyetComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            cinsiyetComboBox.FormattingEnabled = true;
            cinsiyetComboBox.ItemHeight = 28;
            cinsiyetComboBox.Items.AddRange(new object[] { "Erkek", "Kadın" });
            cinsiyetComboBox.Location = new Point(137, 334);
            cinsiyetComboBox.Name = "cinsiyetComboBox";
            cinsiyetComboBox.Size = new Size(189, 36);
            cinsiyetComboBox.TabIndex = 15;
            // 
            // cinsiyetLabel
            // 
            cinsiyetLabel.AutoSize = true;
            cinsiyetLabel.Location = new Point(12, 337);
            cinsiyetLabel.Name = "cinsiyetLabel";
            cinsiyetLabel.Size = new Size(84, 28);
            cinsiyetLabel.TabIndex = 14;
            cinsiyetLabel.Text = "Cinsiyet:";
            cinsiyetLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // soyadTextBox
            // 
            soyadTextBox.BorderStyle = BorderStyle.FixedSingle;
            soyadTextBox.Location = new Point(137, 294);
            soyadTextBox.MaxLength = 40;
            soyadTextBox.Name = "soyadTextBox";
            soyadTextBox.Size = new Size(189, 34);
            soyadTextBox.TabIndex = 13;
            // 
            // soyadLabel
            // 
            soyadLabel.AutoSize = true;
            soyadLabel.Location = new Point(12, 296);
            soyadLabel.Name = "soyadLabel";
            soyadLabel.Size = new Size(71, 28);
            soyadLabel.TabIndex = 12;
            soyadLabel.Text = "Soyad:";
            soyadLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // adTextBox
            // 
            adTextBox.BorderStyle = BorderStyle.FixedSingle;
            adTextBox.Location = new Point(137, 254);
            adTextBox.MaxLength = 40;
            adTextBox.Name = "adTextBox";
            adTextBox.Size = new Size(189, 34);
            adTextBox.TabIndex = 11;
            // 
            // adLabel
            // 
            adLabel.AutoSize = true;
            adLabel.Location = new Point(12, 256);
            adLabel.Name = "adLabel";
            adLabel.Size = new Size(112, 28);
            adLabel.TabIndex = 10;
            adLabel.Text = "Müşteri Ad:";
            adLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // kimlikNoTextBox
            // 
            kimlikNoTextBox.BorderStyle = BorderStyle.FixedSingle;
            kimlikNoTextBox.Location = new Point(137, 214);
            kimlikNoTextBox.MaxLength = 11;
            kimlikNoTextBox.Name = "kimlikNoTextBox";
            kimlikNoTextBox.Size = new Size(189, 34);
            kimlikNoTextBox.TabIndex = 9;
            // 
            // kimlikNoLabel
            // 
            kimlikNoLabel.AutoSize = true;
            kimlikNoLabel.Location = new Point(12, 216);
            kimlikNoLabel.Name = "kimlikNoLabel";
            kimlikNoLabel.Size = new Size(102, 28);
            kimlikNoLabel.TabIndex = 8;
            kimlikNoLabel.Text = "Kimlik No:";
            kimlikNoLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // musteriEkleButton
            // 
            musteriEkleButton.BackColor = SystemColors.ActiveCaption;
            musteriEkleButton.Cursor = Cursors.Hand;
            musteriEkleButton.Location = new Point(128, 544);
            musteriEkleButton.Name = "musteriEkleButton";
            musteriEkleButton.Size = new Size(198, 41);
            musteriEkleButton.TabIndex = 24;
            musteriEkleButton.Text = "Yeni Müşteri Ekle";
            musteriEkleButton.UseVisualStyleBackColor = false;
            musteriEkleButton.Click += musteriEkleButton_Click;
            // 
            // musteriSilButton
            // 
            musteriSilButton.BackColor = SystemColors.ActiveCaption;
            musteriSilButton.Cursor = Cursors.Hand;
            musteriSilButton.Location = new Point(246, 167);
            musteriSilButton.Name = "musteriSilButton";
            musteriSilButton.Size = new Size(80, 41);
            musteriSilButton.TabIndex = 7;
            musteriSilButton.Text = "Sil";
            musteriSilButton.UseVisualStyleBackColor = false;
            musteriSilButton.Click += musteriSilButton_Click;
            // 
            // adAraTextBox
            // 
            adAraTextBox.BorderStyle = BorderStyle.FixedSingle;
            adAraTextBox.Location = new Point(137, 40);
            adAraTextBox.MaxLength = 40;
            adAraTextBox.Name = "adAraTextBox";
            adAraTextBox.Size = new Size(189, 34);
            adAraTextBox.TabIndex = 2;
            // 
            // adAraLabel
            // 
            adAraLabel.AutoSize = true;
            adAraLabel.Location = new Point(12, 42);
            adAraLabel.Name = "adAraLabel";
            adAraLabel.Size = new Size(112, 28);
            adAraLabel.TabIndex = 1;
            adAraLabel.Text = "Müşteri Ad:";
            adAraLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // musteriAraButton
            // 
            musteriAraButton.BackColor = SystemColors.ActiveCaption;
            musteriAraButton.Cursor = Cursors.Hand;
            musteriAraButton.Location = new Point(137, 80);
            musteriAraButton.Name = "musteriAraButton";
            musteriAraButton.Size = new Size(189, 41);
            musteriAraButton.TabIndex = 3;
            musteriAraButton.Text = "Ara";
            musteriAraButton.UseVisualStyleBackColor = false;
            musteriAraButton.Click += musteriAraButton_Click;
            // 
            // musteriSilGuncelleKimlikNoTextBox
            // 
            musteriSilGuncelleKimlikNoTextBox.BorderStyle = BorderStyle.FixedSingle;
            musteriSilGuncelleKimlikNoTextBox.Location = new Point(137, 127);
            musteriSilGuncelleKimlikNoTextBox.MaxLength = 11;
            musteriSilGuncelleKimlikNoTextBox.Name = "musteriSilGuncelleKimlikNoTextBox";
            musteriSilGuncelleKimlikNoTextBox.Size = new Size(189, 34);
            musteriSilGuncelleKimlikNoTextBox.TabIndex = 5;
            // 
            // musteriSilGuncelleKimlikNoNoLabel
            // 
            musteriSilGuncelleKimlikNoNoLabel.AutoSize = true;
            musteriSilGuncelleKimlikNoNoLabel.Location = new Point(12, 129);
            musteriSilGuncelleKimlikNoNoLabel.Name = "musteriSilGuncelleKimlikNoNoLabel";
            musteriSilGuncelleKimlikNoNoLabel.Size = new Size(102, 28);
            musteriSilGuncelleKimlikNoNoLabel.TabIndex = 4;
            musteriSilGuncelleKimlikNoNoLabel.Text = "Kimlik No:";
            musteriSilGuncelleKimlikNoNoLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // musterilerDataGridView
            // 
            musterilerDataGridView.BackgroundColor = SystemColors.ControlLight;
            musterilerDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            musterilerDataGridView.Location = new Point(332, 40);
            musterilerDataGridView.Name = "musterilerDataGridView";
            musterilerDataGridView.ReadOnly = true;
            musterilerDataGridView.Size = new Size(1115, 592);
            musterilerDataGridView.TabIndex = 27;
            // 
            // musteriLabel
            // 
            musteriLabel.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 162);
            musteriLabel.Location = new Point(332, 7);
            musteriLabel.Name = "musteriLabel";
            musteriLabel.Size = new Size(1115, 30);
            musteriLabel.TabIndex = 26;
            musteriLabel.Text = "~Müşteriler~";
            musteriLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // musteriGuncelleButton
            // 
            musteriGuncelleButton.BackColor = SystemColors.ActiveCaption;
            musteriGuncelleButton.Cursor = Cursors.Hand;
            musteriGuncelleButton.Location = new Point(137, 167);
            musteriGuncelleButton.Name = "musteriGuncelleButton";
            musteriGuncelleButton.Size = new Size(103, 41);
            musteriGuncelleButton.TabIndex = 6;
            musteriGuncelleButton.Text = "Güncelle";
            musteriGuncelleButton.UseVisualStyleBackColor = false;
            musteriGuncelleButton.Click += musteriGuncelleButton_Click;
            // 
            // degisiklikleriKaydetButton
            // 
            degisiklikleriKaydetButton.BackColor = SystemColors.ActiveCaption;
            degisiklikleriKaydetButton.Cursor = Cursors.Hand;
            degisiklikleriKaydetButton.Location = new Point(128, 591);
            degisiklikleriKaydetButton.Name = "degisiklikleriKaydetButton";
            degisiklikleriKaydetButton.Size = new Size(198, 41);
            degisiklikleriKaydetButton.TabIndex = 25;
            degisiklikleriKaydetButton.Text = "Değişiklikleri Kaydet";
            degisiklikleriKaydetButton.UseVisualStyleBackColor = false;
            degisiklikleriKaydetButton.Click += degisiklikleriKaydetButton_Click;
            // 
            // MusteriIslemleriForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1459, 642);
            Controls.Add(degisiklikleriKaydetButton);
            Controls.Add(musteriGuncelleButton);
            Controls.Add(musterilerDataGridView);
            Controls.Add(musteriLabel);
            Controls.Add(musteriSilGuncelleKimlikNoTextBox);
            Controls.Add(musteriSilGuncelleKimlikNoNoLabel);
            Controls.Add(adAraTextBox);
            Controls.Add(adAraLabel);
            Controls.Add(musteriAraButton);
            Controls.Add(musteriSilButton);
            Controls.Add(musteriEkleButton);
            Controls.Add(ilceComboBox);
            Controls.Add(ilceLabel);
            Controls.Add(adresTextBox);
            Controls.Add(adresLabel);
            Controls.Add(ePostaTextBox);
            Controls.Add(ePostaLabel);
            Controls.Add(telefonNoTextBox);
            Controls.Add(telefonNoLabel);
            Controls.Add(cinsiyetComboBox);
            Controls.Add(cinsiyetLabel);
            Controls.Add(soyadTextBox);
            Controls.Add(soyadLabel);
            Controls.Add(adTextBox);
            Controls.Add(adLabel);
            Controls.Add(kimlikNoTextBox);
            Controls.Add(kimlikNoLabel);
            Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 162);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 6, 5, 6);
            MaximizeBox = false;
            Name = "MusteriIslemleriForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Müşteri İşlemleri";
            Load += MusteriIslemleriForm_Load;
            ((System.ComponentModel.ISupportInitialize)musterilerDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox ilceComboBox;
        private Label ilceLabel;
        private TextBox adresTextBox;
        private Label adresLabel;
        private TextBox ePostaTextBox;
        private Label ePostaLabel;
        private TextBox telefonNoTextBox;
        private Label telefonNoLabel;
        private ComboBox cinsiyetComboBox;
        private Label cinsiyetLabel;
        private TextBox soyadTextBox;
        private Label soyadLabel;
        private TextBox adTextBox;
        private Label adLabel;
        private TextBox kimlikNoTextBox;
        private Label kimlikNoLabel;
        private Button musteriEkleButton;
        private Button musteriSilButton;
        private TextBox adAraTextBox;
        private Label adAraLabel;
        private Button musteriAraButton;
        private TextBox musteriSilGuncelleKimlikNoTextBox;
        private Label musteriSilGuncelleKimlikNoNoLabel;
        private DataGridView musterilerDataGridView;
        private Label musteriLabel;
        private Button musteriGuncelleButton;
        private Button degisiklikleriKaydetButton;
    }
}