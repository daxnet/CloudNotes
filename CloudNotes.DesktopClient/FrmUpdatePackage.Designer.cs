namespace CloudNotes.DesktopClient
{
    partial class FrmUpdatePackage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUpdatePackage));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblPublished = new System.Windows.Forms.Label();
            this.lblPublishedTitle = new System.Windows.Forms.Label();
            this.lblCurrentVersion = new System.Windows.Forms.Label();
            this.lblLatestVersion = new System.Windows.Forms.Label();
            this.lblCurrentVersionTitle = new System.Windows.Forms.Label();
            this.lblLatestVersionTitle = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.wbReleaseNotes = new System.Windows.Forms.WebBrowser();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            resources.ApplyResources(this.pnlTop, "pnlTop");
            this.pnlTop.Controls.Add(this.lblPublished);
            this.pnlTop.Controls.Add(this.lblPublishedTitle);
            this.pnlTop.Controls.Add(this.lblCurrentVersion);
            this.pnlTop.Controls.Add(this.lblLatestVersion);
            this.pnlTop.Controls.Add(this.lblCurrentVersionTitle);
            this.pnlTop.Controls.Add(this.lblLatestVersionTitle);
            this.pnlTop.Name = "pnlTop";
            // 
            // lblPublished
            // 
            resources.ApplyResources(this.lblPublished, "lblPublished");
            this.lblPublished.Name = "lblPublished";
            // 
            // lblPublishedTitle
            // 
            resources.ApplyResources(this.lblPublishedTitle, "lblPublishedTitle");
            this.lblPublishedTitle.Name = "lblPublishedTitle";
            // 
            // lblCurrentVersion
            // 
            resources.ApplyResources(this.lblCurrentVersion, "lblCurrentVersion");
            this.lblCurrentVersion.Name = "lblCurrentVersion";
            // 
            // lblLatestVersion
            // 
            resources.ApplyResources(this.lblLatestVersion, "lblLatestVersion");
            this.lblLatestVersion.Name = "lblLatestVersion";
            // 
            // lblCurrentVersionTitle
            // 
            resources.ApplyResources(this.lblCurrentVersionTitle, "lblCurrentVersionTitle");
            this.lblCurrentVersionTitle.Name = "lblCurrentVersionTitle";
            // 
            // lblLatestVersionTitle
            // 
            resources.ApplyResources(this.lblLatestVersionTitle, "lblLatestVersionTitle");
            this.lblLatestVersionTitle.Name = "lblLatestVersionTitle";
            // 
            // pnlBottom
            // 
            resources.ApplyResources(this.pnlBottom, "pnlBottom");
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnUpdate);
            this.pnlBottom.Name = "pnlBottom";
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            resources.ApplyResources(this.btnUpdate, "btnUpdate");
            this.btnUpdate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // wbReleaseNotes
            // 
            resources.ApplyResources(this.wbReleaseNotes, "wbReleaseNotes");
            this.wbReleaseNotes.Name = "wbReleaseNotes";
            // 
            // FrmUpdatePackage
            // 
            this.AcceptButton = this.btnUpdate;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.wbReleaseNotes);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "FrmUpdatePackage";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.FrmUpdatePackage_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.WebBrowser wbReleaseNotes;
        private System.Windows.Forms.Label lblCurrentVersion;
        private System.Windows.Forms.Label lblLatestVersion;
        private System.Windows.Forms.Label lblCurrentVersionTitle;
        private System.Windows.Forms.Label lblLatestVersionTitle;
        private System.Windows.Forms.Label lblPublishedTitle;
        private System.Windows.Forms.Label lblPublished;
    }
}