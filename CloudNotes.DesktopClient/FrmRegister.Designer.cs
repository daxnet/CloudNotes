namespace CloudNotes.DesktopClient
{
    partial class FrmRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegister));
            this.lblUserName = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConfirm = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            resources.ApplyResources(this.lblUserName, "lblUserName");
            this.errorProvider.SetError(this.lblUserName, resources.GetString("lblUserName.Error"));
            this.errorProvider.SetIconAlignment(this.lblUserName, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblUserName.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.lblUserName, ((int)(resources.GetObject("lblUserName.IconPadding"))));
            this.lblUserName.Name = "lblUserName";
            this.toolTip.SetToolTip(this.lblUserName, resources.GetString("lblUserName.ToolTip"));
            // 
            // txtUserName
            // 
            resources.ApplyResources(this.txtUserName, "txtUserName");
            this.errorProvider.SetError(this.txtUserName, resources.GetString("txtUserName.Error"));
            this.errorProvider.SetIconAlignment(this.txtUserName, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txtUserName.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.txtUserName, ((int)(resources.GetObject("txtUserName.IconPadding"))));
            this.txtUserName.Name = "txtUserName";
            this.toolTip.SetToolTip(this.txtUserName, resources.GetString("txtUserName.ToolTip"));
            // 
            // lblPassword
            // 
            resources.ApplyResources(this.lblPassword, "lblPassword");
            this.errorProvider.SetError(this.lblPassword, resources.GetString("lblPassword.Error"));
            this.errorProvider.SetIconAlignment(this.lblPassword, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("lblPassword.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.lblPassword, ((int)(resources.GetObject("lblPassword.IconPadding"))));
            this.lblPassword.Name = "lblPassword";
            this.toolTip.SetToolTip(this.lblPassword, resources.GetString("lblPassword.ToolTip"));
            // 
            // txtPassword
            // 
            resources.ApplyResources(this.txtPassword, "txtPassword");
            this.errorProvider.SetError(this.txtPassword, resources.GetString("txtPassword.Error"));
            this.errorProvider.SetIconAlignment(this.txtPassword, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txtPassword.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.txtPassword, ((int)(resources.GetObject("txtPassword.IconPadding"))));
            this.txtPassword.Name = "txtPassword";
            this.toolTip.SetToolTip(this.txtPassword, resources.GetString("txtPassword.ToolTip"));
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.errorProvider.SetError(this.pictureBox1, resources.GetString("pictureBox1.Error"));
            this.errorProvider.SetIconAlignment(this.pictureBox1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("pictureBox1.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.pictureBox1, ((int)(resources.GetObject("pictureBox1.IconPadding"))));
            this.pictureBox1.Image = global::CloudNotes.DesktopClient.Properties.Resources.register;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.toolTip.SetToolTip(this.pictureBox1, resources.GetString("pictureBox1.ToolTip"));
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.errorProvider.SetError(this.label1, resources.GetString("label1.Error"));
            this.errorProvider.SetIconAlignment(this.label1, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label1.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.label1, ((int)(resources.GetObject("label1.IconPadding"))));
            this.label1.Name = "label1";
            this.toolTip.SetToolTip(this.label1, resources.GetString("label1.ToolTip"));
            // 
            // txtConfirm
            // 
            resources.ApplyResources(this.txtConfirm, "txtConfirm");
            this.errorProvider.SetError(this.txtConfirm, resources.GetString("txtConfirm.Error"));
            this.errorProvider.SetIconAlignment(this.txtConfirm, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txtConfirm.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.txtConfirm, ((int)(resources.GetObject("txtConfirm.IconPadding"))));
            this.txtConfirm.Name = "txtConfirm";
            this.toolTip.SetToolTip(this.txtConfirm, resources.GetString("txtConfirm.ToolTip"));
            this.txtConfirm.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.errorProvider.SetError(this.label2, resources.GetString("label2.Error"));
            this.errorProvider.SetIconAlignment(this.label2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label2.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.label2, ((int)(resources.GetObject("label2.IconPadding"))));
            this.label2.Name = "label2";
            this.toolTip.SetToolTip(this.label2, resources.GetString("label2.ToolTip"));
            // 
            // txtEmail
            // 
            resources.ApplyResources(this.txtEmail, "txtEmail");
            this.errorProvider.SetError(this.txtEmail, resources.GetString("txtEmail.Error"));
            this.errorProvider.SetIconAlignment(this.txtEmail, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txtEmail.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.txtEmail, ((int)(resources.GetObject("txtEmail.IconPadding"))));
            this.txtEmail.Name = "txtEmail";
            this.toolTip.SetToolTip(this.txtEmail, resources.GetString("txtEmail.ToolTip"));
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            resources.ApplyResources(this.errorProvider, "errorProvider");
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.errorProvider.SetError(this.btnOK, resources.GetString("btnOK.Error"));
            this.errorProvider.SetIconAlignment(this.btnOK, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("btnOK.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.btnOK, ((int)(resources.GetObject("btnOK.IconPadding"))));
            this.btnOK.Name = "btnOK";
            this.toolTip.SetToolTip(this.btnOK, resources.GetString("btnOK.ToolTip"));
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
            this.toolTip.SetToolTip(this.btnCancel, resources.GetString("btnCancel.ToolTip"));
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.errorProvider.SetError(this.label3, resources.GetString("label3.Error"));
            this.errorProvider.SetIconAlignment(this.label3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label3.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.label3, ((int)(resources.GetObject("label3.IconPadding"))));
            this.label3.Name = "label3";
            this.toolTip.SetToolTip(this.label3, resources.GetString("label3.ToolTip"));
            // 
            // txtServer
            // 
            resources.ApplyResources(this.txtServer, "txtServer");
            this.errorProvider.SetError(this.txtServer, resources.GetString("txtServer.Error"));
            this.errorProvider.SetIconAlignment(this.txtServer, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txtServer.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.txtServer, ((int)(resources.GetObject("txtServer.IconPadding"))));
            this.txtServer.Name = "txtServer";
            this.toolTip.SetToolTip(this.txtServer, resources.GetString("txtServer.ToolTip"));
            // 
            // toolTip
            // 
            this.toolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // FrmRegister
            // 
            this.AcceptButton = this.btnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtConfirm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.lblUserName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRegister";
            this.ShowInTaskbar = false;
            this.toolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.Load += new System.EventHandler(this.FrmRegister_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConfirm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip toolTip;
    }
}