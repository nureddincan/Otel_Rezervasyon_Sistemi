namespace Otel_Rezervasyon_Sistemi
{
    partial class RezervasyonSilForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RezervasyonSilForm));
            faturaOlusturButton = new Button();
            rezervasyonIDLabel = new Label();
            rezervasyonIDTextBox = new TextBox();
            rezervasyonlarLabel = new Label();
            rezervasyonlarDataGridView = new DataGridView();
            rezervasyonSilButton = new Button();
            rezervasyonAraButton = new Button();
            musteriKimlikNoTextBox = new TextBox();
            musteriKimlikNoLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)rezervasyonlarDataGridView).BeginInit();
            SuspendLayout();
            // 
            // faturaOlusturButton
            // 
            faturaOlusturButton.BackColor = SystemColors.ActiveCaption;
            faturaOlusturButton.Cursor = Cursors.Hand;
            faturaOlusturButton.Location = new Point(191, 176);
            faturaOlusturButton.Name = "faturaOlusturButton";
            faturaOlusturButton.Size = new Size(174, 41);
            faturaOlusturButton.TabIndex = 7;
            faturaOlusturButton.Text = "Fatura Oluştur";
            faturaOlusturButton.UseVisualStyleBackColor = false;
            faturaOlusturButton.Click += faturaOlusturButton_Click;
            // 
            // rezervasyonIDLabel
            // 
            rezervasyonIDLabel.AutoSize = true;
            rezervasyonIDLabel.Location = new Point(13, 139);
            rezervasyonIDLabel.Name = "rezervasyonIDLabel";
            rezervasyonIDLabel.Size = new Size(148, 28);
            rezervasyonIDLabel.TabIndex = 4;
            rezervasyonIDLabel.Text = "Rezervasyon ID:";
            // 
            // rezervasyonIDTextBox
            // 
            rezervasyonIDTextBox.BorderStyle = BorderStyle.FixedSingle;
            rezervasyonIDTextBox.Location = new Point(191, 136);
            rezervasyonIDTextBox.Name = "rezervasyonIDTextBox";
            rezervasyonIDTextBox.Size = new Size(174, 34);
            rezervasyonIDTextBox.TabIndex = 5;
            // 
            // rezervasyonlarLabel
            // 
            rezervasyonlarLabel.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 162);
            rezervasyonlarLabel.Location = new Point(371, 10);
            rezervasyonlarLabel.Name = "rezervasyonlarLabel";
            rezervasyonlarLabel.Size = new Size(886, 36);
            rezervasyonlarLabel.TabIndex = 8;
            rezervasyonlarLabel.Text = "~Rezervasyonlar~";
            rezervasyonlarLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // rezervasyonlarDataGridView
            // 
            rezervasyonlarDataGridView.BackgroundColor = SystemColors.ControlLight;
            rezervasyonlarDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            rezervasyonlarDataGridView.Location = new Point(371, 49);
            rezervasyonlarDataGridView.Name = "rezervasyonlarDataGridView";
            rezervasyonlarDataGridView.ReadOnly = true;
            rezervasyonlarDataGridView.Size = new Size(886, 606);
            rezervasyonlarDataGridView.TabIndex = 9;
            // 
            // rezervasyonSilButton
            // 
            rezervasyonSilButton.BackColor = SystemColors.ActiveCaption;
            rezervasyonSilButton.Cursor = Cursors.Hand;
            rezervasyonSilButton.Location = new Point(13, 176);
            rezervasyonSilButton.Name = "rezervasyonSilButton";
            rezervasyonSilButton.Size = new Size(173, 41);
            rezervasyonSilButton.TabIndex = 6;
            rezervasyonSilButton.Text = "Rezervasyonu Sil";
            rezervasyonSilButton.UseVisualStyleBackColor = false;
            rezervasyonSilButton.Click += rezervasyonSilButton_Click;
            // 
            // rezervasyonAraButton
            // 
            rezervasyonAraButton.BackColor = SystemColors.ActiveCaption;
            rezervasyonAraButton.Cursor = Cursors.Hand;
            rezervasyonAraButton.Location = new Point(12, 89);
            rezervasyonAraButton.Name = "rezervasyonAraButton";
            rezervasyonAraButton.Size = new Size(353, 41);
            rezervasyonAraButton.TabIndex = 3;
            rezervasyonAraButton.Text = "Rezervasyon Ara";
            rezervasyonAraButton.UseVisualStyleBackColor = false;
            rezervasyonAraButton.Click += rezervasyonAraButton_Click;
            // 
            // musteriKimlikNoTextBox
            // 
            musteriKimlikNoTextBox.BorderStyle = BorderStyle.FixedSingle;
            musteriKimlikNoTextBox.Location = new Point(191, 49);
            musteriKimlikNoTextBox.MaxLength = 11;
            musteriKimlikNoTextBox.Name = "musteriKimlikNoTextBox";
            musteriKimlikNoTextBox.Size = new Size(174, 34);
            musteriKimlikNoTextBox.TabIndex = 2;
            // 
            // musteriKimlikNoLabel
            // 
            musteriKimlikNoLabel.AutoSize = true;
            musteriKimlikNoLabel.Location = new Point(13, 51);
            musteriKimlikNoLabel.Name = "musteriKimlikNoLabel";
            musteriKimlikNoLabel.Size = new Size(173, 28);
            musteriKimlikNoLabel.TabIndex = 1;
            musteriKimlikNoLabel.Text = "Müşteri Kimlik No:";
            // 
            // RezervasyonSilForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1271, 665);
            Controls.Add(musteriKimlikNoLabel);
            Controls.Add(musteriKimlikNoTextBox);
            Controls.Add(rezervasyonAraButton);
            Controls.Add(rezervasyonSilButton);
            Controls.Add(faturaOlusturButton);
            Controls.Add(rezervasyonIDLabel);
            Controls.Add(rezervasyonIDTextBox);
            Controls.Add(rezervasyonlarLabel);
            Controls.Add(rezervasyonlarDataGridView);
            Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 162);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 6, 5, 6);
            Name = "RezervasyonSilForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Rezervasyon Sil";
            Load += RezervasyonSilForm_Load;
            ((System.ComponentModel.ISupportInitialize)rezervasyonlarDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button faturaOlusturButton;
        private Label rezervasyonIDLabel;
        private TextBox rezervasyonIDTextBox;
        private Label rezervasyonlarLabel;
        private DataGridView rezervasyonlarDataGridView;
        private Button rezervasyonSilButton;
        private Button rezervasyonAraButton;
        private TextBox musteriKimlikNoTextBox;
        private Label musteriKimlikNoLabel;
    }
}