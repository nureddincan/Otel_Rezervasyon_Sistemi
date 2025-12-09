namespace Otel_Rezervasyon_Sistemi
{
    partial class PersonelYonetimForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonelYonetimForm));
            personelIslemleriButton = new Button();
            personelYakiniIslemleriButton = new Button();
            gunSonuRaporuButton = new Button();
            fiyatGuncellemeButton = new Button();
            SuspendLayout();
            // 
            // personelIslemleriButton
            // 
            personelIslemleriButton.Cursor = Cursors.Hand;
            personelIslemleriButton.Location = new Point(12, 12);
            personelIslemleriButton.Name = "personelIslemleriButton";
            personelIslemleriButton.Size = new Size(266, 41);
            personelIslemleriButton.TabIndex = 1;
            personelIslemleriButton.Text = "Personel İşlemleri";
            personelIslemleriButton.UseVisualStyleBackColor = true;
            personelIslemleriButton.Click += personelIslemleriButton_Click;
            // 
            // personelYakiniIslemleriButton
            // 
            personelYakiniIslemleriButton.Cursor = Cursors.Hand;
            personelYakiniIslemleriButton.Location = new Point(12, 58);
            personelYakiniIslemleriButton.Name = "personelYakiniIslemleriButton";
            personelYakiniIslemleriButton.Size = new Size(266, 41);
            personelYakiniIslemleriButton.TabIndex = 2;
            personelYakiniIslemleriButton.Text = "Personel Yakın İşlemleri";
            personelYakiniIslemleriButton.UseVisualStyleBackColor = true;
            personelYakiniIslemleriButton.Click += personelYakiniIslemleriButton_Click;
            // 
            // gunSonuRaporuButton
            // 
            gunSonuRaporuButton.Cursor = Cursors.Hand;
            gunSonuRaporuButton.Location = new Point(12, 150);
            gunSonuRaporuButton.Name = "gunSonuRaporuButton";
            gunSonuRaporuButton.Size = new Size(266, 41);
            gunSonuRaporuButton.TabIndex = 3;
            gunSonuRaporuButton.Text = "Gün Sonu Hesapla";
            gunSonuRaporuButton.UseVisualStyleBackColor = true;
            gunSonuRaporuButton.Click += gunSonuRaporuButton_Click;
            // 
            // fiyatGuncellemeButton
            // 
            fiyatGuncellemeButton.Cursor = Cursors.Hand;
            fiyatGuncellemeButton.Location = new Point(12, 104);
            fiyatGuncellemeButton.Name = "fiyatGuncellemeButton";
            fiyatGuncellemeButton.Size = new Size(266, 41);
            fiyatGuncellemeButton.TabIndex = 4;
            fiyatGuncellemeButton.Text = "Fiyat Güncelleme";
            fiyatGuncellemeButton.UseVisualStyleBackColor = true;
            fiyatGuncellemeButton.Click += fiyatGuncellemeButton_Click;
            // 
            // PersonelYonetimForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(290, 200);
            Controls.Add(fiyatGuncellemeButton);
            Controls.Add(gunSonuRaporuButton);
            Controls.Add(personelYakiniIslemleriButton);
            Controls.Add(personelIslemleriButton);
            Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 162);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5);
            MaximizeBox = false;
            Name = "PersonelYonetimForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Personel Yönetimi";
            ResumeLayout(false);
        }

        #endregion

        private Button personelIslemleriButton;
        private Button personelYakiniIslemleriButton;
        private Button gunSonuRaporuButton;
        private Button fiyatGuncellemeButton;
    }
}