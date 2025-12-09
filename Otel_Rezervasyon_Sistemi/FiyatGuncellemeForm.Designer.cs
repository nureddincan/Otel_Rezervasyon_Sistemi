namespace Otel_Rezervasyon_Sistemi
{
    partial class FiyatGuncellemeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FiyatGuncellemeForm));
            personelTurIDLabel = new Label();
            personelTurIDTextBox = new TextBox();
            personelMaasGuncelleButton = new Button();
            fiyatGuncellemeIslemleriTabControl = new TabControl();
            personelTabPage = new TabPage();
            yeniMaasTextBox = new TextBox();
            yeniMaasLabel = new Label();
            personelTurleriLabel = new Label();
            personelTurleriDataGridView = new DataGridView();
            odaTurTabPage = new TabPage();
            yeniFiyatTextBox = new TextBox();
            yeniFiyatLabel = new Label();
            odaTurIDTextBox = new TextBox();
            odaFiyatGuncelleButton = new Button();
            odaTurIDLabel = new Label();
            odaTurleriLabel = new Label();
            odaTurleriDataGridView = new DataGridView();
            fiyatGuncellemeIslemleriTabControl.SuspendLayout();
            personelTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)personelTurleriDataGridView).BeginInit();
            odaTurTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)odaTurleriDataGridView).BeginInit();
            SuspendLayout();
            // 
            // personelTurIDLabel
            // 
            personelTurIDLabel.AutoSize = true;
            personelTurIDLabel.Location = new Point(6, 56);
            personelTurIDLabel.Name = "personelTurIDLabel";
            personelTurIDLabel.Size = new Size(146, 28);
            personelTurIDLabel.TabIndex = 1;
            personelTurIDLabel.Text = "Personel Tür ID:";
            // 
            // personelTurIDTextBox
            // 
            personelTurIDTextBox.BorderStyle = BorderStyle.FixedSingle;
            personelTurIDTextBox.Location = new Point(158, 53);
            personelTurIDTextBox.Name = "personelTurIDTextBox";
            personelTurIDTextBox.Size = new Size(139, 34);
            personelTurIDTextBox.TabIndex = 2;
            // 
            // personelMaasGuncelleButton
            // 
            personelMaasGuncelleButton.BackColor = SystemColors.ActiveCaption;
            personelMaasGuncelleButton.Cursor = Cursors.Hand;
            personelMaasGuncelleButton.Location = new Point(158, 136);
            personelMaasGuncelleButton.Name = "personelMaasGuncelleButton";
            personelMaasGuncelleButton.Size = new Size(139, 41);
            personelMaasGuncelleButton.TabIndex = 5;
            personelMaasGuncelleButton.Text = "Güncelle";
            personelMaasGuncelleButton.UseVisualStyleBackColor = false;
            personelMaasGuncelleButton.Click += personelMaasGuncelleButton_Click;
            // 
            // fiyatGuncellemeIslemleriTabControl
            // 
            fiyatGuncellemeIslemleriTabControl.Controls.Add(personelTabPage);
            fiyatGuncellemeIslemleriTabControl.Controls.Add(odaTurTabPage);
            fiyatGuncellemeIslemleriTabControl.Location = new Point(12, 12);
            fiyatGuncellemeIslemleriTabControl.Name = "fiyatGuncellemeIslemleriTabControl";
            fiyatGuncellemeIslemleriTabControl.SelectedIndex = 0;
            fiyatGuncellemeIslemleriTabControl.Size = new Size(940, 440);
            fiyatGuncellemeIslemleriTabControl.TabIndex = 24;
            // 
            // personelTabPage
            // 
            personelTabPage.Controls.Add(yeniMaasTextBox);
            personelTabPage.Controls.Add(yeniMaasLabel);
            personelTabPage.Controls.Add(personelTurleriLabel);
            personelTabPage.Controls.Add(personelTurleriDataGridView);
            personelTabPage.Controls.Add(personelTurIDTextBox);
            personelTabPage.Controls.Add(personelMaasGuncelleButton);
            personelTabPage.Controls.Add(personelTurIDLabel);
            personelTabPage.Location = new Point(4, 37);
            personelTabPage.Name = "personelTabPage";
            personelTabPage.Padding = new Padding(3);
            personelTabPage.Size = new Size(932, 399);
            personelTabPage.TabIndex = 0;
            personelTabPage.Text = "Personel Maaş Güncelleme";
            personelTabPage.UseVisualStyleBackColor = true;
            // 
            // yeniMaasTextBox
            // 
            yeniMaasTextBox.BorderStyle = BorderStyle.FixedSingle;
            yeniMaasTextBox.Location = new Point(158, 97);
            yeniMaasTextBox.Name = "yeniMaasTextBox";
            yeniMaasTextBox.Size = new Size(139, 34);
            yeniMaasTextBox.TabIndex = 4;
            // 
            // yeniMaasLabel
            // 
            yeniMaasLabel.AutoSize = true;
            yeniMaasLabel.Location = new Point(6, 99);
            yeniMaasLabel.Name = "yeniMaasLabel";
            yeniMaasLabel.Size = new Size(102, 28);
            yeniMaasLabel.TabIndex = 3;
            yeniMaasLabel.Text = "Yeni Maaş:";
            // 
            // personelTurleriLabel
            // 
            personelTurleriLabel.Location = new Point(303, 13);
            personelTurleriLabel.Name = "personelTurleriLabel";
            personelTurleriLabel.Size = new Size(623, 37);
            personelTurleriLabel.TabIndex = 6;
            personelTurleriLabel.Text = "~Personel Türleri~";
            personelTurleriLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // personelTurleriDataGridView
            // 
            personelTurleriDataGridView.BackgroundColor = SystemColors.ControlLight;
            personelTurleriDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            personelTurleriDataGridView.Location = new Point(303, 53);
            personelTurleriDataGridView.Name = "personelTurleriDataGridView";
            personelTurleriDataGridView.ReadOnly = true;
            personelTurleriDataGridView.Size = new Size(623, 340);
            personelTurleriDataGridView.TabIndex = 7;
            // 
            // odaTurTabPage
            // 
            odaTurTabPage.Controls.Add(yeniFiyatTextBox);
            odaTurTabPage.Controls.Add(yeniFiyatLabel);
            odaTurTabPage.Controls.Add(odaTurIDTextBox);
            odaTurTabPage.Controls.Add(odaFiyatGuncelleButton);
            odaTurTabPage.Controls.Add(odaTurIDLabel);
            odaTurTabPage.Controls.Add(odaTurleriLabel);
            odaTurTabPage.Controls.Add(odaTurleriDataGridView);
            odaTurTabPage.Location = new Point(4, 24);
            odaTurTabPage.Name = "odaTurTabPage";
            odaTurTabPage.Padding = new Padding(3);
            odaTurTabPage.Size = new Size(932, 412);
            odaTurTabPage.TabIndex = 1;
            odaTurTabPage.Text = "Oda Fiyatı Güncelleme";
            odaTurTabPage.UseVisualStyleBackColor = true;
            // 
            // yeniFiyatTextBox
            // 
            yeniFiyatTextBox.BorderStyle = BorderStyle.FixedSingle;
            yeniFiyatTextBox.Location = new Point(131, 93);
            yeniFiyatTextBox.Name = "yeniFiyatTextBox";
            yeniFiyatTextBox.Size = new Size(139, 34);
            yeniFiyatTextBox.TabIndex = 4;
            // 
            // yeniFiyatLabel
            // 
            yeniFiyatLabel.AutoSize = true;
            yeniFiyatLabel.Location = new Point(15, 95);
            yeniFiyatLabel.Name = "yeniFiyatLabel";
            yeniFiyatLabel.Size = new Size(98, 28);
            yeniFiyatLabel.TabIndex = 3;
            yeniFiyatLabel.Text = "Yeni Fiyat:";
            // 
            // odaTurIDTextBox
            // 
            odaTurIDTextBox.BorderStyle = BorderStyle.FixedSingle;
            odaTurIDTextBox.Location = new Point(131, 53);
            odaTurIDTextBox.Name = "odaTurIDTextBox";
            odaTurIDTextBox.Size = new Size(139, 34);
            odaTurIDTextBox.TabIndex = 2;
            // 
            // odaFiyatGuncelleButton
            // 
            odaFiyatGuncelleButton.BackColor = SystemColors.ActiveCaption;
            odaFiyatGuncelleButton.Cursor = Cursors.Hand;
            odaFiyatGuncelleButton.Location = new Point(131, 133);
            odaFiyatGuncelleButton.Name = "odaFiyatGuncelleButton";
            odaFiyatGuncelleButton.Size = new Size(139, 41);
            odaFiyatGuncelleButton.TabIndex = 5;
            odaFiyatGuncelleButton.Text = "Güncelle";
            odaFiyatGuncelleButton.UseVisualStyleBackColor = false;
            odaFiyatGuncelleButton.Click += odaFiyatGuncelleButton_Click;
            // 
            // odaTurIDLabel
            // 
            odaTurIDLabel.AutoSize = true;
            odaTurIDLabel.Location = new Point(15, 55);
            odaTurIDLabel.Name = "odaTurIDLabel";
            odaTurIDLabel.Size = new Size(110, 28);
            odaTurIDLabel.TabIndex = 1;
            odaTurIDLabel.Text = "Oda Tür ID:";
            // 
            // odaTurleriLabel
            // 
            odaTurleriLabel.Location = new Point(276, 13);
            odaTurleriLabel.Name = "odaTurleriLabel";
            odaTurleriLabel.Size = new Size(650, 37);
            odaTurleriLabel.TabIndex = 6;
            odaTurleriLabel.Text = "~Oda Türleri~";
            odaTurleriLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // odaTurleriDataGridView
            // 
            odaTurleriDataGridView.BackgroundColor = SystemColors.ControlLight;
            odaTurleriDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            odaTurleriDataGridView.Location = new Point(276, 53);
            odaTurleriDataGridView.Name = "odaTurleriDataGridView";
            odaTurleriDataGridView.ReadOnly = true;
            odaTurleriDataGridView.Size = new Size(650, 340);
            odaTurleriDataGridView.TabIndex = 7;
            // 
            // FiyatGuncellemeForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(960, 457);
            Controls.Add(fiyatGuncellemeIslemleriTabControl);
            Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 162);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 6, 5, 6);
            MaximizeBox = false;
            Name = "FiyatGuncellemeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Fiyat Güncelleme İşlemleri";
            Load += FiyatGuncellemeForm_Load;
            fiyatGuncellemeIslemleriTabControl.ResumeLayout(false);
            personelTabPage.ResumeLayout(false);
            personelTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)personelTurleriDataGridView).EndInit();
            odaTurTabPage.ResumeLayout(false);
            odaTurTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)odaTurleriDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label personelTurIDLabel;
        private TextBox personelTurIDTextBox;
        private Button personelMaasGuncelleButton;
        private TabControl fiyatGuncellemeIslemleriTabControl;
        private TabPage personelTabPage;
        private TabPage odaTurTabPage;
        private DataGridView personelTurleriDataGridView;
        private Label personelTurleriLabel;
        private TextBox odaTurIDTextBox;
        private Button odaFiyatGuncelleButton;
        private Label odaTurIDLabel;
        private Label odaTurleriLabel;
        private DataGridView odaTurleriDataGridView;
        private TextBox yeniMaasTextBox;
        private Label yeniMaasLabel;
        private TextBox yeniFiyatTextBox;
        private Label yeniFiyatLabel;
    }
}