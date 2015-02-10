namespace CloudNotes.DesktopClient.Extensions.ImportFromWeb
{
    partial class ImportFromWebDialog
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportFromWebDialog));
            this.lblLink = new System.Windows.Forms.Label();
            this.txtLink = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.slblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblLink
            // 
            resources.ApplyResources(this.lblLink, "lblLink");
            this.errorProvider.SetError(this.lblLink, resources.GetString("lblLink.Error"));
            this.errorProvider.SetIconAlignment(this.lblLink, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblLink.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.lblLink, ((int)(resources.GetObject("lblLink.IconPadding"))));
            this.lblLink.Name = "lblLink";
            // 
            // txtLink
            // 
            resources.ApplyResources(this.txtLink, "txtLink");
            this.errorProvider.SetError(this.txtLink, resources.GetString("txtLink.Error"));
            this.errorProvider.SetIconAlignment(this.txtLink, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txtLink.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.txtLink, ((int)(resources.GetObject("txtLink.IconPadding"))));
            this.txtLink.Name = "txtLink";
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.errorProvider.SetError(this.btnOK, resources.GetString("btnOK.Error"));
            this.errorProvider.SetIconAlignment(this.btnOK, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnOK.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.btnOK, ((int)(resources.GetObject("btnOK.IconPadding"))));
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.errorProvider.SetError(this.btnCancel, resources.GetString("btnCancel.Error"));
            this.errorProvider.SetIconAlignment(this.btnCancel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnCancel.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.btnCancel, ((int)(resources.GetObject("btnCancel.IconPadding"))));
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            resources.ApplyResources(this.errorProvider, "errorProvider");
            // 
            // progressBar
            // 
            resources.ApplyResources(this.progressBar, "progressBar");
            this.errorProvider.SetError(this.progressBar, resources.GetString("progressBar.Error"));
            this.errorProvider.SetIconAlignment(this.progressBar, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("progressBar.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.progressBar, ((int)(resources.GetObject("progressBar.IconPadding"))));
            this.progressBar.Name = "progressBar";
            // 
            // slblStatus
            // 
            resources.ApplyResources(this.slblStatus, "slblStatus");
            this.errorProvider.SetError(this.slblStatus, resources.GetString("slblStatus.Error"));
            this.errorProvider.SetIconAlignment(this.slblStatus, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("slblStatus.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.slblStatus, ((int)(resources.GetObject("slblStatus.IconPadding"))));
            this.slblStatus.Name = "slblStatus";
            // 
            // ImportFromWebDialog
            // 
            this.AcceptButton = this.btnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.slblStatus);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtLink);
            this.Controls.Add(this.lblLink);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportFromWebDialog";
            this.ShowInTaskbar = false;
            this.Shown += new System.EventHandler(this.ImportFromWebDialog_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLink;
        private System.Windows.Forms.TextBox txtLink;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label slblStatus;
    }
}