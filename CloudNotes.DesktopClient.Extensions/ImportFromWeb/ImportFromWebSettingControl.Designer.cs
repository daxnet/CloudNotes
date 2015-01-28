namespace CloudNotes.DesktopClient.Extensions.ImportFromWeb
{
    partial class ImportFromWebSettingControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblEncoding = new System.Windows.Forms.Label();
            this.chkEmbedImages = new System.Windows.Forms.CheckBox();
            this.cbEncoding = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblEncoding
            // 
            this.lblEncoding.AutoSize = true;
            this.lblEncoding.Location = new System.Drawing.Point(20, 47);
            this.lblEncoding.Name = "lblEncoding";
            this.lblEncoding.Size = new System.Drawing.Size(55, 13);
            this.lblEncoding.TabIndex = 0;
            this.lblEncoding.Text = "Encoding:";
            // 
            // chkEmbedImages
            // 
            this.chkEmbedImages.AutoSize = true;
            this.chkEmbedImages.Location = new System.Drawing.Point(23, 18);
            this.chkEmbedImages.Name = "chkEmbedImages";
            this.chkEmbedImages.Size = new System.Drawing.Size(96, 17);
            this.chkEmbedImages.TabIndex = 1;
            this.chkEmbedImages.Text = "Embed Images";
            this.chkEmbedImages.UseVisualStyleBackColor = true;
            // 
            // cbEncoding
            // 
            this.cbEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEncoding.FormattingEnabled = true;
            this.cbEncoding.Location = new System.Drawing.Point(81, 41);
            this.cbEncoding.Name = "cbEncoding";
            this.cbEncoding.Size = new System.Drawing.Size(157, 21);
            this.cbEncoding.TabIndex = 2;
            // 
            // ImportFromWebSettingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbEncoding);
            this.Controls.Add(this.chkEmbedImages);
            this.Controls.Add(this.lblEncoding);
            this.Name = "ImportFromWebSettingControl";
            this.Size = new System.Drawing.Size(327, 158);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEncoding;
        internal System.Windows.Forms.CheckBox chkEmbedImages;
        internal System.Windows.Forms.ComboBox cbEncoding;
    }
}
