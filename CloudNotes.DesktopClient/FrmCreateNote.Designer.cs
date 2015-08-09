namespace CloudNotes.DesktopClient
{
    partial class FrmCreateNote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCreateNote));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.grpStyling = new System.Windows.Forms.GroupBox();
            this.panel = new System.Windows.Forms.Panel();
            this.wbStylePreview = new System.Windows.Forms.WebBrowser();
            this.cbStyle = new System.Windows.Forms.ComboBox();
            this.lblStyle = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grpStyling.SuspendLayout();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.errorProvider.SetError(this.pictureBox1, resources.GetString("pictureBox1.Error"));
            this.errorProvider.SetIconAlignment(this.pictureBox1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("pictureBox1.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.pictureBox1, ((int)(resources.GetObject("pictureBox1.IconPadding"))));
            this.pictureBox1.Image = global::CloudNotes.DesktopClient.Properties.Resources.Wordpad_icon;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // lblTitle
            // 
            resources.ApplyResources(this.lblTitle, "lblTitle");
            this.errorProvider.SetError(this.lblTitle, resources.GetString("lblTitle.Error"));
            this.errorProvider.SetIconAlignment(this.lblTitle, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblTitle.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.lblTitle, ((int)(resources.GetObject("lblTitle.IconPadding"))));
            this.lblTitle.Name = "lblTitle";
            // 
            // txtTitle
            // 
            resources.ApplyResources(this.txtTitle, "txtTitle");
            this.errorProvider.SetError(this.txtTitle, resources.GetString("txtTitle.Error"));
            this.errorProvider.SetIconAlignment(this.txtTitle, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txtTitle.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.txtTitle, ((int)(resources.GetObject("txtTitle.IconPadding"))));
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Enter += new System.EventHandler(this.txtTitle_Enter);
            // 
            // grpStyling
            // 
            resources.ApplyResources(this.grpStyling, "grpStyling");
            this.grpStyling.Controls.Add(this.panel);
            this.grpStyling.Controls.Add(this.cbStyle);
            this.grpStyling.Controls.Add(this.lblStyle);
            this.errorProvider.SetError(this.grpStyling, resources.GetString("grpStyling.Error"));
            this.errorProvider.SetIconAlignment(this.grpStyling, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("grpStyling.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.grpStyling, ((int)(resources.GetObject("grpStyling.IconPadding"))));
            this.grpStyling.Name = "grpStyling";
            this.grpStyling.TabStop = false;
            // 
            // panel
            // 
            resources.ApplyResources(this.panel, "panel");
            this.panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel.Controls.Add(this.wbStylePreview);
            this.errorProvider.SetError(this.panel, resources.GetString("panel.Error"));
            this.errorProvider.SetIconAlignment(this.panel, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("panel.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.panel, ((int)(resources.GetObject("panel.IconPadding"))));
            this.panel.Name = "panel";
            // 
            // wbStylePreview
            // 
            resources.ApplyResources(this.wbStylePreview, "wbStylePreview");
            this.wbStylePreview.AllowWebBrowserDrop = false;
            this.errorProvider.SetError(this.wbStylePreview, resources.GetString("wbStylePreview.Error"));
            this.errorProvider.SetIconAlignment(this.wbStylePreview, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("wbStylePreview.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.wbStylePreview, ((int)(resources.GetObject("wbStylePreview.IconPadding"))));
            this.wbStylePreview.IsWebBrowserContextMenuEnabled = false;
            this.wbStylePreview.Name = "wbStylePreview";
            this.wbStylePreview.ScriptErrorsSuppressed = true;
            this.wbStylePreview.WebBrowserShortcutsEnabled = false;
            // 
            // cbStyle
            // 
            resources.ApplyResources(this.cbStyle, "cbStyle");
            this.cbStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.errorProvider.SetError(this.cbStyle, resources.GetString("cbStyle.Error"));
            this.cbStyle.FormattingEnabled = true;
            this.errorProvider.SetIconAlignment(this.cbStyle, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cbStyle.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.cbStyle, ((int)(resources.GetObject("cbStyle.IconPadding"))));
            this.cbStyle.Name = "cbStyle";
            this.cbStyle.SelectedIndexChanged += new System.EventHandler(this.cbStyle_SelectedIndexChanged);
            // 
            // lblStyle
            // 
            resources.ApplyResources(this.lblStyle, "lblStyle");
            this.errorProvider.SetError(this.lblStyle, resources.GetString("lblStyle.Error"));
            this.errorProvider.SetIconAlignment(this.lblStyle, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblStyle.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.lblStyle, ((int)(resources.GetObject("lblStyle.IconPadding"))));
            this.lblStyle.Name = "lblStyle";
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
            // FrmCreateNote
            // 
            this.AcceptButton = this.btnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grpStyling);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pictureBox1);
            this.MinimizeBox = false;
            this.Name = "FrmCreateNote";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.FrmCreateNote_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grpStyling.ResumeLayout(false);
            this.grpStyling.PerformLayout();
            this.panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.GroupBox grpStyling;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cbStyle;
        private System.Windows.Forms.Label lblStyle;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.WebBrowser wbStylePreview;
        private System.Windows.Forms.ErrorProvider errorProvider;

    }
}