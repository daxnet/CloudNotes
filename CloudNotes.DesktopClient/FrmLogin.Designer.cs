namespace CloudNotes.DesktopClient
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbServer = new System.Windows.Forms.ComboBox();
            this.chkRememberPassword = new System.Windows.Forms.CheckBox();
            this.chkAutomaticLogin = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbUserName = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnRegister = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblNewVersionNotify = new System.Windows.Forms.LinkLabel();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.errorProvider.SetError(this.label2, resources.GetString("label2.Error"));
            this.errorProvider.SetIconAlignment(this.label2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label2.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.label2, ((int)(resources.GetObject("label2.IconPadding"))));
            this.label2.Name = "label2";
            // 
            // txtPassword
            // 
            resources.ApplyResources(this.txtPassword, "txtPassword");
            this.errorProvider.SetError(this.txtPassword, resources.GetString("txtPassword.Error"));
            this.errorProvider.SetIconAlignment(this.txtPassword, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txtPassword.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.txtPassword, ((int)(resources.GetObject("txtPassword.IconPadding"))));
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.errorProvider.SetError(this.label3, resources.GetString("label3.Error"));
            this.errorProvider.SetIconAlignment(this.label3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label3.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.label3, ((int)(resources.GetObject("label3.IconPadding"))));
            this.label3.Name = "label3";
            // 
            // cbServer
            // 
            resources.ApplyResources(this.cbServer, "cbServer");
            this.cbServer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.errorProvider.SetError(this.cbServer, resources.GetString("cbServer.Error"));
            this.cbServer.FormattingEnabled = true;
            this.errorProvider.SetIconAlignment(this.cbServer, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cbServer.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.cbServer, ((int)(resources.GetObject("cbServer.IconPadding"))));
            this.cbServer.Name = "cbServer";
            // 
            // chkRememberPassword
            // 
            resources.ApplyResources(this.chkRememberPassword, "chkRememberPassword");
            this.errorProvider.SetError(this.chkRememberPassword, resources.GetString("chkRememberPassword.Error"));
            this.errorProvider.SetIconAlignment(this.chkRememberPassword, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("chkRememberPassword.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.chkRememberPassword, ((int)(resources.GetObject("chkRememberPassword.IconPadding"))));
            this.chkRememberPassword.Name = "chkRememberPassword";
            this.chkRememberPassword.UseVisualStyleBackColor = true;
            // 
            // chkAutomaticLogin
            // 
            resources.ApplyResources(this.chkAutomaticLogin, "chkAutomaticLogin");
            this.errorProvider.SetError(this.chkAutomaticLogin, resources.GetString("chkAutomaticLogin.Error"));
            this.errorProvider.SetIconAlignment(this.chkAutomaticLogin, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("chkAutomaticLogin.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.chkAutomaticLogin, ((int)(resources.GetObject("chkAutomaticLogin.IconPadding"))));
            this.chkAutomaticLogin.Name = "chkAutomaticLogin";
            this.chkAutomaticLogin.UseVisualStyleBackColor = true;
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
            // cbUserName
            // 
            resources.ApplyResources(this.cbUserName, "cbUserName");
            this.cbUserName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbUserName.ContextMenuStrip = this.contextMenuStrip1;
            this.errorProvider.SetError(this.cbUserName, resources.GetString("cbUserName.Error"));
            this.cbUserName.FormattingEnabled = true;
            this.errorProvider.SetIconAlignment(this.cbUserName, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("cbUserName.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.cbUserName, ((int)(resources.GetObject("cbUserName.IconPadding"))));
            this.cbUserName.Name = "cbUserName";
            this.cbUserName.SelectedIndexChanged += new System.EventHandler(this.cbUserName_SelectedIndexChanged);
            this.cbUserName.TextUpdate += new System.EventHandler(this.cbUserName_TextUpdate);
            // 
            // contextMenuStrip1
            // 
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.errorProvider.SetError(this.contextMenuStrip1, resources.GetString("contextMenuStrip1.Error"));
            this.errorProvider.SetIconAlignment(this.contextMenuStrip1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("contextMenuStrip1.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.contextMenuStrip1, ((int)(resources.GetObject("contextMenuStrip1.IconPadding"))));
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuDelete});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            // 
            // cmnuDelete
            // 
            resources.ApplyResources(this.cmnuDelete, "cmnuDelete");
            this.cmnuDelete.Image = global::CloudNotes.DesktopClient.Properties.Resources.Delete;
            this.cmnuDelete.Name = "cmnuDelete";
            this.cmnuDelete.Click += new System.EventHandler(this.Action_DeleteUserProfile);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            resources.ApplyResources(this.errorProvider, "errorProvider");
            // 
            // btnRegister
            // 
            resources.ApplyResources(this.btnRegister, "btnRegister");
            this.btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.errorProvider.SetError(this.btnRegister, resources.GetString("btnRegister.Error"));
            this.errorProvider.SetIconAlignment(this.btnRegister, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnRegister.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.btnRegister, ((int)(resources.GetObject("btnRegister.IconPadding"))));
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.TabStop = true;
            this.btnRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnRegister_LinkClicked);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.errorProvider.SetError(this.pictureBox1, resources.GetString("pictureBox1.Error"));
            this.errorProvider.SetIconAlignment(this.pictureBox1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("pictureBox1.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.pictureBox1, ((int)(resources.GetObject("pictureBox1.IconPadding"))));
            this.pictureBox1.Image = global::CloudNotes.DesktopClient.Properties.Resources.Login;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // lblNewVersionNotify
            // 
            resources.ApplyResources(this.lblNewVersionNotify, "lblNewVersionNotify");
            this.errorProvider.SetError(this.lblNewVersionNotify, resources.GetString("lblNewVersionNotify.Error"));
            this.errorProvider.SetIconAlignment(this.lblNewVersionNotify, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblNewVersionNotify.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.lblNewVersionNotify, ((int)(resources.GetObject("lblNewVersionNotify.IconPadding"))));
            this.lblNewVersionNotify.Image = global::CloudNotes.DesktopClient.Properties.Resources.exclam;
            this.lblNewVersionNotify.Name = "lblNewVersionNotify";
            this.lblNewVersionNotify.TabStop = true;
            this.lblNewVersionNotify.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblNewVersionNotify_LinkClicked);
            // 
            // FrmLogin
            // 
            this.AcceptButton = this.btnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.lblNewVersionNotify);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.cbUserName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkAutomaticLogin);
            this.Controls.Add(this.chkRememberPassword);
            this.Controls.Add(this.cbServer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLogin";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.Shown += new System.EventHandler(this.FrmLogin_Shown);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbServer;
        private System.Windows.Forms.CheckBox chkRememberPassword;
        private System.Windows.Forms.CheckBox chkAutomaticLogin;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cbUserName;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cmnuDelete;
        private System.Windows.Forms.LinkLabel btnRegister;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel lblNewVersionNotify;
    }
}