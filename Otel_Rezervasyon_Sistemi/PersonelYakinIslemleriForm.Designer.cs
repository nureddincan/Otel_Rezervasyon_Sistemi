namespace Otel_Rezervasyon_Sistemi
{
    partial class PersonelYakinIslemleriForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonelYakinIslemleriForm));
            personelYakiniEkleButton = new Button();
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
            personelTCTextBox = new TextBox();
            personel_idLabel = new Label();
            personelYakinlariDataGridView = new DataGridView();
            personelYakinlariLabel = new Label();
            yakinGuncelleButton = new Button();
            yakinTCTextBox = new TextBox();
            yakinTCLabel = new Label();
            yakinAdAraTextBox = new TextBox();
            yakinAdAraLabel = new Label();
            yakinAdAraButton = new Button();
            yakinSilButton = new Button();
            degisiklikleriKaydetButton = new Button();
            ((System.ComponentModel.ISupportInitialize)personelYakinlariDataGridView).BeginInit();
            SuspendLayout();
            // 
            // personelYakiniEkleButton
            // 
            personelYakiniEkleButton.BackColor = SystemColors.ActiveCaption;
            personelYakiniEkleButton.Cursor = Cursors.Hand;
            personelYakiniEkleButton.Location = new Point(122, 587);
            personelYakiniEkleButton.Name = "personelYakiniEkleButton";
            personelYakiniEkleButton.Size = new Size(213, 41);
            personelYakiniEkleButton.TabIndex = 25;
            personelYakiniEkleButton.Text = "Personel Yakını Ekle";
            personelYakiniEkleButton.UseVisualStyleBackColor = false;
            personelYakiniEkleButton.Click += personelYakiniEkleButton_Click;
            // 
            // ilceComboBox
            // 
            ilceComboBox.DropDownHeight = 150;
            ilceComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ilceComboBox.FormattingEnabled = true;
            ilceComboBox.IntegralHeight = false;
            ilceComboBox.ItemHeight = 28;
            ilceComboBox.Items.AddRange(new object[] { "Esenyurt", "Küçükçekmece", "Bağcılar", "Pendik", "Ümraniye", "Çankaya", "Keçiören", "Yenimahalle", "Mamak", "Etimesgut", "Buca", "Karabağlar", "Bornova", "Karşıyaka", "Konak", "Osmangazi", "Yıldırım", "Nilüfer", "İnegöl", "Gemlik", "Muratpaşa", "Konyaaltı", "Kepez", "Aksu", "Döşemealtı", "Gebze", "İzmit", "Darıca", "Körfez", "Gölcük", "Adapazarı", "Serdivan", "Akyazı", "Erenler", "Hendek", "Seyhan", "Yüreğir", "Çukurova", "Sarıçam", "Ceyhan", "Şahinbey", "Şehitkamil", "Nizip", "İslahiye", "Nurdağı", "Selçuklu", "Karatay", "Meram", "Ereğli", "Akşehir" });
            ilceComboBox.Location = new Point(146, 499);
            ilceComboBox.Name = "ilceComboBox";
            ilceComboBox.Size = new Size(189, 36);
            ilceComboBox.TabIndex = 22;
            // 
            // ilceLabel
            // 
            ilceLabel.AutoSize = true;
            ilceLabel.Location = new Point(12, 502);
            ilceLabel.Name = "ilceLabel";
            ilceLabel.Size = new Size(45, 28);
            ilceLabel.TabIndex = 21;
            ilceLabel.Text = "İlçe:";
            ilceLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // adresTextBox
            // 
            adresTextBox.BorderStyle = BorderStyle.FixedSingle;
            adresTextBox.Location = new Point(146, 459);
            adresTextBox.MaxLength = 90;
            adresTextBox.Name = "adresTextBox";
            adresTextBox.Size = new Size(189, 34);
            adresTextBox.TabIndex = 20;
            // 
            // adresLabel
            // 
            adresLabel.AutoSize = true;
            adresLabel.Location = new Point(12, 462);
            adresLabel.Name = "adresLabel";
            adresLabel.Size = new Size(66, 28);
            adresLabel.TabIndex = 19;
            adresLabel.Text = "Adres:";
            adresLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ePostaTextBox
            // 
            ePostaTextBox.BorderStyle = BorderStyle.FixedSingle;
            ePostaTextBox.Location = new Point(146, 419);
            ePostaTextBox.MaxLength = 40;
            ePostaTextBox.Name = "ePostaTextBox";
            ePostaTextBox.PlaceholderText = "abc@gmail.com";
            ePostaTextBox.Size = new Size(189, 34);
            ePostaTextBox.TabIndex = 18;
            // 
            // ePostaLabel
            // 
            ePostaLabel.AutoSize = true;
            ePostaLabel.Location = new Point(12, 422);
            ePostaLabel.Name = "ePostaLabel";
            ePostaLabel.Size = new Size(81, 28);
            ePostaLabel.TabIndex = 17;
            ePostaLabel.Text = "E-Posta:";
            ePostaLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // telefonNoTextBox
            // 
            telefonNoTextBox.BorderStyle = BorderStyle.FixedSingle;
            telefonNoTextBox.Location = new Point(146, 379);
            telefonNoTextBox.MaxLength = 11;
            telefonNoTextBox.Name = "telefonNoTextBox";
            telefonNoTextBox.Size = new Size(189, 34);
            telefonNoTextBox.TabIndex = 16;
            // 
            // telefonNoLabel
            // 
            telefonNoLabel.AutoSize = true;
            telefonNoLabel.Location = new Point(12, 382);
            telefonNoLabel.Name = "telefonNoLabel";
            telefonNoLabel.Size = new Size(110, 28);
            telefonNoLabel.TabIndex = 15;
            telefonNoLabel.Text = "Telefon No:";
            telefonNoLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cinsiyetComboBox
            // 
            cinsiyetComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            cinsiyetComboBox.FormattingEnabled = true;
            cinsiyetComboBox.ItemHeight = 28;
            cinsiyetComboBox.Items.AddRange(new object[] { "Erkek", "Kadın" });
            cinsiyetComboBox.Location = new Point(146, 334);
            cinsiyetComboBox.Name = "cinsiyetComboBox";
            cinsiyetComboBox.Size = new Size(189, 36);
            cinsiyetComboBox.TabIndex = 14;
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
            // soyadTextBox
            // 
            soyadTextBox.BorderStyle = BorderStyle.FixedSingle;
            soyadTextBox.Location = new Point(146, 294);
            soyadTextBox.MaxLength = 40;
            soyadTextBox.Name = "soyadTextBox";
            soyadTextBox.Size = new Size(189, 34);
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
            // adTextBox
            // 
            adTextBox.BorderStyle = BorderStyle.FixedSingle;
            adTextBox.Location = new Point(146, 254);
            adTextBox.MaxLength = 40;
            adTextBox.Name = "adTextBox";
            adTextBox.Size = new Size(189, 34);
            adTextBox.TabIndex = 10;
            // 
            // adLabel
            // 
            adLabel.AutoSize = true;
            adLabel.Location = new Point(12, 257);
            adLabel.Name = "adLabel";
            adLabel.Size = new Size(91, 28);
            adLabel.TabIndex = 9;
            adLabel.Text = "Yakın Ad:";
            adLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // kimlikNoTextBox
            // 
            kimlikNoTextBox.BorderStyle = BorderStyle.FixedSingle;
            kimlikNoTextBox.Location = new Point(146, 214);
            kimlikNoTextBox.MaxLength = 11;
            kimlikNoTextBox.Name = "kimlikNoTextBox";
            kimlikNoTextBox.Size = new Size(189, 34);
            kimlikNoTextBox.TabIndex = 8;
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
            // personelTCTextBox
            // 
            personelTCTextBox.BorderStyle = BorderStyle.FixedSingle;
            personelTCTextBox.Location = new Point(146, 541);
            personelTCTextBox.Name = "personelTCTextBox";
            personelTCTextBox.Size = new Size(189, 34);
            personelTCTextBox.TabIndex = 24;
            // 
            // personel_idLabel
            // 
            personel_idLabel.AutoSize = true;
            personel_idLabel.Location = new Point(12, 544);
            personel_idLabel.Name = "personel_idLabel";
            personel_idLabel.Size = new Size(129, 28);
            personel_idLabel.TabIndex = 23;
            personel_idLabel.Text = "Personel T.C. :";
            personel_idLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // personelYakinlariDataGridView
            // 
            personelYakinlariDataGridView.BackgroundColor = SystemColors.ControlLight;
            personelYakinlariDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            personelYakinlariDataGridView.Location = new Point(341, 43);
            personelYakinlariDataGridView.Name = "personelYakinlariDataGridView";
            personelYakinlariDataGridView.ReadOnly = true;
            personelYakinlariDataGridView.Size = new Size(903, 630);
            personelYakinlariDataGridView.TabIndex = 27;
            // 
            // personelYakinlariLabel
            // 
            personelYakinlariLabel.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 162);
            personelYakinlariLabel.Location = new Point(341, 9);
            personelYakinlariLabel.Name = "personelYakinlariLabel";
            personelYakinlariLabel.Size = new Size(903, 31);
            personelYakinlariLabel.TabIndex = 26;
            personelYakinlariLabel.Text = "~Personel Yakınları~";
            personelYakinlariLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // yakinGuncelleButton
            // 
            yakinGuncelleButton.BackColor = SystemColors.ActiveCaption;
            yakinGuncelleButton.Cursor = Cursors.Hand;
            yakinGuncelleButton.Location = new Point(237, 167);
            yakinGuncelleButton.Name = "yakinGuncelleButton";
            yakinGuncelleButton.Size = new Size(98, 41);
            yakinGuncelleButton.TabIndex = 6;
            yakinGuncelleButton.Text = "Güncelle";
            yakinGuncelleButton.UseVisualStyleBackColor = false;
            yakinGuncelleButton.Click += yakinGuncelleButton_Click;
            // 
            // yakinTCTextBox
            // 
            yakinTCTextBox.BorderStyle = BorderStyle.FixedSingle;
            yakinTCTextBox.Location = new Point(146, 128);
            yakinTCTextBox.Name = "yakinTCTextBox";
            yakinTCTextBox.Size = new Size(189, 34);
            yakinTCTextBox.TabIndex = 4;
            // 
            // yakinTCLabel
            // 
            yakinTCLabel.AutoSize = true;
            yakinTCLabel.Location = new Point(12, 130);
            yakinTCLabel.Name = "yakinTCLabel";
            yakinTCLabel.Size = new Size(101, 28);
            yakinTCLabel.TabIndex = 3;
            yakinTCLabel.Text = "Yakın T.C. :";
            yakinTCLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // yakinAdAraTextBox
            // 
            yakinAdAraTextBox.BorderStyle = BorderStyle.FixedSingle;
            yakinAdAraTextBox.Location = new Point(146, 43);
            yakinAdAraTextBox.MaxLength = 40;
            yakinAdAraTextBox.Name = "yakinAdAraTextBox";
            yakinAdAraTextBox.Size = new Size(189, 34);
            yakinAdAraTextBox.TabIndex = 1;
            // 
            // yakinAdAraLabel
            // 
            yakinAdAraLabel.AutoSize = true;
            yakinAdAraLabel.Location = new Point(12, 45);
            yakinAdAraLabel.Name = "yakinAdAraLabel";
            yakinAdAraLabel.Size = new Size(91, 28);
            yakinAdAraLabel.TabIndex = 0;
            yakinAdAraLabel.Text = "Yakın Ad:";
            yakinAdAraLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // yakinAdAraButton
            // 
            yakinAdAraButton.BackColor = SystemColors.ActiveCaption;
            yakinAdAraButton.Cursor = Cursors.Hand;
            yakinAdAraButton.Location = new Point(146, 83);
            yakinAdAraButton.Name = "yakinAdAraButton";
            yakinAdAraButton.Size = new Size(189, 41);
            yakinAdAraButton.TabIndex = 2;
            yakinAdAraButton.Text = "Ara";
            yakinAdAraButton.UseVisualStyleBackColor = false;
            yakinAdAraButton.Click += yakinAdAraButton_Click;
            // 
            // yakinSilButton
            // 
            yakinSilButton.BackColor = SystemColors.ActiveCaption;
            yakinSilButton.Cursor = Cursors.Hand;
            yakinSilButton.Location = new Point(146, 167);
            yakinSilButton.Name = "yakinSilButton";
            yakinSilButton.Size = new Size(85, 41);
            yakinSilButton.TabIndex = 5;
            yakinSilButton.Text = "Sil";
            yakinSilButton.UseVisualStyleBackColor = false;
            yakinSilButton.Click += yakinSilButton_Click;
            // 
            // degisiklikleriKaydetButton
            // 
            degisiklikleriKaydetButton.BackColor = SystemColors.ActiveCaption;
            degisiklikleriKaydetButton.Cursor = Cursors.Hand;
            degisiklikleriKaydetButton.Location = new Point(122, 632);
            degisiklikleriKaydetButton.Name = "degisiklikleriKaydetButton";
            degisiklikleriKaydetButton.Size = new Size(213, 41);
            degisiklikleriKaydetButton.TabIndex = 28;
            degisiklikleriKaydetButton.Text = "Değişiklikleri Kaydet";
            degisiklikleriKaydetButton.UseVisualStyleBackColor = false;
            degisiklikleriKaydetButton.Click += degisiklikleriKaydetButton_Click;
            // 
            // PersonelYakinIslemleriForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1256, 685);
            Controls.Add(degisiklikleriKaydetButton);
            Controls.Add(yakinSilButton);
            Controls.Add(yakinGuncelleButton);
            Controls.Add(yakinTCTextBox);
            Controls.Add(yakinTCLabel);
            Controls.Add(yakinAdAraTextBox);
            Controls.Add(yakinAdAraLabel);
            Controls.Add(yakinAdAraButton);
            Controls.Add(personelYakinlariDataGridView);
            Controls.Add(personelYakinlariLabel);
            Controls.Add(personelTCTextBox);
            Controls.Add(personel_idLabel);
            Controls.Add(personelYakiniEkleButton);
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
            Name = "PersonelYakinIslemleriForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Personel Yakın İşlemleri";
            Load += PersonelYakinIslemleriForm_Load;
            ((System.ComponentModel.ISupportInitialize)personelYakinlariDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button personelYakiniEkleButton;
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
        private TextBox personelTCTextBox;
        private Label personel_idLabel;
        private DataGridView personelYakinlariDataGridView;
        private Label personelYakinlariLabel;
        private Button yakinGuncelleButton;
        private TextBox yakinTCTextBox;
        private Label yakinTCLabel;
        private TextBox yakinAdAraTextBox;
        private Label yakinAdAraLabel;
        private Button yakinAdAraButton;
        private Button yakinSilButton;
        private Button degisiklikleriKaydetButton;
    }
}