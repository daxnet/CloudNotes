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
            this.ilExtensions = new System.Windows.Forms.ImageList(this.components);
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.fontDialog = new System.Windows.Forms.FontDialog();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpGeneral = new System.Windows.Forms.TabPage();
            this.groupBoxLocalization = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblOnlyShowWhenMoreThan = new System.Windows.Forms.Label();
            this.numMaxExtensionsLoaded = new System.Windows.Forms.NumericUpDown();
            this.chkOnlyShowWhenMoreThan = new System.Windows.Forms.CheckBox();
            this.chkShowExtensionInMenuGroup = new System.Windows.Forms.CheckBox();
            this.cbLanguage = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tpComposing = new System.Windows.Forms.TabPage();
            this.grpStylePreview = new System.Windows.Forms.GroupBox();
            this.pnlStylePreview = new System.Windows.Forms.Panel();
            this.wbStylePreview = new System.Windows.Forms.WebBrowser();
            this.txtStyleDescription = new System.Windows.Forms.TextBox();
            this.txtStyleCreationDate = new System.Windows.Forms.TextBox();
            this.txtStyleAuthor = new System.Windows.Forms.TextBox();
            this.lblStyleDescription = new System.Windows.Forms.Label();
            this.lblStyleCreationDate = new System.Windows.Forms.Label();
            this.lblStyleAuthor = new System.Windows.Forms.Label();
            this.cbDefaultStyle = new System.Windows.Forms.ComboBox();
            this.lblDefaultStyle = new System.Windows.Forms.Label();
            this.tpExtensions = new System.Windows.Forms.TabPage();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            this.groupBoxLocalization.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxExtensionsLoaded)).BeginInit();
            this.tpComposing.SuspendLayout();
            this.grpStylePreview.SuspendLayout();
            this.pnlStylePreview.SuspendLayout();
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
            resources.ApplyResources(this.splitContainer.Panel1, "splitContainer.Panel1");
            this.splitContainer.Panel1.Controls.Add(this.lvExtensions);
            // 
            // splitContainer.Panel2
            // 
            resources.ApplyResources(this.splitContainer.Panel2, "splitContainer.Panel2");
            this.splitContainer.Panel2.Controls.Add(this.pnlSettings);
            // 
            // lvExtensions
            // 
            resources.ApplyResources(this.lvExtensions, "lvExtensions");
            this.lvExtensions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colExtension});
            this.lvExtensions.FullRowSelect = true;
            this.lvExtensions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvExtensions.HideSelection = false;
            this.lvExtensions.MultiSelect = false;
            this.lvExtensions.Name = "lvExtensions";
            this.lvExtensions.SmallImageList = this.ilExtensions;
            this.lvExtensions.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvExtensions.UseCompatibleStateImageBehavior = false;
            this.lvExtensions.View = System.Windows.Forms.View.Details;
            this.lvExtensions.SelectedIndexChanged += new System.EventHandler(this.lvExtensions_SelectedIndexChanged);
            // 
            // colExtension
            // 
            resources.ApplyResources(this.colExtension, "colExtension");
            // 
            // ilExtensions
            // 
            this.ilExtensions.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            resources.ApplyResources(this.ilExtensions, "ilExtensions");
            this.ilExtensions.TransparentColor = System.Drawing.Color.Transparent;
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
            this.tabControl.Controls.Add(this.tpComposing);
            this.tabControl.Controls.Add(this.tpExtensions);
            this.tabControl.ImageList = this.imageList;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            // 
            // tpGeneral
            // 
            resources.ApplyResources(this.tpGeneral, "tpGeneral");
            this.tpGeneral.Controls.Add(this.groupBoxLocalization);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.UseVisualStyleBackColor = true;
            // 
            // groupBoxLocalization
            // 
            resources.ApplyResources(this.groupBoxLocalization, "groupBoxLocalization");
            this.groupBoxLocalization.Controls.Add(this.label3);
            this.groupBoxLocalization.Controls.Add(this.lblOnlyShowWhenMoreThan);
            this.groupBoxLocalization.Controls.Add(this.numMaxExtensionsLoaded);
            this.groupBoxLocalization.Controls.Add(this.chkOnlyShowWhenMoreThan);
            this.groupBoxLocalization.Controls.Add(this.chkShowExtensionInMenuGroup);
            this.groupBoxLocalization.Controls.Add(this.cbLanguage);
            this.groupBoxLocalization.Controls.Add(this.label1);
            this.groupBoxLocalization.Name = "groupBoxLocalization";
            this.groupBoxLocalization.TabStop = false;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Image = global::CloudNotes.DesktopClient.Properties.Resources.exclam;
            this.label3.Name = "label3";
            // 
            // lblOnlyShowWhenMoreThan
            // 
            resources.ApplyResources(this.lblOnlyShowWhenMoreThan, "lblOnlyShowWhenMoreThan");
            this.lblOnlyShowWhenMoreThan.Image = global::CloudNotes.DesktopClient.Properties.Resources.exclam;
            this.lblOnlyShowWhenMoreThan.Name = "lblOnlyShowWhenMoreThan";
            // 
            // numMaxExtensionsLoaded
            // 
            resources.ApplyResources(this.numMaxExtensionsLoaded, "numMaxExtensionsLoaded");
            this.numMaxExtensionsLoaded.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numMaxExtensionsLoaded.Name = "numMaxExtensionsLoaded";
            // 
            // chkOnlyShowWhenMoreThan
            // 
            resources.ApplyResources(this.chkOnlyShowWhenMoreThan, "chkOnlyShowWhenMoreThan");
            this.chkOnlyShowWhenMoreThan.Name = "chkOnlyShowWhenMoreThan";
            this.chkOnlyShowWhenMoreThan.UseVisualStyleBackColor = true;
            // 
            // chkShowExtensionInMenuGroup
            // 
            resources.ApplyResources(this.chkShowExtensionInMenuGroup, "chkShowExtensionInMenuGroup");
            this.chkShowExtensionInMenuGroup.Image = global::CloudNotes.DesktopClient.Properties.Resources.exclam;
            this.chkShowExtensionInMenuGroup.Name = "chkShowExtensionInMenuGroup";
            this.chkShowExtensionInMenuGroup.UseVisualStyleBackColor = true;
            this.chkShowExtensionInMenuGroup.Click += new System.EventHandler(this.chkShowExtensionInMenuGroup_Click);
            // 
            // cbLanguage
            // 
            resources.ApplyResources(this.cbLanguage, "cbLanguage");
            this.cbLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLanguage.FormattingEnabled = true;
            this.cbLanguage.Name = "cbLanguage";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // tpComposing
            // 
            resources.ApplyResources(this.tpComposing, "tpComposing");
            this.tpComposing.Controls.Add(this.grpStylePreview);
            this.tpComposing.Controls.Add(this.cbDefaultStyle);
            this.tpComposing.Controls.Add(this.lblDefaultStyle);
            this.tpComposing.Name = "tpComposing";
            this.tpComposing.UseVisualStyleBackColor = true;
            // 
            // grpStylePreview
            // 
            resources.ApplyResources(this.grpStylePreview, "grpStylePreview");
            this.grpStylePreview.Controls.Add(this.pnlStylePreview);
            this.grpStylePreview.Controls.Add(this.txtStyleDescription);
            this.grpStylePreview.Controls.Add(this.txtStyleCreationDate);
            this.grpStylePreview.Controls.Add(this.txtStyleAuthor);
            this.grpStylePreview.Controls.Add(this.lblStyleDescription);
            this.grpStylePreview.Controls.Add(this.lblStyleCreationDate);
            this.grpStylePreview.Controls.Add(this.lblStyleAuthor);
            this.grpStylePreview.Name = "grpStylePreview";
            this.grpStylePreview.TabStop = false;
            // 
            // pnlStylePreview
            // 
            resources.ApplyResources(this.pnlStylePreview, "pnlStylePreview");
            this.pnlStylePreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlStylePreview.Controls.Add(this.wbStylePreview);
            this.pnlStylePreview.Name = "pnlStylePreview";
            // 
            // wbStylePreview
            // 
            resources.ApplyResources(this.wbStylePreview, "wbStylePreview");
            this.wbStylePreview.AllowWebBrowserDrop = false;
            this.wbStylePreview.IsWebBrowserContextMenuEnabled = false;
            this.wbStylePreview.Name = "wbStylePreview";
            this.wbStylePreview.ScriptErrorsSuppressed = true;
            this.wbStylePreview.WebBrowserShortcutsEnabled = false;
            // 
            // txtStyleDescription
            // 
            resources.ApplyResources(this.txtStyleDescription, "txtStyleDescription");
            this.txtStyleDescription.Name = "txtStyleDescription";
            this.txtStyleDescription.ReadOnly = true;
            // 
            // txtStyleCreationDate
            // 
            resources.ApplyResources(this.txtStyleCreationDate, "txtStyleCreationDate");
            this.txtStyleCreationDate.Name = "txtStyleCreationDate";
            this.txtStyleCreationDate.ReadOnly = true;
            // 
            // txtStyleAuthor
            // 
            resources.ApplyResources(this.txtStyleAuthor, "txtStyleAuthor");
            this.txtStyleAuthor.Name = "txtStyleAuthor";
            this.txtStyleAuthor.ReadOnly = true;
            // 
            // lblStyleDescription
            // 
            resources.ApplyResources(this.lblStyleDescription, "lblStyleDescription");
            this.lblStyleDescription.Name = "lblStyleDescription";
            // 
            // lblStyleCreationDate
            // 
            resources.ApplyResources(this.lblStyleCreationDate, "lblStyleCreationDate");
            this.lblStyleCreationDate.Name = "lblStyleCreationDate";
            // 
            // lblStyleAuthor
            // 
            resources.ApplyResources(this.lblStyleAuthor, "lblStyleAuthor");
            this.lblStyleAuthor.Name = "lblStyleAuthor";
            // 
            // cbDefaultStyle
            // 
            resources.ApplyResources(this.cbDefaultStyle, "cbDefaultStyle");
            this.cbDefaultStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDefaultStyle.FormattingEnabled = true;
            this.cbDefaultStyle.Name = "cbDefaultStyle";
            this.cbDefaultStyle.SelectedIndexChanged += new System.EventHandler(this.cbDefaultStyle_SelectedIndexChanged);
            // 
            // lblDefaultStyle
            // 
            resources.ApplyResources(this.lblDefaultStyle, "lblDefaultStyle");
            this.lblDefaultStyle.Name = "lblDefaultStyle";
            // 
            // tpExtensions
            // 
            resources.ApplyResources(this.tpExtensions, "tpExtensions");
            this.tpExtensions.Controls.Add(this.splitContainer);
            this.tpExtensions.Name = "tpExtensions";
            this.tpExtensions.UseVisualStyleBackColor = true;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "cog.png");
            this.imageList.Images.SetKeyName(1, "page_white_edit.png");
            this.imageList.Images.SetKeyName(2, "plugin.png");
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Image = global::CloudNotes.DesktopClient.Properties.Resources.exclam;
            this.label4.Name = "label4";
            // 
            // FrmSettings
            // 
            this.AcceptButton = this.btnOK;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.label4);
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
            this.groupBoxLocalization.ResumeLayout(false);
            this.groupBoxLocalization.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxExtensionsLoaded)).EndInit();
            this.tpComposing.ResumeLayout(false);
            this.tpComposing.PerformLayout();
            this.grpStylePreview.ResumeLayout(false);
            this.grpStylePreview.PerformLayout();
            this.pnlStylePreview.ResumeLayout(false);
            this.tpExtensions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FontDialog fontDialog;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpGeneral;
        private System.Windows.Forms.TabPage tpExtensions;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ListView lvExtensions;
        private System.Windows.Forms.ColumnHeader colExtension;
        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.ImageList ilExtensions;
        private System.Windows.Forms.GroupBox groupBoxLocalization;
        private System.Windows.Forms.ComboBox cbLanguage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkShowExtensionInMenuGroup;
        private System.Windows.Forms.Label lblOnlyShowWhenMoreThan;
        private System.Windows.Forms.NumericUpDown numMaxExtensionsLoaded;
        private System.Windows.Forms.CheckBox chkOnlyShowWhenMoreThan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tpComposing;
        private System.Windows.Forms.Label lblDefaultStyle;
        private System.Windows.Forms.ComboBox cbDefaultStyle;
        private System.Windows.Forms.GroupBox grpStylePreview;
        private System.Windows.Forms.Label lblStyleDescription;
        private System.Windows.Forms.Label lblStyleCreationDate;
        private System.Windows.Forms.Label lblStyleAuthor;
        private System.Windows.Forms.TextBox txtStyleAuthor;
        private System.Windows.Forms.TextBox txtStyleDescription;
        private System.Windows.Forms.TextBox txtStyleCreationDate;
        private System.Windows.Forms.Panel pnlStylePreview;
        private System.Windows.Forms.WebBrowser wbStylePreview;
    }
}