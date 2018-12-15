namespace Client_StreetIndex
{
    partial class MainForm
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
            this.buttonSend = new System.Windows.Forms.Button();
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
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(118, 11);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(156, 23);
            this.buttonSend.TabIndex = 1;
            this.buttonSend.Text = "Получить список";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // listBoxStreets
            // 
            this.listBoxStreets.FormattingEnabled = true;
            this.listBoxStreets.Location = new System.Drawing.Point(13, 40);
            this.listBoxStreets.Name = "listBoxStreets";
            this.listBoxStreets.Size = new System.Drawing.Size(261, 121);
            this.listBoxStreets.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 172);
            this.Controls.Add(this.listBoxStreets);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.textBoxPostCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Список улиц по индексу";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox textBoxPostCode;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.ListBox listBoxStreets;
    }
}

