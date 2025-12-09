namespace Otel_Rezervasyon_Sistemi
{
    partial class RezervasyonYonetimForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RezervasyonYonetimForm));
            rezervasyonOlusturButton = new Button();
            musteriIslemleriButton = new Button();
            misafirIslemleriButton = new Button();
            faturalariGoruntuleButton = new Button();
            hizmetleriGoruntuleButton = new Button();
            rezervasyonSilButton = new Button();
            SuspendLayout();
            // 
            // rezervasyonOlusturButton
            // 
            rezervasyonOlusturButton.Cursor = Cursors.Hand;
            rezervasyonOlusturButton.Location = new Point(14, 107);
            rezervasyonOlusturButton.Margin = new Padding(5, 6, 5, 6);
            rezervasyonOlusturButton.Name = "rezervasyonOlusturButton";
            rezervasyonOlusturButton.Size = new Size(266, 41);
            rezervasyonOlusturButton.TabIndex = 3;
            rezervasyonOlusturButton.Text = "Rezervasyon Oluştur";
            rezervasyonOlusturButton.UseVisualStyleBackColor = true;
            rezervasyonOlusturButton.Click += rezervasyonOlusturButton_Click;
            // 
            // musteriIslemleriButton
            // 
            musteriIslemleriButton.Cursor = Cursors.Hand;
            musteriIslemleriButton.Location = new Point(14, 13);
            musteriIslemleriButton.Margin = new Padding(5, 6, 5, 6);
            musteriIslemleriButton.Name = "musteriIslemleriButton";
            musteriIslemleriButton.Size = new Size(266, 41);
            musteriIslemleriButton.TabIndex = 1;
            musteriIslemleriButton.Text = "Müşteri İşlemleri";
            musteriIslemleriButton.UseVisualStyleBackColor = true;
            musteriIslemleriButton.Click += musteriIslemleriButton_Click;
            // 
            // misafirIslemleriButton
            // 
            misafirIslemleriButton.Cursor = Cursors.Hand;
            misafirIslemleriButton.Location = new Point(14, 60);
            misafirIslemleriButton.Margin = new Padding(5, 6, 5, 6);
            misafirIslemleriButton.Name = "misafirIslemleriButton";
            misafirIslemleriButton.Size = new Size(266, 41);
            misafirIslemleriButton.TabIndex = 2;
            misafirIslemleriButton.Text = "Misafir İşlemleri";
            misafirIslemleriButton.UseVisualStyleBackColor = true;
            misafirIslemleriButton.Click += misafirIslemleriButton_Click;
            // 
            // faturalariGoruntuleButton
            // 
            faturalariGoruntuleButton.Cursor = Cursors.Hand;
            faturalariGoruntuleButton.Location = new Point(14, 201);
            faturalariGoruntuleButton.Margin = new Padding(5, 6, 5, 6);
            faturalariGoruntuleButton.Name = "faturalariGoruntuleButton";
            faturalariGoruntuleButton.Size = new Size(266, 41);
            faturalariGoruntuleButton.TabIndex = 5;
            faturalariGoruntuleButton.Text = "Faturaları Görüntüle";
            faturalariGoruntuleButton.UseVisualStyleBackColor = true;
            faturalariGoruntuleButton.Click += faturalarButton_Click;
            // 
            // hizmetleriGoruntuleButton
            // 
            hizmetleriGoruntuleButton.Cursor = Cursors.Hand;
            hizmetleriGoruntuleButton.Location = new Point(14, 248);
            hizmetleriGoruntuleButton.Margin = new Padding(5, 6, 5, 6);
            hizmetleriGoruntuleButton.Name = "hizmetleriGoruntuleButton";
            hizmetleriGoruntuleButton.Size = new Size(266, 41);
            hizmetleriGoruntuleButton.TabIndex = 6;
            hizmetleriGoruntuleButton.Text = "Hizmetleri Görüntüle";
            hizmetleriGoruntuleButton.UseVisualStyleBackColor = true;
            hizmetleriGoruntuleButton.Click += hizmetleriGoruntuleButton_Click;
            // 
            // rezervasyonSilButton
            // 
            rezervasyonSilButton.Cursor = Cursors.Hand;
            rezervasyonSilButton.Location = new Point(14, 154);
            rezervasyonSilButton.Margin = new Padding(5, 6, 5, 6);
            rezervasyonSilButton.Name = "rezervasyonSilButton";
            rezervasyonSilButton.Size = new Size(266, 41);
            rezervasyonSilButton.TabIndex = 4;
            rezervasyonSilButton.Text = "Rezervasyon Sil";
            rezervasyonSilButton.UseVisualStyleBackColor = true;
            rezervasyonSilButton.Click += rezervasyonSilButton_Click;
            // 
            // RezervasyonYonetimForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(290, 298);
            Controls.Add(rezervasyonSilButton);
            Controls.Add(hizmetleriGoruntuleButton);
            Controls.Add(faturalariGoruntuleButton);
            Controls.Add(misafirIslemleriButton);
            Controls.Add(musteriIslemleriButton);
            Controls.Add(rezervasyonOlusturButton);
            Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 162);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 6, 5, 6);
            MaximizeBox = false;
            Name = "RezervasyonYonetimForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Rezervasyon Yönetimi";
            ResumeLayout(false);
        }

        #endregion

        private Button rezervasyonOlusturButton;
        private Button musteriIslemleriButton;
        private Button misafirIslemleriButton;
        private Button faturalariGoruntuleButton;
        private Button hizmetleriGoruntuleButton;
        private Button rezervasyonSilButton;
    }
}