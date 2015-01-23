namespace CloudNotes.DesktopClient
{
    partial class FrmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAbout));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpLicense = new System.Windows.Forms.TabPage();
            this.txtLicense = new System.Windows.Forms.TextBox();
            this.tpRefAssemblies = new System.Windows.Forms.TabPage();
            this.lstAssemblies = new System.Windows.Forms.ListView();
            this.colAssemblyName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAssemblyVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAssemblyFullName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tpExtensions = new System.Windows.Forms.TabPage();
            this.lstExtensions = new System.Windows.Forms.ListView();
            this.colExtensionName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colExtensionVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colExtensionManufacture = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colExtensionDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ilExtensions = new System.Windows.Forms.ImageList(this.components);
            this.tpDonate = new System.Windows.Forms.TabPage();
            this.lblDonateLink = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.tpAuthor = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAuthorName = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblBlog = new System.Windows.Forms.LinkLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tpLicense.SuspendLayout();
            this.tpRefAssemblies.SuspendLayout();
            this.tpExtensions.SuspendLayout();
            this.tpDonate.SuspendLayout();
            this.tpAuthor.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Image = global::CloudNotes.DesktopClient.Properties.Resources.Login;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel
            // 
            resources.ApplyResources(this.tableLayoutPanel, "tableLayoutPanel");
            this.tableLayoutPanel.Controls.Add(this.lblTitle, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.tabControl, 0, 1);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            // 
            // lblTitle
            // 
            resources.ApplyResources(this.lblTitle, "lblTitle");
            this.lblTitle.Name = "lblTitle";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tpLicense);
            this.tabControl.Controls.Add(this.tpRefAssemblies);
            this.tabControl.Controls.Add(this.tpExtensions);
            this.tabControl.Controls.Add(this.tpDonate);
            this.tabControl.Controls.Add(this.tpAuthor);
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.ImageList = this.imageList;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            // 
            // tpLicense
            // 
            this.tpLicense.Controls.Add(this.txtLicense);
            resources.ApplyResources(this.tpLicense, "tpLicense");
            this.tpLicense.Name = "tpLicense";
            this.tpLicense.UseVisualStyleBackColor = true;
            // 
            // txtLicense
            // 
            resources.ApplyResources(this.txtLicense, "txtLicense");
            this.txtLicense.Name = "txtLicense";
            this.txtLicense.ReadOnly = true;
            // 
            // tpRefAssemblies
            // 
            this.tpRefAssemblies.Controls.Add(this.lstAssemblies);
            resources.ApplyResources(this.tpRefAssemblies, "tpRefAssemblies");
            this.tpRefAssemblies.Name = "tpRefAssemblies";
            this.tpRefAssemblies.UseVisualStyleBackColor = true;
            // 
            // lstAssemblies
            // 
            this.lstAssemblies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAssemblyName,
            this.colAssemblyVersion,
            this.colAssemblyFullName});
            resources.ApplyResources(this.lstAssemblies, "lstAssemblies");
            this.lstAssemblies.FullRowSelect = true;
            this.lstAssemblies.HideSelection = false;
            this.lstAssemblies.MultiSelect = false;
            this.lstAssemblies.Name = "lstAssemblies";
            this.lstAssemblies.SmallImageList = this.imageList;
            this.lstAssemblies.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstAssemblies.UseCompatibleStateImageBehavior = false;
            this.lstAssemblies.View = System.Windows.Forms.View.Details;
            // 
            // colAssemblyName
            // 
            resources.ApplyResources(this.colAssemblyName, "colAssemblyName");
            // 
            // colAssemblyVersion
            // 
            resources.ApplyResources(this.colAssemblyVersion, "colAssemblyVersion");
            // 
            // colAssemblyFullName
            // 
            resources.ApplyResources(this.colAssemblyFullName, "colAssemblyFullName");
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Assembly.png");
            this.imageList.Images.SetKeyName(1, "License");
            this.imageList.Images.SetKeyName(2, "Donate");
            this.imageList.Images.SetKeyName(3, "Person");
            this.imageList.Images.SetKeyName(4, "plugin.png");
            // 
            // tpExtensions
            // 
            this.tpExtensions.Controls.Add(this.lstExtensions);
            resources.ApplyResources(this.tpExtensions, "tpExtensions");
            this.tpExtensions.Name = "tpExtensions";
            this.tpExtensions.UseVisualStyleBackColor = true;
            // 
            // lstExtensions
            // 
            this.lstExtensions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colExtensionName,
            this.colExtensionVersion,
            this.colExtensionManufacture,
            this.colExtensionDescription});
            resources.ApplyResources(this.lstExtensions, "lstExtensions");
            this.lstExtensions.FullRowSelect = true;
            this.lstExtensions.HideSelection = false;
            this.lstExtensions.MultiSelect = false;
            this.lstExtensions.Name = "lstExtensions";
            this.lstExtensions.SmallImageList = this.ilExtensions;
            this.lstExtensions.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstExtensions.UseCompatibleStateImageBehavior = false;
            this.lstExtensions.View = System.Windows.Forms.View.Details;
            // 
            // colExtensionName
            // 
            resources.ApplyResources(this.colExtensionName, "colExtensionName");
            // 
            // colExtensionVersion
            // 
            resources.ApplyResources(this.colExtensionVersion, "colExtensionVersion");
            // 
            // colExtensionManufacture
            // 
            resources.ApplyResources(this.colExtensionManufacture, "colExtensionManufacture");
            // 
            // colExtensionDescription
            // 
            resources.ApplyResources(this.colExtensionDescription, "colExtensionDescription");
            // 
            // ilExtensions
            // 
            this.ilExtensions.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            resources.ApplyResources(this.ilExtensions, "ilExtensions");
            this.ilExtensions.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tpDonate
            // 
            this.tpDonate.Controls.Add(this.lblDonateLink);
            this.tpDonate.Controls.Add(this.label3);
            resources.ApplyResources(this.tpDonate, "tpDonate");
            this.tpDonate.Name = "tpDonate";
            this.tpDonate.UseVisualStyleBackColor = true;
            // 
            // lblDonateLink
            // 
            resources.ApplyResources(this.lblDonateLink, "lblDonateLink");
            this.lblDonateLink.Name = "lblDonateLink";
            this.lblDonateLink.TabStop = true;
            this.lblDonateLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblDonateLink_LinkClicked);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // tpAuthor
            // 
            this.tpAuthor.Controls.Add(this.tableLayoutPanel1);
            resources.ApplyResources(this.tpAuthor, "tpAuthor");
            this.tpAuthor.Name = "tpAuthor";
            this.tpAuthor.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblAuthorName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblBlog, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox2, 1, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // lblAuthorName
            // 
            resources.ApplyResources(this.lblAuthorName, "lblAuthorName");
            this.lblAuthorName.Name = "lblAuthorName";
            this.lblAuthorName.TabStop = true;
            this.lblAuthorName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAuthorName_LinkClicked);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // lblBlog
            // 
            resources.ApplyResources(this.lblBlog, "lblBlog");
            this.lblBlog.Name = "lblBlog";
            this.lblBlog.TabStop = true;
            this.lblBlog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblBlog_LinkClicked);
            // 
            // pictureBox2
            // 
            resources.ApplyResources(this.pictureBox2, "pictureBox2");
            this.pictureBox2.Image = global::CloudNotes.DesktopClient.Properties.Resources.MVP_Horizontal_FullColor;
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.TabStop = false;
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // FrmAbout
            // 
            this.AcceptButton = this.btnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAbout";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.FrmAbout_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tpLicense.ResumeLayout(false);
            this.tpLicense.PerformLayout();
            this.tpRefAssemblies.ResumeLayout(false);
            this.tpExtensions.ResumeLayout(false);
            this.tpDonate.ResumeLayout(false);
            this.tpAuthor.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpLicense;
        private System.Windows.Forms.TabPage tpRefAssemblies;
        private System.Windows.Forms.TabPage tpAuthor;
        private System.Windows.Forms.TextBox txtLicense;
        private System.Windows.Forms.ListView lstAssemblies;
        private System.Windows.Forms.ColumnHeader colAssemblyName;
        private System.Windows.Forms.ColumnHeader colAssemblyVersion;
        private System.Windows.Forms.ColumnHeader colAssemblyFullName;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lblAuthorName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lblBlog;
        private System.Windows.Forms.TabPage tpDonate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel lblDonateLink;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TabPage tpExtensions;
        private System.Windows.Forms.ListView lstExtensions;
        private System.Windows.Forms.ColumnHeader colExtensionName;
        private System.Windows.Forms.ColumnHeader colExtensionVersion;
        private System.Windows.Forms.ColumnHeader colExtensionManufacture;
        private System.Windows.Forms.ColumnHeader colExtensionDescription;
        private System.Windows.Forms.ImageList ilExtensions;
    }
}