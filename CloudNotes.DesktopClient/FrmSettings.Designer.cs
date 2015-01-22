namespace CloudNotes.DesktopClient
{
    partial class FrmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSettings));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.lvExtensions = new System.Windows.Forms.ListView();
            this.colExtension = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpGeneral = new System.Windows.Forms.TabPage();
            this.cbLanguage = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tpExtensions = new System.Windows.Forms.TabPage();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            this.tpExtensions.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            resources.ApplyResources(this.splitContainer, "splitContainer");
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.lvExtensions);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.pnlSettings);
            // 
            // lvExtensions
            // 
            this.lvExtensions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colExtension});
            resources.ApplyResources(this.lvExtensions, "lvExtensions");
            this.lvExtensions.FullRowSelect = true;
            this.lvExtensions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvExtensions.HideSelection = false;
            this.lvExtensions.MultiSelect = false;
            this.lvExtensions.Name = "lvExtensions";
            this.lvExtensions.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvExtensions.UseCompatibleStateImageBehavior = false;
            this.lvExtensions.View = System.Windows.Forms.View.Details;
            this.lvExtensions.SelectedIndexChanged += new System.EventHandler(this.lvExtensions_SelectedIndexChanged);
            // 
            // colExtension
            // 
            resources.ApplyResources(this.colExtension, "colExtension");
            // 
            // pnlSettings
            // 
            resources.ApplyResources(this.pnlSettings, "pnlSettings");
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.pnlSettings_ControlRemoved);
            // 
            // fontDialog
            // 
            this.fontDialog.AllowScriptChange = false;
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Name = "btnOK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Controls.Add(this.tpGeneral);
            this.tabControl.Controls.Add(this.tpExtensions);
            this.tabControl.ImageList = this.imageList;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            // 
            // tpGeneral
            // 
            this.tpGeneral.Controls.Add(this.cbLanguage);
            this.tpGeneral.Controls.Add(this.label1);
            resources.ApplyResources(this.tpGeneral, "tpGeneral");
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.UseVisualStyleBackColor = true;
            // 
            // cbLanguage
            // 
            this.cbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLanguage.FormattingEnabled = true;
            resources.ApplyResources(this.cbLanguage, "cbLanguage");
            this.cbLanguage.Name = "cbLanguage";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // tpExtensions
            // 
            this.tpExtensions.Controls.Add(this.splitContainer);
            resources.ApplyResources(this.tpExtensions, "tpExtensions");
            this.tpExtensions.Name = "tpExtensions";
            this.tpExtensions.UseVisualStyleBackColor = true;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "cog.png");
            this.imageList.Images.SetKeyName(1, "plugin.png");
            // 
            // FrmSettings
            // 
            this.AcceptButton = this.btnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Name = "FrmSettings";
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.FrmSettings_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tpGeneral.ResumeLayout(false);
            this.tpGeneral.PerformLayout();
            this.tpExtensions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpGeneral;
        private System.Windows.Forms.ComboBox cbLanguage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tpExtensions;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ListView lvExtensions;
        private System.Windows.Forms.ColumnHeader colExtension;
        private System.Windows.Forms.Panel pnlSettings;
    }
}