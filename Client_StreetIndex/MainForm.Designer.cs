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
            this.textBoxAvailableIndex = new System.Windows.Forms.TextBox();
            this.groupBoxAvailableIndex = new System.Windows.Forms.GroupBox();
            this.groupBoxAvailableIndex.SuspendLayout();
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
            this.buttonSend.Size = new System.Drawing.Size(85, 23);
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
            this.listBoxStreets.Size = new System.Drawing.Size(190, 134);
            this.listBoxStreets.TabIndex = 2;
            // 
            // textBoxAvailableIndex
            // 
            this.textBoxAvailableIndex.Location = new System.Drawing.Point(15, 35);
            this.textBoxAvailableIndex.Multiline = true;
            this.textBoxAvailableIndex.Name = "textBoxAvailableIndex";
            this.textBoxAvailableIndex.ReadOnly = true;
            this.textBoxAvailableIndex.Size = new System.Drawing.Size(68, 115);
            this.textBoxAvailableIndex.TabIndex = 3;
            // 
            // groupBoxAvailableIndex
            // 
            this.groupBoxAvailableIndex.Controls.Add(this.textBoxAvailableIndex);
            this.groupBoxAvailableIndex.Location = new System.Drawing.Point(210, 11);
            this.groupBoxAvailableIndex.Name = "groupBoxAvailableIndex";
            this.groupBoxAvailableIndex.Size = new System.Drawing.Size(99, 163);
            this.groupBoxAvailableIndex.TabIndex = 4;
            this.groupBoxAvailableIndex.TabStop = false;
            this.groupBoxAvailableIndex.Text = "Доступные индексы";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 185);
            this.Controls.Add(this.groupBoxAvailableIndex);
            this.Controls.Add(this.listBoxStreets);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.textBoxPostCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Список улиц по индексу";
            this.groupBoxAvailableIndex.ResumeLayout(false);
            this.groupBoxAvailableIndex.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox textBoxPostCode;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.ListBox listBoxStreets;
        private System.Windows.Forms.TextBox textBoxAvailableIndex;
        private System.Windows.Forms.GroupBox groupBoxAvailableIndex;
    }
}

