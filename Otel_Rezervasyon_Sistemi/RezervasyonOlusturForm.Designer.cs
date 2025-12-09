namespace Otel_Rezervasyon_Sistemi
{
    partial class RezervasyonOlusturForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RezervasyonOlusturForm));
            musteriKimlikNoLabel = new Label();
            rezervasyonOlusturButton = new Button();
            girisDateTimePicker = new DateTimePicker();
            girisTarihiLabel = new Label();
            cikisTarihiLabel = new Label();
            cikisDateTimePicker = new DateTimePicker();
            odaNoComboBox = new ComboBox();
            odaNoLabel = new Label();
            misafirSayisiLabel = new Label();
            misafirSayisiNumericUpDown = new NumericUpDown();
            misafirKimlikNoLabel1 = new Label();
            misafirKimlikNoLabel2 = new Label();
            misafirKimlikNoComboBox1 = new ComboBox();
            misafirKimlikNoComboBox2 = new ComboBox();
            rezervasyonlarDataGridView = new DataGridView();
            rezervasyonlarLabel = new Label();
            musteriKimlikNoComboBox = new ComboBox();
            kahvaltiCheckBox = new CheckBox();
            ogleYemegiCheckBox = new CheckBox();
            aksamYemegiCheckBox = new CheckBox();
            odaServisiCheckBox = new CheckBox();
            odaTemizligiCheckBox = new CheckBox();
            rezervasyonIDTextBox = new TextBox();
            rezervasyonIDLabel = new Label();
            faturaOlusturButton = new Button();
            ((System.ComponentModel.ISupportInitialize)misafirSayisiNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rezervasyonlarDataGridView).BeginInit();
            SuspendLayout();
            // 
            // musteriKimlikNoLabel
            // 
            musteriKimlikNoLabel.AutoSize = true;
            musteriKimlikNoLabel.Location = new Point(15, 51);
            musteriKimlikNoLabel.Name = "musteriKimlikNoLabel";
            musteriKimlikNoLabel.Size = new Size(122, 28);
            musteriKimlikNoLabel.TabIndex = 1;
            musteriKimlikNoLabel.Text = "Müşteri T.C. :";
            musteriKimlikNoLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // rezervasyonOlusturButton
            // 
            rezervasyonOlusturButton.BackColor = SystemColors.ActiveCaption;
            rezervasyonOlusturButton.Cursor = Cursors.Hand;
            rezervasyonOlusturButton.Location = new Point(168, 526);
            rezervasyonOlusturButton.Name = "rezervasyonOlusturButton";
            rezervasyonOlusturButton.Size = new Size(199, 41);
            rezervasyonOlusturButton.TabIndex = 20;
            rezervasyonOlusturButton.Text = "Rezervasyon Oluştur";
            rezervasyonOlusturButton.UseVisualStyleBackColor = false;
            rezervasyonOlusturButton.Click += rezervasyonOlusturButton_Click;
            // 
            // girisDateTimePicker
            // 
            girisDateTimePicker.Location = new Point(142, 90);
            girisDateTimePicker.Name = "girisDateTimePicker";
            girisDateTimePicker.Size = new Size(225, 34);
            girisDateTimePicker.TabIndex = 4;
            girisDateTimePicker.ValueChanged += TarihDegisti;
            // 
            // girisTarihiLabel
            // 
            girisTarihiLabel.AutoSize = true;
            girisTarihiLabel.Location = new Point(15, 95);
            girisTarihiLabel.Name = "girisTarihiLabel";
            girisTarihiLabel.Size = new Size(106, 28);
            girisTarihiLabel.TabIndex = 3;
            girisTarihiLabel.Text = "Giriş Tarihi:";
            girisTarihiLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cikisTarihiLabel
            // 
            cikisTarihiLabel.AutoSize = true;
            cikisTarihiLabel.Location = new Point(15, 135);
            cikisTarihiLabel.Name = "cikisTarihiLabel";
            cikisTarihiLabel.Size = new Size(107, 28);
            cikisTarihiLabel.TabIndex = 5;
            cikisTarihiLabel.Text = "Çıkış Tarihi:";
            cikisTarihiLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cikisDateTimePicker
            // 
            cikisDateTimePicker.Location = new Point(142, 130);
            cikisDateTimePicker.Name = "cikisDateTimePicker";
            cikisDateTimePicker.Size = new Size(225, 34);
            cikisDateTimePicker.TabIndex = 6;
            cikisDateTimePicker.ValueChanged += TarihDegisti;
            // 
            // odaNoComboBox
            // 
            odaNoComboBox.DropDownHeight = 150;
            odaNoComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            odaNoComboBox.FormattingEnabled = true;
            odaNoComboBox.IntegralHeight = false;
            odaNoComboBox.ItemHeight = 28;
            odaNoComboBox.Location = new Point(142, 294);
            odaNoComboBox.Name = "odaNoComboBox";
            odaNoComboBox.Size = new Size(225, 36);
            odaNoComboBox.TabIndex = 14;
            // 
            // odaNoLabel
            // 
            odaNoLabel.AutoSize = true;
            odaNoLabel.Location = new Point(15, 297);
            odaNoLabel.Name = "odaNoLabel";
            odaNoLabel.Size = new Size(85, 28);
            odaNoLabel.TabIndex = 13;
            odaNoLabel.Text = "Oda No:";
            odaNoLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // misafirSayisiLabel
            // 
            misafirSayisiLabel.AutoSize = true;
            misafirSayisiLabel.Location = new Point(15, 172);
            misafirSayisiLabel.Name = "misafirSayisiLabel";
            misafirSayisiLabel.Size = new Size(129, 28);
            misafirSayisiLabel.TabIndex = 7;
            misafirSayisiLabel.Text = "Misafir Sayısı:";
            misafirSayisiLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // misafirSayisiNumericUpDown
            // 
            misafirSayisiNumericUpDown.Location = new Point(142, 170);
            misafirSayisiNumericUpDown.Margin = new Padding(20, 39, 20, 39);
            misafirSayisiNumericUpDown.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            misafirSayisiNumericUpDown.Name = "misafirSayisiNumericUpDown";
            misafirSayisiNumericUpDown.Size = new Size(225, 34);
            misafirSayisiNumericUpDown.TabIndex = 8;
            misafirSayisiNumericUpDown.ValueChanged += misafirSayisiNumericUpDown_ValueChanged;
            // 
            // misafirKimlikNoLabel1
            // 
            misafirKimlikNoLabel1.AutoSize = true;
            misafirKimlikNoLabel1.Location = new Point(15, 213);
            misafirKimlikNoLabel1.Name = "misafirKimlikNoLabel1";
            misafirKimlikNoLabel1.Size = new Size(90, 28);
            misafirKimlikNoLabel1.TabIndex = 9;
            misafirKimlikNoLabel1.Text = "1.Misafir:";
            misafirKimlikNoLabel1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // misafirKimlikNoLabel2
            // 
            misafirKimlikNoLabel2.AutoSize = true;
            misafirKimlikNoLabel2.Location = new Point(15, 255);
            misafirKimlikNoLabel2.Name = "misafirKimlikNoLabel2";
            misafirKimlikNoLabel2.Size = new Size(90, 28);
            misafirKimlikNoLabel2.TabIndex = 11;
            misafirKimlikNoLabel2.Text = "2.Misafir:";
            misafirKimlikNoLabel2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // misafirKimlikNoComboBox1
            // 
            misafirKimlikNoComboBox1.FormattingEnabled = true;
            misafirKimlikNoComboBox1.Location = new Point(142, 210);
            misafirKimlikNoComboBox1.MaxLength = 11;
            misafirKimlikNoComboBox1.Name = "misafirKimlikNoComboBox1";
            misafirKimlikNoComboBox1.Size = new Size(225, 36);
            misafirKimlikNoComboBox1.TabIndex = 10;
            // 
            // misafirKimlikNoComboBox2
            // 
            misafirKimlikNoComboBox2.FormattingEnabled = true;
            misafirKimlikNoComboBox2.Location = new Point(142, 252);
            misafirKimlikNoComboBox2.MaxLength = 11;
            misafirKimlikNoComboBox2.Name = "misafirKimlikNoComboBox2";
            misafirKimlikNoComboBox2.Size = new Size(225, 36);
            misafirKimlikNoComboBox2.TabIndex = 12;
            // 
            // rezervasyonlarDataGridView
            // 
            rezervasyonlarDataGridView.BackgroundColor = SystemColors.ControlLight;
            rezervasyonlarDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            rezervasyonlarDataGridView.Location = new Point(373, 48);
            rezervasyonlarDataGridView.Name = "rezervasyonlarDataGridView";
            rezervasyonlarDataGridView.ReadOnly = true;
            rezervasyonlarDataGridView.Size = new Size(886, 606);
            rezervasyonlarDataGridView.TabIndex = 25;
            // 
            // rezervasyonlarLabel
            // 
            rezervasyonlarLabel.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 162);
            rezervasyonlarLabel.Location = new Point(373, 9);
            rezervasyonlarLabel.Name = "rezervasyonlarLabel";
            rezervasyonlarLabel.Size = new Size(886, 36);
            rezervasyonlarLabel.TabIndex = 24;
            rezervasyonlarLabel.Text = "~Rezervasyonlar~";
            rezervasyonlarLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // musteriKimlikNoComboBox
            // 
            musteriKimlikNoComboBox.FormattingEnabled = true;
            musteriKimlikNoComboBox.Location = new Point(142, 48);
            musteriKimlikNoComboBox.MaxLength = 11;
            musteriKimlikNoComboBox.Name = "musteriKimlikNoComboBox";
            musteriKimlikNoComboBox.Size = new Size(225, 36);
            musteriKimlikNoComboBox.TabIndex = 2;
            musteriKimlikNoComboBox.SelectedIndexChanged += musteriKimlikNoComboBox_SelectedIndexChanged;
            // 
            // kahvaltiCheckBox
            // 
            kahvaltiCheckBox.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 162);
            kahvaltiCheckBox.Location = new Point(15, 336);
            kahvaltiCheckBox.Name = "kahvaltiCheckBox";
            kahvaltiCheckBox.Size = new Size(352, 32);
            kahvaltiCheckBox.TabIndex = 15;
            kahvaltiCheckBox.Text = "Kahvaltı (Günlük 1 Kişi 300TL)";
            kahvaltiCheckBox.UseVisualStyleBackColor = true;
            // 
            // ogleYemegiCheckBox
            // 
            ogleYemegiCheckBox.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 162);
            ogleYemegiCheckBox.Location = new Point(15, 374);
            ogleYemegiCheckBox.Name = "ogleYemegiCheckBox";
            ogleYemegiCheckBox.Size = new Size(352, 32);
            ogleYemegiCheckBox.TabIndex = 16;
            ogleYemegiCheckBox.Text = "Öğle Yemeği (Günlük 1 Kişi 300TL)";
            ogleYemegiCheckBox.UseVisualStyleBackColor = true;
            // 
            // aksamYemegiCheckBox
            // 
            aksamYemegiCheckBox.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 162);
            aksamYemegiCheckBox.Location = new Point(15, 412);
            aksamYemegiCheckBox.Name = "aksamYemegiCheckBox";
            aksamYemegiCheckBox.Size = new Size(352, 32);
            aksamYemegiCheckBox.TabIndex = 17;
            aksamYemegiCheckBox.Text = "Akşam Yemeği (Günlük 1 Kişi 500TL)";
            aksamYemegiCheckBox.UseVisualStyleBackColor = true;
            // 
            // odaServisiCheckBox
            // 
            odaServisiCheckBox.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 162);
            odaServisiCheckBox.Location = new Point(15, 450);
            odaServisiCheckBox.Name = "odaServisiCheckBox";
            odaServisiCheckBox.Size = new Size(352, 32);
            odaServisiCheckBox.TabIndex = 18;
            odaServisiCheckBox.Text = "Oda Servisi (Günlük 1 Kişi 1000TL)";
            odaServisiCheckBox.UseVisualStyleBackColor = true;
            // 
            // odaTemizligiCheckBox
            // 
            odaTemizligiCheckBox.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 162);
            odaTemizligiCheckBox.Location = new Point(15, 488);
            odaTemizligiCheckBox.Name = "odaTemizligiCheckBox";
            odaTemizligiCheckBox.Size = new Size(352, 32);
            odaTemizligiCheckBox.TabIndex = 19;
            odaTemizligiCheckBox.Text = "Oda Temizliği (Günlük 300TL)";
            odaTemizligiCheckBox.UseVisualStyleBackColor = true;
            // 
            // rezervasyonIDTextBox
            // 
            rezervasyonIDTextBox.BorderStyle = BorderStyle.FixedSingle;
            rezervasyonIDTextBox.Location = new Point(168, 573);
            rezervasyonIDTextBox.Name = "rezervasyonIDTextBox";
            rezervasyonIDTextBox.Size = new Size(199, 34);
            rezervasyonIDTextBox.TabIndex = 22;
            // 
            // rezervasyonIDLabel
            // 
            rezervasyonIDLabel.AutoSize = true;
            rezervasyonIDLabel.Location = new Point(15, 576);
            rezervasyonIDLabel.Name = "rezervasyonIDLabel";
            rezervasyonIDLabel.Size = new Size(148, 28);
            rezervasyonIDLabel.TabIndex = 21;
            rezervasyonIDLabel.Text = "Rezervasyon ID:";
            // 
            // faturaOlusturButton
            // 
            faturaOlusturButton.BackColor = SystemColors.ActiveCaption;
            faturaOlusturButton.Cursor = Cursors.Hand;
            faturaOlusturButton.Location = new Point(168, 613);
            faturaOlusturButton.Name = "faturaOlusturButton";
            faturaOlusturButton.Size = new Size(199, 41);
            faturaOlusturButton.TabIndex = 23;
            faturaOlusturButton.Text = "Fatura Oluştur";
            faturaOlusturButton.UseVisualStyleBackColor = false;
            faturaOlusturButton.Click += faturaOlusturButton_Click;
            // 
            // RezervasyonOlusturForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1271, 663);
            Controls.Add(faturaOlusturButton);
            Controls.Add(rezervasyonIDLabel);
            Controls.Add(rezervasyonIDTextBox);
            Controls.Add(odaTemizligiCheckBox);
            Controls.Add(odaServisiCheckBox);
            Controls.Add(aksamYemegiCheckBox);
            Controls.Add(ogleYemegiCheckBox);
            Controls.Add(kahvaltiCheckBox);
            Controls.Add(musteriKimlikNoComboBox);
            Controls.Add(rezervasyonlarLabel);
            Controls.Add(rezervasyonlarDataGridView);
            Controls.Add(misafirKimlikNoComboBox2);
            Controls.Add(misafirKimlikNoComboBox1);
            Controls.Add(misafirKimlikNoLabel2);
            Controls.Add(misafirKimlikNoLabel1);
            Controls.Add(misafirSayisiNumericUpDown);
            Controls.Add(misafirSayisiLabel);
            Controls.Add(odaNoComboBox);
            Controls.Add(odaNoLabel);
            Controls.Add(cikisTarihiLabel);
            Controls.Add(cikisDateTimePicker);
            Controls.Add(girisTarihiLabel);
            Controls.Add(girisDateTimePicker);
            Controls.Add(rezervasyonOlusturButton);
            Controls.Add(musteriKimlikNoLabel);
            Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 162);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 6, 5, 6);
            MaximizeBox = false;
            Name = "RezervasyonOlusturForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Rezervasyon Oluştur";
            Load += RezervasyonOlusturForm_Load;
            ((System.ComponentModel.ISupportInitialize)misafirSayisiNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)rezervasyonlarDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label musteriKimlikNoLabel;
        private Button rezervasyonOlusturButton;
        private DateTimePicker girisDateTimePicker;
        private Label girisTarihiLabel;
        private Label cikisTarihiLabel;
        private DateTimePicker cikisDateTimePicker;
        private ComboBox odaNoComboBox;
        private Label odaNoLabel;
        private Label misafirSayisiLabel;
        private NumericUpDown misafirSayisiNumericUpDown;
        private Label misafirKimlikNoLabel1;
        private Label misafirKimlikNoLabel2;
        private ComboBox misafirKimlikNoComboBox1;
        private ComboBox misafirKimlikNoComboBox2;
        private DataGridView rezervasyonlarDataGridView;
        private Label rezervasyonlarLabel;
        private ComboBox musteriKimlikNoComboBox;
        private CheckedListBox checkedListBox1;
        private CheckBox kahvaltiCheckBox;
        private CheckBox ogleYemegiCheckBox;
        private CheckBox aksamYemegiCheckBox;
        private CheckBox odaServisiCheckBox;
        private CheckBox odaTemizligiCheckBox;
        private TextBox rezervasyonIDTextBox;
        private Label rezervasyonIDLabel;
        private Button faturaOlusturButton;
    }
}