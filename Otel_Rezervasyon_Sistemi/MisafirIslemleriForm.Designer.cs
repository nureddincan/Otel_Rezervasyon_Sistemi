namespace Otel_Rezervasyon_Sistemi
{
    partial class MisafirIslemleriForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MisafirIslemleriForm));
            degisiklikleriKaydetButton = new Button();
            misafirGuncelleButton = new Button();
            misafirlerDataGridView = new DataGridView();
            misafirLabel = new Label();
            misafirSilGuncelleKimlikNoTextBox = new TextBox();
            misafirSilGuncelleKimlikNoNoLabel = new Label();
            adAraTextBox = new TextBox();
            adAraLabel = new Label();
            misafirAraButton = new Button();
            misafirSilButton = new Button();
            misafirEkleButton = new Button();
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
            musteriKimlikNoTextBox = new TextBox();
            musteriKimlikNoLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)misafirlerDataGridView).BeginInit();
            SuspendLayout();
            // 
            // degisiklikleriKaydetButton
            // 
            degisiklikleriKaydetButton.BackColor = SystemColors.ActiveCaption;
            degisiklikleriKaydetButton.Cursor = Cursors.Hand;
            degisiklikleriKaydetButton.Location = new Point(119, 630);
            degisiklikleriKaydetButton.Name = "degisiklikleriKaydetButton";
            degisiklikleriKaydetButton.Size = new Size(206, 41);
            degisiklikleriKaydetButton.TabIndex = 27;
            degisiklikleriKaydetButton.Text = "Değişiklikleri Kaydet";
            degisiklikleriKaydetButton.UseVisualStyleBackColor = false;
            degisiklikleriKaydetButton.Click += degisiklikleriKaydetButton_Click;
            // 
            // misafirGuncelleButton
            // 
            misafirGuncelleButton.BackColor = SystemColors.ActiveCaption;
            misafirGuncelleButton.Cursor = Cursors.Hand;
            misafirGuncelleButton.Location = new Point(119, 169);
            misafirGuncelleButton.Name = "misafirGuncelleButton";
            misafirGuncelleButton.Size = new Size(103, 41);
            misafirGuncelleButton.TabIndex = 6;
            misafirGuncelleButton.Text = "Güncelle";
            misafirGuncelleButton.UseVisualStyleBackColor = false;
            misafirGuncelleButton.Click += misafirGuncelleButton_Click;
            // 
            // misafirlerDataGridView
            // 
            misafirlerDataGridView.BackgroundColor = SystemColors.ControlLight;
            misafirlerDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            misafirlerDataGridView.Location = new Point(331, 42);
            misafirlerDataGridView.Name = "misafirlerDataGridView";
            misafirlerDataGridView.ReadOnly = true;
            misafirlerDataGridView.Size = new Size(903, 629);
            misafirlerDataGridView.TabIndex = 29;
            // 
            // misafirLabel
            // 
            misafirLabel.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 162);
            misafirLabel.Location = new Point(331, 9);
            misafirLabel.Name = "misafirLabel";
            misafirLabel.Size = new Size(903, 30);
            misafirLabel.TabIndex = 28;
            misafirLabel.Text = "~Misafirler~";
            misafirLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // misafirSilGuncelleKimlikNoTextBox
            // 
            misafirSilGuncelleKimlikNoTextBox.BorderStyle = BorderStyle.FixedSingle;
            misafirSilGuncelleKimlikNoTextBox.Location = new Point(119, 129);
            misafirSilGuncelleKimlikNoTextBox.MaxLength = 11;
            misafirSilGuncelleKimlikNoTextBox.Name = "misafirSilGuncelleKimlikNoTextBox";
            misafirSilGuncelleKimlikNoTextBox.Size = new Size(206, 34);
            misafirSilGuncelleKimlikNoTextBox.TabIndex = 5;
            // 
            // misafirSilGuncelleKimlikNoNoLabel
            // 
            misafirSilGuncelleKimlikNoNoLabel.Location = new Point(11, 128);
            misafirSilGuncelleKimlikNoNoLabel.Name = "misafirSilGuncelleKimlikNoNoLabel";
            misafirSilGuncelleKimlikNoNoLabel.Size = new Size(110, 34);
            misafirSilGuncelleKimlikNoNoLabel.TabIndex = 4;
            misafirSilGuncelleKimlikNoNoLabel.Text = "Kimlik No:";
            misafirSilGuncelleKimlikNoNoLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // adAraTextBox
            // 
            adAraTextBox.BorderStyle = BorderStyle.FixedSingle;
            adAraTextBox.Location = new Point(119, 42);
            adAraTextBox.MaxLength = 40;
            adAraTextBox.Name = "adAraTextBox";
            adAraTextBox.Size = new Size(206, 34);
            adAraTextBox.TabIndex = 2;
            // 
            // adAraLabel
            // 
            adAraLabel.Location = new Point(11, 42);
            adAraLabel.Name = "adAraLabel";
            adAraLabel.Size = new Size(110, 34);
            adAraLabel.TabIndex = 1;
            adAraLabel.Text = "Misafir Ad:";
            adAraLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // misafirAraButton
            // 
            misafirAraButton.BackColor = SystemColors.ActiveCaption;
            misafirAraButton.Cursor = Cursors.Hand;
            misafirAraButton.Location = new Point(119, 82);
            misafirAraButton.Name = "misafirAraButton";
            misafirAraButton.Size = new Size(206, 41);
            misafirAraButton.TabIndex = 3;
            misafirAraButton.Text = "Ara";
            misafirAraButton.UseVisualStyleBackColor = false;
            misafirAraButton.Click += misafirAraButton_Click;
            // 
            // misafirSilButton
            // 
            misafirSilButton.BackColor = SystemColors.ActiveCaption;
            misafirSilButton.Cursor = Cursors.Hand;
            misafirSilButton.Location = new Point(228, 169);
            misafirSilButton.Name = "misafirSilButton";
            misafirSilButton.Size = new Size(97, 41);
            misafirSilButton.TabIndex = 7;
            misafirSilButton.Text = "Sil";
            misafirSilButton.UseVisualStyleBackColor = false;
            misafirSilButton.Click += misafirSilButton_Click;
            // 
            // misafirEkleButton
            // 
            misafirEkleButton.BackColor = SystemColors.ActiveCaption;
            misafirEkleButton.Cursor = Cursors.Hand;
            misafirEkleButton.Location = new Point(119, 583);
            misafirEkleButton.Name = "misafirEkleButton";
            misafirEkleButton.Size = new Size(206, 41);
            misafirEkleButton.TabIndex = 26;
            misafirEkleButton.Text = "Yeni Misafir Ekle";
            misafirEkleButton.UseVisualStyleBackColor = false;
            misafirEkleButton.Click += misafirEkleButton_Click;
            // 
            // ilceComboBox
            // 
            ilceComboBox.DropDownHeight = 150;
            ilceComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            ilceComboBox.FormattingEnabled = true;
            ilceComboBox.IntegralHeight = false;
            ilceComboBox.ItemHeight = 28;
            ilceComboBox.Items.AddRange(new object[] { "Esenyurt", "Küçükçekmece", "Bağcılar", "Pendik", "Ümraniye", "Çankaya", "Keçiören", "Yenimahalle", "Mamak", "Etimesgut", "Buca", "Karabağlar", "Bornova", "Karşıyaka", "Konak", "Osmangazi", "Yıldırım", "Nilüfer", "İnegöl", "Gemlik", "Muratpaşa", "Konyaaltı", "Kepez", "Aksu", "Döşemealtı", "Gebze", "İzmit", "Darıca", "Körfez", "Gölcük", "Adapazarı", "Serdivan", "Akyazı", "Erenler", "Hendek", "Seyhan", "Yüreğir", "Çukurova", "Sarıçam", "Ceyhan", "Şahinbey", "Şehitkamil", "Nizip", "İslahiye", "Nurdağı", "Selçuklu", "Karatay", "Meram", "Ereğli", "Akşehir" });
            ilceComboBox.Location = new Point(119, 501);
            ilceComboBox.Name = "ilceComboBox";
            ilceComboBox.Size = new Size(206, 36);
            ilceComboBox.TabIndex = 23;
            // 
            // ilceLabel
            // 
            ilceLabel.AutoSize = true;
            ilceLabel.Location = new Point(11, 504);
            ilceLabel.Name = "ilceLabel";
            ilceLabel.Size = new Size(45, 28);
            ilceLabel.TabIndex = 22;
            ilceLabel.Text = "İlçe:";
            ilceLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // adresTextBox
            // 
            adresTextBox.BorderStyle = BorderStyle.FixedSingle;
            adresTextBox.Location = new Point(119, 461);
            adresTextBox.MaxLength = 90;
            adresTextBox.Name = "adresTextBox";
            adresTextBox.Size = new Size(206, 34);
            adresTextBox.TabIndex = 21;
            // 
            // adresLabel
            // 
            adresLabel.AutoSize = true;
            adresLabel.Location = new Point(11, 463);
            adresLabel.Name = "adresLabel";
            adresLabel.Size = new Size(66, 28);
            adresLabel.TabIndex = 20;
            adresLabel.Text = "Adres:";
            adresLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ePostaTextBox
            // 
            ePostaTextBox.BorderStyle = BorderStyle.FixedSingle;
            ePostaTextBox.Location = new Point(119, 421);
            ePostaTextBox.MaxLength = 40;
            ePostaTextBox.Name = "ePostaTextBox";
            ePostaTextBox.PlaceholderText = "abc@gmail.com";
            ePostaTextBox.Size = new Size(206, 34);
            ePostaTextBox.TabIndex = 19;
            // 
            // ePostaLabel
            // 
            ePostaLabel.AutoSize = true;
            ePostaLabel.Location = new Point(11, 423);
            ePostaLabel.Name = "ePostaLabel";
            ePostaLabel.Size = new Size(81, 28);
            ePostaLabel.TabIndex = 18;
            ePostaLabel.Text = "E-Posta:";
            ePostaLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // telefonNoTextBox
            // 
            telefonNoTextBox.BorderStyle = BorderStyle.FixedSingle;
            telefonNoTextBox.Location = new Point(119, 381);
            telefonNoTextBox.MaxLength = 11;
            telefonNoTextBox.Name = "telefonNoTextBox";
            telefonNoTextBox.Size = new Size(206, 34);
            telefonNoTextBox.TabIndex = 17;
            // 
            // telefonNoLabel
            // 
            telefonNoLabel.AutoSize = true;
            telefonNoLabel.Location = new Point(11, 383);
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
            cinsiyetComboBox.Location = new Point(119, 336);
            cinsiyetComboBox.Name = "cinsiyetComboBox";
            cinsiyetComboBox.Size = new Size(206, 36);
            cinsiyetComboBox.TabIndex = 15;
            // 
            // cinsiyetLabel
            // 
            cinsiyetLabel.AutoSize = true;
            cinsiyetLabel.Location = new Point(11, 339);
            cinsiyetLabel.Name = "cinsiyetLabel";
            cinsiyetLabel.Size = new Size(84, 28);
            cinsiyetLabel.TabIndex = 14;
            cinsiyetLabel.Text = "Cinsiyet:";
            cinsiyetLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // soyadTextBox
            // 
            soyadTextBox.BorderStyle = BorderStyle.FixedSingle;
            soyadTextBox.Location = new Point(119, 296);
            soyadTextBox.MaxLength = 40;
            soyadTextBox.Name = "soyadTextBox";
            soyadTextBox.Size = new Size(206, 34);
            soyadTextBox.TabIndex = 13;
            // 
            // soyadLabel
            // 
            soyadLabel.AutoSize = true;
            soyadLabel.Location = new Point(11, 298);
            soyadLabel.Name = "soyadLabel";
            soyadLabel.Size = new Size(71, 28);
            soyadLabel.TabIndex = 12;
            soyadLabel.Text = "Soyad:";
            soyadLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // adTextBox
            // 
            adTextBox.BorderStyle = BorderStyle.FixedSingle;
            adTextBox.Location = new Point(119, 256);
            adTextBox.MaxLength = 40;
            adTextBox.Name = "adTextBox";
            adTextBox.Size = new Size(206, 34);
            adTextBox.TabIndex = 11;
            // 
            // adLabel
            // 
            adLabel.AutoSize = true;
            adLabel.Location = new Point(11, 258);
            adLabel.Name = "adLabel";
            adLabel.Size = new Size(105, 28);
            adLabel.TabIndex = 10;
            adLabel.Text = "Misafir Ad:";
            adLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // kimlikNoTextBox
            // 
            kimlikNoTextBox.BorderStyle = BorderStyle.FixedSingle;
            kimlikNoTextBox.Location = new Point(119, 216);
            kimlikNoTextBox.MaxLength = 11;
            kimlikNoTextBox.Name = "kimlikNoTextBox";
            kimlikNoTextBox.Size = new Size(206, 34);
            kimlikNoTextBox.TabIndex = 9;
            // 
            // kimlikNoLabel
            // 
            kimlikNoLabel.AutoSize = true;
            kimlikNoLabel.Location = new Point(11, 218);
            kimlikNoLabel.Name = "kimlikNoLabel";
            kimlikNoLabel.Size = new Size(102, 28);
            kimlikNoLabel.TabIndex = 8;
            kimlikNoLabel.Text = "Kimlik No:";
            kimlikNoLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // musteriKimlikNoTextBox
            // 
            musteriKimlikNoTextBox.BorderStyle = BorderStyle.FixedSingle;
            musteriKimlikNoTextBox.Location = new Point(189, 543);
            musteriKimlikNoTextBox.MaxLength = 11;
            musteriKimlikNoTextBox.Name = "musteriKimlikNoTextBox";
            musteriKimlikNoTextBox.Size = new Size(136, 34);
            musteriKimlikNoTextBox.TabIndex = 25;
            // 
            // musteriKimlikNoLabel
            // 
            musteriKimlikNoLabel.AutoSize = true;
            musteriKimlikNoLabel.Location = new Point(11, 545);
            musteriKimlikNoLabel.Name = "musteriKimlikNoLabel";
            musteriKimlikNoLabel.Size = new Size(173, 28);
            musteriKimlikNoLabel.TabIndex = 24;
            musteriKimlikNoLabel.Text = "Müşteri Kimlik No:";
            musteriKimlikNoLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MisafirIslemleriForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1245, 679);
            Controls.Add(musteriKimlikNoTextBox);
            Controls.Add(musteriKimlikNoLabel);
            Controls.Add(degisiklikleriKaydetButton);
            Controls.Add(misafirGuncelleButton);
            Controls.Add(misafirlerDataGridView);
            Controls.Add(misafirLabel);
            Controls.Add(misafirSilGuncelleKimlikNoTextBox);
            Controls.Add(misafirSilGuncelleKimlikNoNoLabel);
            Controls.Add(adAraTextBox);
            Controls.Add(adAraLabel);
            Controls.Add(misafirAraButton);
            Controls.Add(misafirSilButton);
            Controls.Add(misafirEkleButton);
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
            Name = "MisafirIslemleriForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Misafir İşlemleri";
            Load += MisafirIslemleriForm_Load;
            ((System.ComponentModel.ISupportInitialize)misafirlerDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button degisiklikleriKaydetButton;
        private Button misafirGuncelleButton;
        private DataGridView misafirlerDataGridView;
        private Label misafirLabel;
        private TextBox misafirSilGuncelleKimlikNoTextBox;
        private Label misafirSilGuncelleKimlikNoNoLabel;
        private TextBox adAraTextBox;
        private Label adAraLabel;
        private Button misafirAraButton;
        private Button misafirSilButton;
        private Button misafirEkleButton;
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
        private TextBox musteriKimlikNoTextBox;
        private Label musteriKimlikNoLabel;
    }
}