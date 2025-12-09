namespace Otel_Rezervasyon_Sistemi
{
    partial class HizmetlerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HizmetlerForm));
            odaNoLabel = new Label();
            hizmetleriAraButton = new Button();
            hizmetlerLabel = new Label();
            hizmetlerDataGridView = new DataGridView();
            odaNoComboBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)hizmetlerDataGridView).BeginInit();
            SuspendLayout();
            // 
            // odaNoLabel
            // 
            odaNoLabel.AutoSize = true;
            odaNoLabel.Location = new Point(13, 50);
            odaNoLabel.Name = "odaNoLabel";
            odaNoLabel.Size = new Size(85, 28);
            odaNoLabel.TabIndex = 1;
            odaNoLabel.Text = "Oda No:";
            // 
            // hizmetleriAraButton
            // 
            hizmetleriAraButton.BackColor = SystemColors.ActiveCaption;
            hizmetleriAraButton.Cursor = Cursors.Hand;
            hizmetleriAraButton.Location = new Point(13, 89);
            hizmetleriAraButton.Name = "hizmetleriAraButton";
            hizmetleriAraButton.Size = new Size(328, 41);
            hizmetleriAraButton.TabIndex = 3;
            hizmetleriAraButton.Text = "Hizmetleri Ara";
            hizmetleriAraButton.UseVisualStyleBackColor = false;
            hizmetleriAraButton.Click += hizmetleriAraButton_Click;
            // 
            // hizmetlerLabel
            // 
            hizmetlerLabel.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 162);
            hizmetlerLabel.Location = new Point(347, 10);
            hizmetlerLabel.Name = "hizmetlerLabel";
            hizmetlerLabel.Size = new Size(886, 36);
            hizmetlerLabel.TabIndex = 4;
            hizmetlerLabel.Text = "~Hizmetler~";
            hizmetlerLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // hizmetlerDataGridView
            // 
            hizmetlerDataGridView.BackgroundColor = SystemColors.ControlLight;
            hizmetlerDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            hizmetlerDataGridView.Location = new Point(347, 49);
            hizmetlerDataGridView.Name = "hizmetlerDataGridView";
            hizmetlerDataGridView.ReadOnly = true;
            hizmetlerDataGridView.Size = new Size(886, 606);
            hizmetlerDataGridView.TabIndex = 5;
            // 
            // odaNoComboBox
            // 
            odaNoComboBox.FormattingEnabled = true;
            odaNoComboBox.Location = new Point(167, 47);
            odaNoComboBox.MaxLength = 3;
            odaNoComboBox.Name = "odaNoComboBox";
            odaNoComboBox.Size = new Size(174, 36);
            odaNoComboBox.TabIndex = 2;
            // 
            // HizmetlerForm
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1244, 665);
            Controls.Add(odaNoComboBox);
            Controls.Add(odaNoLabel);
            Controls.Add(hizmetleriAraButton);
            Controls.Add(hizmetlerLabel);
            Controls.Add(hizmetlerDataGridView);
            Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, 162);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 6, 5, 6);
            MaximizeBox = false;
            Name = "HizmetlerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hizmetler";
            Load += HizmetlerForm_Load;
            ((System.ComponentModel.ISupportInitialize)hizmetlerDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label odaNoLabel;
        private Button hizmetleriAraButton;
        private Label hizmetlerLabel;
        private DataGridView hizmetlerDataGridView;
        private ComboBox odaNoComboBox;
    }
}