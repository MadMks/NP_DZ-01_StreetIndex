namespace Client_StreetIndex
{
    partial class Form1
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
            this.textBoxPostCode = new System.Windows.Forms.MaskedTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listBoxStreets = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // textBoxPostCode
            // 
            this.textBoxPostCode.Location = new System.Drawing.Point(12, 12);
            this.textBoxPostCode.Mask = "00000";
            this.textBoxPostCode.Name = "textBoxPostCode";
            this.textBoxPostCode.Size = new System.Drawing.Size(100, 21);
            this.textBoxPostCode.TabIndex = 0;
            this.textBoxPostCode.ValidatingType = typeof(int);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(146, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // listBoxStreets
            // 
            this.listBoxStreets.FormattingEnabled = true;
            this.listBoxStreets.Location = new System.Drawing.Point(13, 40);
            this.listBoxStreets.Name = "listBoxStreets";
            this.listBoxStreets.Size = new System.Drawing.Size(208, 121);
            this.listBoxStreets.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 172);
            this.Controls.Add(this.listBoxStreets);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxPostCode);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox textBoxPostCode;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBoxStreets;
    }
}

