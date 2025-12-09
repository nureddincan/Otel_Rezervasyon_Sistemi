namespace Otel_Rezervasyon_Sistemi
{
    partial class FaturalarForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FaturalarForm));
            musteriKimlikNoLabel = new Label();
            musteriKimlikNoTextBox = new TextBox();
            faturaAraButton = new Button();
            faturayiGoruntuleButton = new Button();
            faturaNoLabel = new Label();
            faturaNoTextBox = new TextBox();
            faturalarLabel = new Label();
            faturalarDataGridView = new DataGridView();
            baslangicDateTimePicker = new DateTimePicker();
            bitisTarihiLabel = new Label();
            bitisDateTimePicker = new DateTimePicker();
            bilgiLabel = new Label();
            baslangicTarihiLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)faturalarDataGridView).BeginInit();
            SuspendLayout();
            // 
            // musteriKimlikNoLabel
            // 
            musteriKimlikNoLabel.AutoSize = true;
            musteriKimlikNoLabel.Location = new Point(12, 98);
            musteriKimlikNoLabel.Name = "musteriKimlikNoLabel";
            musteriKimlikNoLabel.Size = new Size(173, 28);
            musteriKimlikNoLabel.TabIndex = 1;
            musteriKimlikNoLabel.Text = "Müşteri Kimlik No:";
            // 
            // musteriKimlikNoTextBox
            // 
            musteriKimlikNoTextBox.BorderStyle = BorderStyle.FixedSingle;
            musteriKimlikNoTextBox.Location = new Point(190, 96);
            musteriKimlikNoTextBox.MaxLength = 11;
            musteriKimlikNoTextBox.Name = "musteriKimlikNoTextBox";
            musteriKimlikNoTextBox.Size = new Size(174, 34);
            musteriKimlikNoTextBox.TabIndex = 2;
            // 
            // faturaAraButton
            // 
            faturaAraButton.BackColor = SystemColors.ActiveCaption;
            faturaAraButton.Cursor = Cursors.Hand;
            faturaAraButton.Location = new Point(12, 218);
            faturaAraButton.Name = "faturaAraButton";
            faturaAraButton.Size = new Size(352, 41);
            faturaAraButton.TabIndex = 7;
            faturaAraButton.Text = "Fatura Ara";
            faturaAraButton.UseVisualStyleBackColor = false;
            faturaAraButton.Click += faturaAraButton_Click;
            // 
            // faturayiGoruntuleButton
            // 
            faturayiGoruntuleButton.BackColor = SystemColors.ActiveCaption;
            faturayiGoruntuleButton.Cursor = Cursors.Hand;
            faturayiGoruntuleButton.Location = new Point(12, 305);
            faturayiGoruntuleButton.Name = "faturayiGoruntuleButton";
            faturayiGoruntuleButton.Size = new Size(352, 41);
            faturayiGoruntuleButton.TabIndex = 10;
            faturayiGoruntuleButton.Text = "Faturayı Görüntüle";
            faturayiGoruntuleButton.UseVisualStyleBackColor = false;
            faturayiGoruntuleButton.Click += faturayiGoruntuleButton_Click;
            // 
            // faturaNoLabel
            // 
            faturaNoLabel.AutoSize = true;
            faturaNoLabel.Location = new Point(12, 267);
            faturaNoLabel.Name = "faturaNoLabel";
            faturaNoLabel.Size = new Size(102, 28);
            faturaNoLabel.TabIndex = 8;
            faturaNoLabel.Text = "Fatura No:";
            // 
            // faturaNoTextBox
            // 
            faturaNoTextBox.BorderStyle = BorderStyle.FixedSingle;
            faturaNoTextBox.Location = new Point(190, 265);
            faturaNoTextBox.Name = "faturaNoTextBox";
            faturaNoTextBox.Size = new Size(174, 34);
            faturaNoTextBox.TabIndex = 9;
            // 
            // faturalarLabel
            // 
            faturalarLabel.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 162);
            faturalarLabel.Location = new Point(371, 10);
            faturalarLabel.Name = "faturalarLabel";
            faturalarLabel.Size = new Size(886, 36);
            faturalarLabel.TabIndex = 11;
            faturalarLabel.Text = "~Faturalar~";
            faturalarLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // faturalarDataGridView
            // 
            faturalarDataGridView.BackgroundColor = SystemColors.ControlLight;
            faturalarDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            faturalarDataGridView.Location = new Point(371, 49);
            faturalarDataGridView.Name = "faturalarDataGridView";
            faturalarDataGridView.ReadOnly = true;
            faturalarDataGridView.Size = new Size(886, 606);
            faturalarDataGridView.TabIndex = 12;
            // 
            // baslangicDateTimePicker
            // 
            baslangicDateTimePicker.Location = new Point(190, 136);
            baslangicDateTimePicker.Name = "baslangicDateTimePicker";
            baslangicDateTimePicker.Size = new Size(174, 34);
            baslangicDateTimePicker.TabIndex = 4;
            // 
            // bitisTarihiLabel
            // 
            bitisTarihiLabel.AutoSize = true;
            bitisTarihiLabel.Location = new Point(12, 181);
            bitisTarihiLabel.Name = "bitisTarihiLabel";
            bitisTarihiLabel.Size = new Size(103, 28);
            bitisTarihiLabel.TabIndex = 5;
            bitisTarihiLabel.Text = "Bitiş Tarihi:";
            // 
            // bitisDateTimePicker
            // 
            bitisDateTimePicker.Location = new Point(190, 176);
            bitisDateTimePicker.Name = "bitisDateTimePicker";
            bitisDateTimePicker.Size = new Size(174, 34);
            bitisDateTimePicker.TabIndex = 6;
            // 
            // bilgiLabel
            // 
            bilgiLabel.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 162);
            bilgiLabel.Location = new Point(12, 49);
            bilgiLabel.Name = "bilgiLabel";
            bilgiLabel.Size = new Size(352, 44);
            bilgiLabel.TabIndex = 0;
            bilgiLabel.Text = "İstediğiniz Kritere Göre Arayabilirsiniz";
            bilgiLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // baslangicTarihiLabel
            // 
            baslangicTarihiLabel.AutoSize = true;
            baslangicTarihiLabel.Location = new Point(12, 141);
            baslangicTarihiLabel.Name = "baslangicTarihiLabel";
            baslangicTarihiLabel.Size = new Size(148, 28);
            baslangicTarihiLabel.TabIndex = 3;
            baslangicTarihiLabel.Text = "Başlangıç Tarihi:";
            // 
            // FaturalarForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1271, 665);
            Controls.Add(baslangicTarihiLabel);
            Controls.Add(bilgiLabel);
            Controls.Add(bitisDateTimePicker);
            Controls.Add(bitisTarihiLabel);
            Controls.Add(baslangicDateTimePicker);
            Controls.Add(musteriKimlikNoLabel);
            Controls.Add(musteriKimlikNoTextBox);
            Controls.Add(faturaAraButton);
            Controls.Add(faturayiGoruntuleButton);
            Controls.Add(faturaNoLabel);
            Controls.Add(faturaNoTextBox);
            Controls.Add(faturalarLabel);
            Controls.Add(faturalarDataGridView);
            Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 162);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 6, 5, 6);
            MaximizeBox = false;
            Name = "FaturalarForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Faturalar";
            ((System.ComponentModel.ISupportInitialize)faturalarDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label musteriKimlikNoLabel;
        private TextBox musteriKimlikNoTextBox;
        private Button faturaAraButton;
        private Button faturayiGoruntuleButton;
        private Label faturaNoLabel;
        private TextBox faturaNoTextBox;
        private Label faturalarLabel;
        private DataGridView faturalarDataGridView;
        private Label label1;
        private ComboBox odaComboBox;
        private Label label2;
        private DateTimePicker baslangicDateTimePicker;
        private Label bitisTarihiLabel;
        private DateTimePicker bitisDateTimePicker;
        private Label bilgiLabel;
        private Label baslangicTarihiLabel;
    }
}