namespace CloudNotes.DesktopClient.Extensions.Blog
{
    partial class FrmBlogPublish
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBlogPublish));
            this.cbBlogs = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbBlogs
            // 
            this.cbBlogs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBlogs.FormattingEnabled = true;
            resources.ApplyResources(this.cbBlogs, "cbBlogs");
            this.cbBlogs.Name = "cbBlogs";
            // 
            // FrmBlogPublish
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbBlogs);
            this.Name = "FrmBlogPublish";
            this.Shown += new System.EventHandler(this.FrmBlogPublish_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbBlogs;
    }
}