namespace YARTE
{
    partial class FrmInsertOnlineImage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInsertOnlineImage));
            this.label1 = new System.Windows.Forms.Label();
            this.txtUri = new System.Windows.Forms.TextBox();
            this.grpPreview = new System.Windows.Forms.GroupBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.grpPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.errorProvider.SetError(this.label1, resources.GetString("label1.Error"));
            this.errorProvider.SetIconAlignment(this.label1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label1.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.label1, ((int)(resources.GetObject("label1.IconPadding"))));
            this.label1.Name = "label1";
            // 
            // txtUri
            // 
            resources.ApplyResources(this.txtUri, "txtUri");
            this.errorProvider.SetError(this.txtUri, resources.GetString("txtUri.Error"));
            this.errorProvider.SetIconAlignment(this.txtUri, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txtUri.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.txtUri, ((int)(resources.GetObject("txtUri.IconPadding"))));
            this.txtUri.Name = "txtUri";
            this.txtUri.TextChanged += new System.EventHandler(this.txtUri_TextChanged);
            // 
            // grpPreview
            // 
            resources.ApplyResources(this.grpPreview, "grpPreview");
            this.grpPreview.Controls.Add(this.pictureBox);
            this.errorProvider.SetError(this.grpPreview, resources.GetString("grpPreview.Error"));
            this.errorProvider.SetIconAlignment(this.grpPreview, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("grpPreview.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.grpPreview, ((int)(resources.GetObject("grpPreview.IconPadding"))));
            this.grpPreview.Name = "grpPreview";
            this.grpPreview.TabStop = false;
            // 
            // pictureBox
            // 
            resources.ApplyResources(this.pictureBox, "pictureBox");
            this.pictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.errorProvider.SetError(this.pictureBox, resources.GetString("pictureBox.Error"));
            this.errorProvider.SetIconAlignment(this.pictureBox, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("pictureBox.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.pictureBox, ((int)(resources.GetObject("pictureBox.IconPadding"))));
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.TabStop = false;
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
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
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            resources.ApplyResources(this.errorProvider, "errorProvider");
            // 
            // FrmInsertOnlineImage
            // 
            this.AcceptButton = this.btnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grpPreview);
            this.Controls.Add(this.txtUri);
            this.Controls.Add(this.label1);
            this.Name = "FrmInsertOnlineImage";
            this.ShowInTaskbar = false;
            this.Shown += new System.EventHandler(this.FrmOpenOnlineImage_Shown);
            this.grpPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUri;
        private System.Windows.Forms.GroupBox grpPreview;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}