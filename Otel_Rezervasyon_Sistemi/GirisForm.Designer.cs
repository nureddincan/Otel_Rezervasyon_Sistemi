namespace Otel_Rezervasyon_Sistemi
{
    partial class GirisForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GirisForm));
            girisButton = new Button();
            eMailTextBox = new TextBox();
            sifreTextBox = new TextBox();
            hosgeldinizLabel = new Label();
            SuspendLayout();
            // 
            // girisButton
            // 
            girisButton.Cursor = Cursors.Hand;
            girisButton.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            girisButton.Location = new Point(10, 122);
            girisButton.Margin = new Padding(3, 2, 3, 2);
            girisButton.Name = "girisButton";
            girisButton.Size = new Size(379, 37);
            girisButton.TabIndex = 2;
            girisButton.Text = "Giriş Yap";
            girisButton.UseVisualStyleBackColor = true;
            girisButton.Click += girisButton_Click;
            // 
            // eMailTextBox
            // 
            eMailTextBox.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 162);
            eMailTextBox.Location = new Point(10, 46);
            eMailTextBox.Margin = new Padding(3, 2, 3, 2);
            eMailTextBox.MaxLength = 40;
            eMailTextBox.Name = "eMailTextBox";
            eMailTextBox.PlaceholderText = "abc@gmail.com";
            eMailTextBox.Size = new Size(379, 31);
            eMailTextBox.TabIndex = 0;
            eMailTextBox.TabStop = false;
            // 
            // sifreTextBox
            // 
            sifreTextBox.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 162);
            sifreTextBox.Location = new Point(10, 82);
            sifreTextBox.Margin = new Padding(3, 2, 3, 2);
            sifreTextBox.MaxLength = 40;
            sifreTextBox.Name = "sifreTextBox";
            sifreTextBox.PasswordChar = '*';
            sifreTextBox.PlaceholderText = "************";
            sifreTextBox.Size = new Size(379, 31);
            sifreTextBox.TabIndex = 1;
            sifreTextBox.TabStop = false;
            // 
            // hosgeldinizLabel
            // 
            hosgeldinizLabel.Font = new Font("Segoe UI", 13.2000008F, FontStyle.Regular, GraphicsUnit.Point, 162);
            hosgeldinizLabel.Location = new Point(10, 6);
            hosgeldinizLabel.Name = "hosgeldinizLabel";
            hosgeldinizLabel.Size = new Size(379, 29);
            hosgeldinizLabel.TabIndex = 0;
            hosgeldinizLabel.Text = "~Hoşgeldiniz~";
            hosgeldinizLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // GirisForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 167);
            Controls.Add(hosgeldinizLabel);
            Controls.Add(sifreTextBox);
            Controls.Add(eMailTextBox);
            Controls.Add(girisButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "GirisForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = " Otel Rezervasyon Sistemi Giriş";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button girisButton;
        private TextBox eMailTextBox;
        private TextBox sifreTextBox;
        private Label hosgeldinizLabel;
    }
}
