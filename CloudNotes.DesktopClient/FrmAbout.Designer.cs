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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtLicense = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lstAssemblies = new System.Windows.Forms.ListView();
            this.colAssemblyName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAssemblyVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAssemblyFullName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAuthorName = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblBlog = new System.Windows.Forms.LinkLabel();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Controls.Add(this.txtLicense);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtLicense
            // 
            resources.ApplyResources(this.txtLicense, "txtLicense");
            this.txtLicense.Name = "txtLicense";
            this.txtLicense.ReadOnly = true;
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Controls.Add(this.lstAssemblies);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lstAssemblies
            // 
            resources.ApplyResources(this.lstAssemblies, "lstAssemblies");
            this.lstAssemblies.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAssemblyName,
            this.colAssemblyVersion,
            this.colAssemblyFullName});
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
            // 
            // tabPage4
            // 
            resources.ApplyResources(this.tabPage4, "tabPage4");
            this.tabPage4.Controls.Add(this.tableLayoutPanel1);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblAuthorName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblBlog, 1, 1);
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
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage4;
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
    }
}