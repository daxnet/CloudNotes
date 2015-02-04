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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportFromWebSettingControl));
            this.lblEncoding = new System.Windows.Forms.Label();
            this.chkEmbedImages = new System.Windows.Forms.CheckBox();
            this.cbEncoding = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblEncoding
            // 
            resources.ApplyResources(this.lblEncoding, "lblEncoding");
            this.lblEncoding.Name = "lblEncoding";
            // 
            // chkEmbedImages
            // 
            resources.ApplyResources(this.chkEmbedImages, "chkEmbedImages");
            this.chkEmbedImages.Name = "chkEmbedImages";
            this.chkEmbedImages.UseVisualStyleBackColor = true;
            // 
            // cbEncoding
            // 
            this.cbEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEncoding.FormattingEnabled = true;
            resources.ApplyResources(this.cbEncoding, "cbEncoding");
            this.cbEncoding.Name = "cbEncoding";
            // 
            // ImportFromWebSettingControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbEncoding);
            this.Controls.Add(this.chkEmbedImages);
            this.Controls.Add(this.lblEncoding);
            this.Name = "ImportFromWebSettingControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEncoding;
        internal System.Windows.Forms.CheckBox chkEmbedImages;
        internal System.Windows.Forms.ComboBox cbEncoding;
    }
}
