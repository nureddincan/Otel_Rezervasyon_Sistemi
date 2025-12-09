namespace Otel_Rezervasyon_Sistemi
{
    partial class PersonelIslemleriForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonelIslemleriForm));
            kimlikNoLabel = new Label();
            kimlikNoTextBox = new TextBox();
            adTextBox = new TextBox();
            adLabel = new Label();
            soyadTextBox = new TextBox();
            soyadLabel = new Label();
            cinsiyetLabel = new Label();
            cinsiyetComboBox = new ComboBox();
            personelTurComboBox = new ComboBox();
            personelTurLabel = new Label();
            sifreTextBox = new TextBox();
            sifreLabel = new Label();
            adresTextBox = new TextBox();
            adresLabel = new Label();
            ePostaTextBox = new TextBox();
            ePostaLabel = new Label();
            telefonNoTextBox = new TextBox();
            telefonNoLabel = new Label();
            ilceComboBox = new ComboBox();
            ilceLabel = new Label();
            personelEkleButton = new Button();
            personellerLabel = new Label();
            personellerDataGridView = new DataGridView();
            personelGuncelleButton = new Button();
            sicilNoTextBox = new TextBox();
            sicilNoLabel = new Label();
            adAraTextBox = new TextBox();
            adAraLabel = new Label();
            personelleriAraButton = new Button();
            kaydetButton = new Button();
            personelSilButton = new Button();
            ((System.ComponentModel.ISupportInitialize)personellerDataGridView).BeginInit();
            SuspendLayout();
            // 
            // kimlikNoLabel
            // 
            kimlikNoLabel.AutoSize = true;
            kimlikNoLabel.Location = new Point(12, 217);
            kimlikNoLabel.Name = "kimlikNoLabel";
            kimlikNoLabel.Size = new Size(128, 28);
            kimlikNoLabel.TabIndex = 7;
            kimlikNoLabel.Text = "TC Kimlik No:";
            kimlikNoLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // kimlikNoTextBox
            // 
            kimlikNoTextBox.BorderStyle = BorderStyle.FixedSingle;
            kimlikNoTextBox.Location = new Point(145, 214);
            kimlikNoTextBox.MaxLength = 11;
            kimlikNoTextBox.Name = "kimlikNoTextBox";
            kimlikNoTextBox.Size = new Size(213, 34);
            kimlikNoTextBox.TabIndex = 8;
            // 
            // adTextBox
            // 
            adTextBox.BorderStyle = BorderStyle.FixedSingle;
            adTextBox.Location = new Point(145, 254);
            adTextBox.MaxLength = 40;
            adTextBox.Name = "adTextBox";
            adTextBox.Size = new Size(213, 34);
            adTextBox.TabIndex = 10;
            // 
            // adLabel
            // 
            adLabel.AutoSize = true;
            adLabel.Location = new Point(12, 257);
            adLabel.Name = "adLabel";
            adLabel.Size = new Size(119, 28);
            adLabel.TabIndex = 9;
            adLabel.Text = "Personel Ad:";
            adLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // soyadTextBox
            // 
            soyadTextBox.BorderStyle = BorderStyle.FixedSingle;
            soyadTextBox.Location = new Point(145, 294);
            soyadTextBox.MaxLength = 40;
            soyadTextBox.Name = "soyadTextBox";
            soyadTextBox.Size = new Size(213, 34);
            soyadTextBox.TabIndex = 12;
            // 
            // soyadLabel
            // 
            soyadLabel.AutoSize = true;
            soyadLabel.Location = new Point(12, 297);
            soyadLabel.Name = "soyadLabel";
            soyadLabel.Size = new Size(71, 28);
            soyadLabel.TabIndex = 11;
            soyadLabel.Text = "Soyad:";
            soyadLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cinsiyetLabel
            // 
            cinsiyetLabel.AutoSize = true;
            cinsiyetLabel.Location = new Point(12, 337);
            cinsiyetLabel.Name = "cinsiyetLabel";
            cinsiyetLabel.Size = new Size(84, 28);
            cinsiyetLabel.TabIndex = 13;
            cinsiyetLabel.Text = "Cinsiyet:";
            cinsiyetLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cinsiyetComboBox
            // 
            cinsiyetComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            cinsiyetComboBox.FormattingEnabled = true;
            cinsiyetComboBox.ItemHeight = 28;
            cinsiyetComboBox.Items.AddRange(new object[] { "Erkek", "Kadın" });
            cinsiyetComboBox.Location = new Point(145, 334);
            cinsiyetComboBox.Name = "cinsiyetComboBox";
            cinsiyetComboBox.Size = new Size(213, 36);
            cinsiyetComboBox.TabIndex = 14;
            // 
            // personelTurComboBox
            // 
            personelTurComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            personelTurComboBox.FormattingEnabled = true;
            personelTurComboBox.ItemHeight = 28;
            personelTurComboBox.Items.AddRange(new object[] { "Resepsiyonist", "Güvenlik", "Vale", "Oda Servis Elemanı", "Temizlik Görevlisi", "Garson", "Aşçı" });
            personelTurComboBox.Location = new Point(145, 376);
            personelTurComboBox.Name = "personelTurComboBox";
            personelTurComboBox.Size = new Size(213, 36);
            personelTurComboBox.TabIndex = 16;
            // 
            // personelTurLabel
            // 
            personelTurLabel.AutoSize = true;
            personelTurLabel.Location = new Point(12, 379);
            personelTurLabel.Name = "personelTurLabel";
            personelTurLabel.Size = new Size(133, 28);
            personelTurLabel.TabIndex = 15;
            personelTurLabel.Text = "Personel Türü:";
            personelTurLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // sifreTextBox
            // 
            sifreTextBox.BorderStyle = BorderStyle.FixedSingle;
            sifreTextBox.Location = new Point(145, 418);
            sifreTextBox.MaxLength = 40;
            sifreTextBox.Name = "sifreTextBox";
            sifreTextBox.PasswordChar = '*';
            sifreTextBox.Size = new Size(213, 34);
            sifreTextBox.TabIndex = 18;
            // 
            // sifreLabel
            // 
            sifreLabel.AutoSize = true;
            sifreLabel.Location = new Point(12, 421);
            sifreLabel.Name = "sifreLabel";
            sifreLabel.Size = new Size(55, 28);
            sifreLabel.TabIndex = 17;
            sifreLabel.Text = "Şifre:";
            sifreLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // adresTextBox
            // 
            adresTextBox.BorderStyle = BorderStyle.FixedSingle;
            adresTextBox.Location = new Point(145, 538);
            adresTextBox.MaxLength = 90;
            adresTextBox.Name = "adresTextBox";
            adresTextBox.Size = new Size(213, 34);
            adresTextBox.TabIndex = 24;
            // 
            // adresLabel
            // 
            adresLabel.AutoSize = true;
            adresLabel.Location = new Point(12, 541);
            adresLabel.Name = "adresLabel";
            adresLabel.Size = new Size(66, 28);
            adresLabel.TabIndex = 23;
            adresLabel.Text = "Adres:";
            adresLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ePostaTextBox
            // 
            ePostaTextBox.BorderStyle = BorderStyle.FixedSingle;
            ePostaTextBox.Location = new Point(145, 498);
            ePostaTextBox.MaxLength = 40;
            ePostaTextBox.Name = "ePostaTextBox";
            ePostaTextBox.PlaceholderText = "abc@gmail.com";
            ePostaTextBox.Size = new Size(213, 34);
            ePostaTextBox.TabIndex = 22;
            // 
            // ePostaLabel
            // 
            ePostaLabel.AutoSize = true;
            ePostaLabel.Location = new Point(12, 501);
            ePostaLabel.Name = "ePostaLabel";
            ePostaLabel.Size = new Size(81, 28);
            ePostaLabel.TabIndex = 21;
            ePostaLabel.Text = "E-Posta:";
            ePostaLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // telefonNoTextBox
            // 
            telefonNoTextBox.BorderStyle = BorderStyle.FixedSingle;
            telefonNoTextBox.Location = new Point(145, 458);
            telefonNoTextBox.MaxLength = 11;
            telefonNoTextBox.Name = "telefonNoTextBox";
            telefonNoTextBox.Size = new Size(213, 34);
            telefonNoTextBox.TabIndex = 20;
            // 
            // telefonNoLabel
            // 
            telefonNoLabel.AutoSize = true;
            telefonNoLabel.Location = new Point(12, 461);
            telefonNoLabel.Name = "telefonNoLabel";
            telefonNoLabel.Size = new Size(110, 28);
            telefonNoLabel.TabIndex = 19;
            telefonNoLabel.Text = "Telefon No:";
            telefonNoLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ilceComboBox
            // 
            ilceComboBox.DropDownHeight = 150;
            ilceComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ilceComboBox.FormattingEnabled = true;
            ilceComboBox.IntegralHeight = false;
            ilceComboBox.ItemHeight = 28;
            ilceComboBox.Items.AddRange(new object[] { "Esenyurt", "Küçükçekmece", "Bağcılar", "Pendik", "Ümraniye", "Çankaya", "Keçiören", "Yenimahalle", "Mamak", "Etimesgut", "Buca", "Karabağlar", "Bornova", "Karşıyaka", "Konak", "Osmangazi", "Yıldırım", "Nilüfer", "İnegöl", "Gemlik", "Muratpaşa", "Konyaaltı", "Kepez", "Aksu", "Döşemealtı", "Gebze", "İzmit", "Darıca", "Körfez", "Gölcük", "Adapazarı", "Serdivan", "Akyazı", "Erenler", "Hendek", "Seyhan", "Yüreğir", "Çukurova", "Sarıçam", "Ceyhan", "Şahinbey", "Şehitkamil", "Nizip", "İslahiye", "Nurdağı", "Selçuklu", "Karatay", "Meram", "Ereğli", "Akşehir" });
            ilceComboBox.Location = new Point(145, 578);
            ilceComboBox.Name = "ilceComboBox";
            ilceComboBox.Size = new Size(213, 36);
            ilceComboBox.TabIndex = 26;
            // 
            // ilceLabel
            // 
            ilceLabel.AutoSize = true;
            ilceLabel.Location = new Point(12, 581);
            ilceLabel.Name = "ilceLabel";
            ilceLabel.Size = new Size(45, 28);
            ilceLabel.TabIndex = 25;
            ilceLabel.Text = "İlçe:";
            ilceLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // personelEkleButton
            // 
            personelEkleButton.BackColor = SystemColors.ActiveCaption;
            personelEkleButton.Cursor = Cursors.Hand;
            personelEkleButton.Location = new Point(145, 620);
            personelEkleButton.Name = "personelEkleButton";
            personelEkleButton.Size = new Size(213, 41);
            personelEkleButton.TabIndex = 27;
            personelEkleButton.Text = "Personel Ekle";
            personelEkleButton.UseVisualStyleBackColor = false;
            personelEkleButton.Click += personelEkleButton_Click;
            // 
            // personellerLabel
            // 
            personellerLabel.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 162);
            personellerLabel.Location = new Point(364, 9);
            personellerLabel.Name = "personellerLabel";
            personellerLabel.Size = new Size(1047, 34);
            personellerLabel.TabIndex = 29;
            personellerLabel.Text = "~Personeller~";
            personellerLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // personellerDataGridView
            // 
            personellerDataGridView.BackgroundColor = SystemColors.ControlLight;
            personellerDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            personellerDataGridView.Location = new Point(364, 46);
            personellerDataGridView.Name = "personellerDataGridView";
            personellerDataGridView.ReadOnly = true;
            personellerDataGridView.Size = new Size(1047, 660);
            personellerDataGridView.TabIndex = 30;
            // 
            // personelGuncelleButton
            // 
            personelGuncelleButton.BackColor = SystemColors.ActiveCaption;
            personelGuncelleButton.Cursor = Cursors.Hand;
            personelGuncelleButton.Location = new Point(254, 169);
            personelGuncelleButton.Name = "personelGuncelleButton";
            personelGuncelleButton.Size = new Size(103, 39);
            personelGuncelleButton.TabIndex = 6;
            personelGuncelleButton.Text = "Güncelle";
            personelGuncelleButton.UseVisualStyleBackColor = false;
            personelGuncelleButton.Click += personelGuncelleButton_Click;
            // 
            // sicilNoTextBox
            // 
            sicilNoTextBox.BorderStyle = BorderStyle.FixedSingle;
            sicilNoTextBox.Location = new Point(145, 130);
            sicilNoTextBox.MaxLength = 11;
            sicilNoTextBox.Name = "sicilNoTextBox";
            sicilNoTextBox.Size = new Size(212, 34);
            sicilNoTextBox.TabIndex = 3;
            // 
            // sicilNoLabel
            // 
            sicilNoLabel.Location = new Point(12, 129);
            sicilNoLabel.Name = "sicilNoLabel";
            sicilNoLabel.Size = new Size(84, 34);
            sicilNoLabel.TabIndex = 4;
            sicilNoLabel.Text = "Sicil No:";
            sicilNoLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // adAraTextBox
            // 
            adAraTextBox.BorderStyle = BorderStyle.FixedSingle;
            adAraTextBox.Location = new Point(145, 46);
            adAraTextBox.MaxLength = 40;
            adAraTextBox.Name = "adAraTextBox";
            adAraTextBox.Size = new Size(212, 34);
            adAraTextBox.TabIndex = 1;
            // 
            // adAraLabel
            // 
            adAraLabel.AutoSize = true;
            adAraLabel.Location = new Point(12, 48);
            adAraLabel.Name = "adAraLabel";
            adAraLabel.Size = new Size(119, 28);
            adAraLabel.TabIndex = 0;
            adAraLabel.Text = "Personel Ad:";
            adAraLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // personelleriAraButton
            // 
            personelleriAraButton.BackColor = SystemColors.ActiveCaption;
            personelleriAraButton.Cursor = Cursors.Hand;
            personelleriAraButton.Location = new Point(145, 86);
            personelleriAraButton.Name = "personelleriAraButton";
            personelleriAraButton.Size = new Size(212, 38);
            personelleriAraButton.TabIndex = 2;
            personelleriAraButton.Text = "Ara";
            personelleriAraButton.UseVisualStyleBackColor = false;
            personelleriAraButton.Click += personelleriAraButton_Click;
            // 
            // kaydetButton
            // 
            kaydetButton.BackColor = SystemColors.ActiveCaption;
            kaydetButton.Cursor = Cursors.Hand;
            kaydetButton.Location = new Point(145, 665);
            kaydetButton.Name = "kaydetButton";
            kaydetButton.Size = new Size(213, 41);
            kaydetButton.TabIndex = 28;
            kaydetButton.Text = "Değişiklikleri Kaydet";
            kaydetButton.UseVisualStyleBackColor = false;
            kaydetButton.Click += kaydetButton_Click;
            // 
            // personelSilButton
            // 
            personelSilButton.BackColor = SystemColors.ActiveCaption;
            personelSilButton.Cursor = Cursors.Hand;
            personelSilButton.Location = new Point(145, 169);
            personelSilButton.Name = "personelSilButton";
            personelSilButton.Size = new Size(103, 39);
            personelSilButton.TabIndex = 5;
            personelSilButton.Text = "Sil";
            personelSilButton.UseVisualStyleBackColor = false;
            personelSilButton.Click += personelSilButton_Click;
            // 
            // PersonelIslemleriForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1423, 716);
            Controls.Add(personelSilButton);
            Controls.Add(kaydetButton);
            Controls.Add(personelGuncelleButton);
            Controls.Add(sicilNoTextBox);
            Controls.Add(sicilNoLabel);
            Controls.Add(adAraTextBox);
            Controls.Add(adAraLabel);
            Controls.Add(personelleriAraButton);
            Controls.Add(personellerDataGridView);
            Controls.Add(personellerLabel);
            Controls.Add(personelEkleButton);
            Controls.Add(ilceComboBox);
            Controls.Add(ilceLabel);
            Controls.Add(adresTextBox);
            Controls.Add(adresLabel);
            Controls.Add(ePostaTextBox);
            Controls.Add(ePostaLabel);
            Controls.Add(telefonNoTextBox);
            Controls.Add(telefonNoLabel);
            Controls.Add(sifreTextBox);
            Controls.Add(sifreLabel);
            Controls.Add(personelTurComboBox);
            Controls.Add(personelTurLabel);
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
            Name = "PersonelIslemleriForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Personel İşlemleri";
            Load += PersonelIslemleriForm_Load;
            ((System.ComponentModel.ISupportInitialize)personellerDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label kimlikNoLabel;
        private TextBox kimlikNoTextBox;
        private TextBox adTextBox;
        private Label adLabel;
        private TextBox soyadTextBox;
        private Label soyadLabel;
        private Label cinsiyetLabel;
        private ComboBox cinsiyetComboBox;
        private ComboBox personelTurComboBox;
        private Label personelTurLabel;
        private TextBox sifreTextBox;
        private Label sifreLabel;
        private TextBox adresTextBox;
        private Label adresLabel;
        private TextBox ePostaTextBox;
        private Label ePostaLabel;
        private TextBox telefonNoTextBox;
        private Label telefonNoLabel;
        private ComboBox ilceComboBox;
        private Label ilceLabel;
        private Button personelEkleButton;
        private Label personellerLabel;
        private DataGridView personellerDataGridView;
        private Button personelGuncelleButton;
        private TextBox sicilNoTextBox;
        private Label sicilNoLabel;
        private TextBox adAraTextBox;
        private Label adAraLabel;
        private Button personelleriAraButton;
        private Button kaydetButton;
        private Button personelSilButton;
    }
}