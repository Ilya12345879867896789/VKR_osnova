
namespace Sklad_mebeli
{
    partial class QR_code
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
            this.Zagruz = new System.Windows.Forms.Button();
            this.Rashifr = new System.Windows.Forms.Button();
            this.Codirovka = new System.Windows.Forms.ComboBox();
            this.Textick = new System.Windows.Forms.TextBox();
            this.Code = new System.Windows.Forms.PictureBox();
            this.Save = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.Code)).BeginInit();
            this.SuspendLayout();
            // 
            // Zagruz
            // 
            this.Zagruz.Location = new System.Drawing.Point(483, 113);
            this.Zagruz.Name = "Zagruz";
            this.Zagruz.Size = new System.Drawing.Size(106, 23);
            this.Zagruz.TabIndex = 11;
            this.Zagruz.Text = "Загрузить";
            this.Zagruz.UseVisualStyleBackColor = true;
            this.Zagruz.Click += new System.EventHandler(this.Zagruz_Click);
            // 
            // Rashifr
            // 
            this.Rashifr.Location = new System.Drawing.Point(483, 142);
            this.Rashifr.Name = "Rashifr";
            this.Rashifr.Size = new System.Drawing.Size(106, 23);
            this.Rashifr.TabIndex = 10;
            this.Rashifr.Text = "Расшифровать";
            this.Rashifr.UseVisualStyleBackColor = true;
            this.Rashifr.Click += new System.EventHandler(this.Rashifr_Click);
            // 
            // Codirovka
            // 
            this.Codirovka.FormattingEnabled = true;
            this.Codirovka.Items.AddRange(new object[] {
            "CODEBAR",
            "CODE_39",
            "CODE_93",
            "CODE_128",
            "QR_CODE",
            "MSI",
            "DATA_MATRIX"});
            this.Codirovka.Location = new System.Drawing.Point(483, 81);
            this.Codirovka.Name = "Codirovka";
            this.Codirovka.Size = new System.Drawing.Size(259, 21);
            this.Codirovka.TabIndex = 9;
            this.Codirovka.Text = "CODEBAR";
            // 
            // Textick
            // 
            this.Textick.Location = new System.Drawing.Point(483, 55);
            this.Textick.Name = "Textick";
            this.Textick.Size = new System.Drawing.Size(259, 20);
            this.Textick.TabIndex = 8;
            this.Textick.TextChanged += new System.EventHandler(this.Textick_TextChanged);
            // 
            // Code
            // 
            this.Code.Location = new System.Drawing.Point(58, 55);
            this.Code.Name = "Code";
            this.Code.Size = new System.Drawing.Size(419, 341);
            this.Code.TabIndex = 7;
            this.Code.TabStop = false;
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(483, 171);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(106, 23);
            this.Save.TabIndex = 6;
            this.Save.Text = "Сохранить";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // QR_code
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Zagruz);
            this.Controls.Add(this.Rashifr);
            this.Controls.Add(this.Codirovka);
            this.Controls.Add(this.Textick);
            this.Controls.Add(this.Code);
            this.Controls.Add(this.Save);
            this.Name = "QR_code";
            this.Text = "QR_code";
            ((System.ComponentModel.ISupportInitialize)(this.Code)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Zagruz;
        private System.Windows.Forms.Button Rashifr;
        private System.Windows.Forms.ComboBox Codirovka;
        private System.Windows.Forms.TextBox Textick;
        private System.Windows.Forms.PictureBox Code;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}