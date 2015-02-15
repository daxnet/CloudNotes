namespace CloudNotes.DesktopClient
{
    partial class FrmChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChangePassword));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
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
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.errorProvider.SetError(this.label2, resources.GetString("label2.Error"));
            this.errorProvider.SetIconAlignment(this.label2, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label2.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.label2, ((int)(resources.GetObject("label2.IconPadding"))));
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.errorProvider.SetError(this.label3, resources.GetString("label3.Error"));
            this.errorProvider.SetIconAlignment(this.label3, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("label3.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.label3, ((int)(resources.GetObject("label3.IconPadding"))));
            this.label3.Name = "label3";
            // 
            // txtOldPassword
            // 
            resources.ApplyResources(this.txtOldPassword, "txtOldPassword");
            this.errorProvider.SetError(this.txtOldPassword, resources.GetString("txtOldPassword.Error"));
            this.errorProvider.SetIconAlignment(this.txtOldPassword, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txtOldPassword.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.txtOldPassword, ((int)(resources.GetObject("txtOldPassword.IconPadding"))));
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.UseSystemPasswordChar = true;
            // 
            // txtNewPassword
            // 
            resources.ApplyResources(this.txtNewPassword, "txtNewPassword");
            this.errorProvider.SetError(this.txtNewPassword, resources.GetString("txtNewPassword.Error"));
            this.errorProvider.SetIconAlignment(this.txtNewPassword, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txtNewPassword.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.txtNewPassword, ((int)(resources.GetObject("txtNewPassword.IconPadding"))));
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.UseSystemPasswordChar = true;
            // 
            // txtConfirmPassword
            // 
            resources.ApplyResources(this.txtConfirmPassword, "txtConfirmPassword");
            this.errorProvider.SetError(this.txtConfirmPassword, resources.GetString("txtConfirmPassword.Error"));
            this.errorProvider.SetIconAlignment(this.txtConfirmPassword, ((System.Windows.Forms.ErrorIconAlignment)(resources.GetObject("txtConfirmPassword.IconAlignment"))));
            this.errorProvider.SetIconPadding(this.txtConfirmPassword, ((int)(resources.GetObject("txtConfirmPassword.IconPadding"))));
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.UseSystemPasswordChar = true;
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
            // FrmChangePassword
            // 
            this.AcceptButton = this.btnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.txtOldPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmChangePassword";
            this.ShowInTaskbar = false;
            this.Shown += new System.EventHandler(this.FrmChangePassword_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOldPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}