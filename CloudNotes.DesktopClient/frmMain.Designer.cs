namespace CloudNotes.DesktopClient
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.tvNotes = new CloudNotes.DesktopClient.Controls.TreeViewEx();
            this.tvImageList = new System.Windows.Forms.ImageList(this.components);
            this.htmlEditor = new YARTE.UI.HtmlEditor();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDatePublished = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuReconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNote = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPermanentDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRename = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEmptyTrash = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSourceCodeRepository = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCloudNotesTech = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tbtnNew = new System.Windows.Forms.ToolStripButton();
            this.tbtnOpen = new System.Windows.Forms.ToolStripButton();
            this.tbtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnDelete = new System.Windows.Forms.ToolStripButton();
            this.tbtnRename = new System.Windows.Forms.ToolStripButton();
            this.tbtnRestore = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnSettings = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.slblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.slblUpdateAvailable = new System.Windows.Forms.ToolStripStatusLabel();
            this.sp = new System.Windows.Forms.ToolStripProgressBar();
            this.tabImageList = new System.Windows.Forms.ImageList(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayIconContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuOpenMainWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMnuNotesNode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMnuTrashNode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuEmptyTrash = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxMnuNoteNode = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuPermanentDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuRename = new System.Windows.Forms.ToolStripMenuItem();
            this.cmnuRestore = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.trayIconContextMenu.SuspendLayout();
            this.ctxMnuNotesNode.SuspendLayout();
            this.ctxMnuTrashNode.SuspendLayout();
            this.ctxMnuNoteNode.SuspendLayout();
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
            this.splitContainer.Panel1.Controls.Add(this.pnlLeft);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.htmlEditor);
            this.splitContainer.Panel2.Controls.Add(this.tableLayoutPanel);
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.tvNotes);
            resources.ApplyResources(this.pnlLeft, "pnlLeft");
            this.pnlLeft.Name = "pnlLeft";
            // 
            // tvNotes
            // 
            this.tvNotes.DescriptionFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvNotes.DescriptionIndent = 2;
            this.tvNotes.DescriptionTextColor = System.Drawing.Color.DarkGray;
            resources.ApplyResources(this.tvNotes, "tvNotes");
            this.tvNotes.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.tvNotes.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tvNotes.FullRowSelect = true;
            this.tvNotes.HideSelection = false;
            this.tvNotes.HighlightBackgroundColor = System.Drawing.Color.SkyBlue;
            this.tvNotes.HighlightTextColor = System.Drawing.SystemColors.HighlightText;
            this.tvNotes.ImageList = this.tvImageList;
            this.tvNotes.ImageWidth = 65;
            this.tvNotes.ItemHeight = 34;
            this.tvNotes.LabelEdit = true;
            this.tvNotes.Name = "tvNotes";
            this.tvNotes.NormalTextBackgroundColor = System.Drawing.SystemColors.Window;
            this.tvNotes.ShowLines = false;
            this.tvNotes.TitleColor = System.Drawing.Color.DodgerBlue;
            this.tvNotes.TitleFont = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvNotes.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvNotes_BeforeLabelEdit);
            this.tvNotes.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvNotes_AfterLabelEdit);
            this.tvNotes.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvNotes_AfterSelect);
            this.tvNotes.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvNotes_NodeMouseClick);
            this.tvNotes.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvNotes_NodeMouseDoubleClick);
            // 
            // tvImageList
            // 
            this.tvImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("tvImageList.ImageStream")));
            this.tvImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.tvImageList.Images.SetKeyName(0, "note.png");
            this.tvImageList.Images.SetKeyName(1, "trash.png");
            // 
            // htmlEditor
            // 
            resources.ApplyResources(this.htmlEditor, "htmlEditor");
            this.htmlEditor.Html = resources.GetString("htmlEditor.Html");
            this.htmlEditor.Name = "htmlEditor";
            this.htmlEditor.ReadOnly = false;
            this.htmlEditor.ShowToolbar = true;
            // 
            // tableLayoutPanel
            // 
            resources.ApplyResources(this.tableLayoutPanel, "tableLayoutPanel");
            this.tableLayoutPanel.Controls.Add(this.lblTitle, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.lblDatePublished, 1, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            // 
            // lblTitle
            // 
            resources.ApplyResources(this.lblTitle, "lblTitle");
            this.lblTitle.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblTitle.Name = "lblTitle";
            // 
            // lblDatePublished
            // 
            resources.ApplyResources(this.lblDatePublished, "lblDatePublished");
            this.lblDatePublished.ForeColor = System.Drawing.Color.Gray;
            this.lblDatePublished.Name = "lblDatePublished";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuNote,
            this.mnuTools,
            this.mnuHelp});
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.Name = "menuStrip";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNew,
            this.mnuOpen,
            this.mnuSave,
            this.toolStripMenuItem6,
            this.mnuPrint,
            this.toolStripMenuItem1,
            this.mnuReconnect,
            this.toolStripMenuItem3,
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            resources.ApplyResources(this.mnuFile, "mnuFile");
            // 
            // mnuNew
            // 
            resources.ApplyResources(this.mnuNew, "mnuNew");
            this.mnuNew.Name = "mnuNew";
            this.mnuNew.Click += new System.EventHandler(this.Action_New);
            // 
            // mnuOpen
            // 
            resources.ApplyResources(this.mnuOpen, "mnuOpen");
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Click += new System.EventHandler(this.Action_Open);
            // 
            // mnuSave
            // 
            resources.ApplyResources(this.mnuSave, "mnuSave");
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.Click += new System.EventHandler(this.Action_Save);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            resources.ApplyResources(this.toolStripMenuItem6, "toolStripMenuItem6");
            // 
            // mnuPrint
            // 
            this.mnuPrint.Image = global::CloudNotes.DesktopClient.Properties.Resources.printer;
            this.mnuPrint.Name = "mnuPrint";
            resources.ApplyResources(this.mnuPrint, "mnuPrint");
            this.mnuPrint.Click += new System.EventHandler(this.Action_Print);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            // 
            // mnuReconnect
            // 
            resources.ApplyResources(this.mnuReconnect, "mnuReconnect");
            this.mnuReconnect.Name = "mnuReconnect";
            this.mnuReconnect.Click += new System.EventHandler(this.Action_Reconnect);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            // 
            // mnuExit
            // 
            resources.ApplyResources(this.mnuExit, "mnuExit");
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Click += new System.EventHandler(this.Action_Exit);
            // 
            // mnuNote
            // 
            this.mnuNote.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDelete,
            this.mnuPermanentDelete,
            this.mnuRename,
            this.mnuRestore,
            this.toolStripMenuItem5,
            this.mnuEmptyTrash});
            this.mnuNote.Name = "mnuNote";
            resources.ApplyResources(this.mnuNote, "mnuNote");
            // 
            // mnuDelete
            // 
            resources.ApplyResources(this.mnuDelete, "mnuDelete");
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Click += new System.EventHandler(this.Action_Delete);
            // 
            // mnuPermanentDelete
            // 
            this.mnuPermanentDelete.Name = "mnuPermanentDelete";
            resources.ApplyResources(this.mnuPermanentDelete, "mnuPermanentDelete");
            this.mnuPermanentDelete.Click += new System.EventHandler(this.Action_PermanentDelete);
            // 
            // mnuRename
            // 
            this.mnuRename.Image = global::CloudNotes.DesktopClient.Properties.Resources.Rename2;
            this.mnuRename.Name = "mnuRename";
            resources.ApplyResources(this.mnuRename, "mnuRename");
            this.mnuRename.Click += new System.EventHandler(this.Action_Rename);
            // 
            // mnuRestore
            // 
            resources.ApplyResources(this.mnuRestore, "mnuRestore");
            this.mnuRestore.Name = "mnuRestore";
            this.mnuRestore.Click += new System.EventHandler(this.Action_Restore);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            resources.ApplyResources(this.toolStripMenuItem5, "toolStripMenuItem5");
            // 
            // mnuEmptyTrash
            // 
            this.mnuEmptyTrash.Image = global::CloudNotes.DesktopClient.Properties.Resources.bin_empty;
            this.mnuEmptyTrash.Name = "mnuEmptyTrash";
            resources.ApplyResources(this.mnuEmptyTrash, "mnuEmptyTrash");
            this.mnuEmptyTrash.Click += new System.EventHandler(this.Action_EmptyTrash);
            // 
            // mnuTools
            // 
            this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuChangePassword,
            this.toolStripMenuItem4,
            this.mnuSettings});
            this.mnuTools.Name = "mnuTools";
            resources.ApplyResources(this.mnuTools, "mnuTools");
            // 
            // mnuChangePassword
            // 
            resources.ApplyResources(this.mnuChangePassword, "mnuChangePassword");
            this.mnuChangePassword.Name = "mnuChangePassword";
            this.mnuChangePassword.Click += new System.EventHandler(this.Action_ChangePassword);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
            // 
            // mnuSettings
            // 
            this.mnuSettings.Image = global::CloudNotes.DesktopClient.Properties.Resources.Settings;
            this.mnuSettings.Name = "mnuSettings";
            resources.ApplyResources(this.mnuSettings, "mnuSettings");
            this.mnuSettings.Click += new System.EventHandler(this.Action_Settings);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSourceCodeRepository,
            this.mnuCloudNotesTech,
            this.toolStripMenuItem7,
            this.mnuAbout});
            this.mnuHelp.Name = "mnuHelp";
            resources.ApplyResources(this.mnuHelp, "mnuHelp");
            // 
            // mnuSourceCodeRepository
            // 
            this.mnuSourceCodeRepository.Image = global::CloudNotes.DesktopClient.Properties.Resources.page_white_csharp;
            this.mnuSourceCodeRepository.Name = "mnuSourceCodeRepository";
            resources.ApplyResources(this.mnuSourceCodeRepository, "mnuSourceCodeRepository");
            this.mnuSourceCodeRepository.Click += new System.EventHandler(this.Action_SourceCodeRepository);
            // 
            // mnuCloudNotesTech
            // 
            this.mnuCloudNotesTech.Image = global::CloudNotes.DesktopClient.Properties.Resources.world;
            this.mnuCloudNotesTech.Name = "mnuCloudNotesTech";
            resources.ApplyResources(this.mnuCloudNotesTech, "mnuCloudNotesTech");
            this.mnuCloudNotesTech.Click += new System.EventHandler(this.Action_CloudNotesTech);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            resources.ApplyResources(this.toolStripMenuItem7, "toolStripMenuItem7");
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            resources.ApplyResources(this.mnuAbout, "mnuAbout");
            this.mnuAbout.Click += new System.EventHandler(this.Action_About);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtnNew,
            this.tbtnOpen,
            this.tbtnSave,
            this.toolStripSeparator1,
            this.tbtnDelete,
            this.tbtnRename,
            this.tbtnRestore,
            this.toolStripSeparator2,
            this.tbtnSettings});
            resources.ApplyResources(this.toolStrip, "toolStrip");
            this.toolStrip.Name = "toolStrip";
            // 
            // tbtnNew
            // 
            this.tbtnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tbtnNew, "tbtnNew");
            this.tbtnNew.Name = "tbtnNew";
            this.tbtnNew.Click += new System.EventHandler(this.Action_New);
            // 
            // tbtnOpen
            // 
            this.tbtnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tbtnOpen, "tbtnOpen");
            this.tbtnOpen.Name = "tbtnOpen";
            this.tbtnOpen.Click += new System.EventHandler(this.Action_Open);
            // 
            // tbtnSave
            // 
            this.tbtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tbtnSave, "tbtnSave");
            this.tbtnSave.Name = "tbtnSave";
            this.tbtnSave.Click += new System.EventHandler(this.Action_Save);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // tbtnDelete
            // 
            this.tbtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tbtnDelete, "tbtnDelete");
            this.tbtnDelete.Name = "tbtnDelete";
            this.tbtnDelete.Click += new System.EventHandler(this.Action_Delete);
            // 
            // tbtnRename
            // 
            this.tbtnRename.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnRename.Image = global::CloudNotes.DesktopClient.Properties.Resources.Rename2;
            resources.ApplyResources(this.tbtnRename, "tbtnRename");
            this.tbtnRename.Name = "tbtnRename";
            this.tbtnRename.Click += new System.EventHandler(this.Action_Rename);
            // 
            // tbtnRestore
            // 
            this.tbtnRestore.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tbtnRestore, "tbtnRestore");
            this.tbtnRestore.Name = "tbtnRestore";
            this.tbtnRestore.Click += new System.EventHandler(this.Action_Restore);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // tbtnSettings
            // 
            this.tbtnSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnSettings.Image = global::CloudNotes.DesktopClient.Properties.Resources.Settings;
            resources.ApplyResources(this.tbtnSettings, "tbtnSettings");
            this.tbtnSettings.Name = "tbtnSettings";
            this.tbtnSettings.Click += new System.EventHandler(this.Action_Settings);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slblStatus,
            this.slblUpdateAvailable,
            this.sp});
            resources.ApplyResources(this.statusStrip, "statusStrip");
            this.statusStrip.Name = "statusStrip";
            // 
            // slblStatus
            // 
            resources.ApplyResources(this.slblStatus, "slblStatus");
            this.slblStatus.Name = "slblStatus";
            // 
            // slblUpdateAvailable
            // 
            this.slblUpdateAvailable.Image = global::CloudNotes.DesktopClient.Properties.Resources.exclam;
            this.slblUpdateAvailable.IsLink = true;
            this.slblUpdateAvailable.Name = "slblUpdateAvailable";
            resources.ApplyResources(this.slblUpdateAvailable, "slblUpdateAvailable");
            this.slblUpdateAvailable.Click += new System.EventHandler(this.slblUpdateAvailable_Click);
            // 
            // sp
            // 
            this.sp.Name = "sp";
            resources.ApplyResources(this.sp, "sp");
            this.sp.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // tabImageList
            // 
            this.tabImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("tabImageList.ImageStream")));
            this.tabImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.tabImageList.Images.SetKeyName(0, "world.png");
            this.tabImageList.Images.SetKeyName(1, "pencil.png");
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.trayIconContextMenu;
            resources.ApplyResources(this.notifyIcon, "notifyIcon");
            this.notifyIcon.DoubleClick += new System.EventHandler(this.Action_OpenMainWindow);
            // 
            // trayIconContextMenu
            // 
            this.trayIconContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuOpenMainWindow,
            this.toolStripSeparator3,
            this.cmnuExit});
            this.trayIconContextMenu.Name = "contextMenuStrip1";
            resources.ApplyResources(this.trayIconContextMenu, "trayIconContextMenu");
            // 
            // cmnuOpenMainWindow
            // 
            resources.ApplyResources(this.cmnuOpenMainWindow, "cmnuOpenMainWindow");
            this.cmnuOpenMainWindow.Name = "cmnuOpenMainWindow";
            this.cmnuOpenMainWindow.Click += new System.EventHandler(this.Action_OpenMainWindow);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // cmnuExit
            // 
            resources.ApplyResources(this.cmnuExit, "cmnuExit");
            this.cmnuExit.Name = "cmnuExit";
            this.cmnuExit.Click += new System.EventHandler(this.Action_Exit);
            // 
            // ctxMnuNotesNode
            // 
            this.ctxMnuNotesNode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuNew});
            this.ctxMnuNotesNode.Name = "ctxMnuNotesNode";
            resources.ApplyResources(this.ctxMnuNotesNode, "ctxMnuNotesNode");
            this.ctxMnuNotesNode.Click += new System.EventHandler(this.Action_New);
            // 
            // cmnuNew
            // 
            this.cmnuNew.Image = global::CloudNotes.DesktopClient.Properties.Resources.New;
            this.cmnuNew.Name = "cmnuNew";
            resources.ApplyResources(this.cmnuNew, "cmnuNew");
            // 
            // ctxMnuTrashNode
            // 
            this.ctxMnuTrashNode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuEmptyTrash});
            this.ctxMnuTrashNode.Name = "ctxMnuTrashNode";
            resources.ApplyResources(this.ctxMnuTrashNode, "ctxMnuTrashNode");
            // 
            // cmnuEmptyTrash
            // 
            this.cmnuEmptyTrash.Image = global::CloudNotes.DesktopClient.Properties.Resources.bin_empty;
            this.cmnuEmptyTrash.Name = "cmnuEmptyTrash";
            resources.ApplyResources(this.cmnuEmptyTrash, "cmnuEmptyTrash");
            this.cmnuEmptyTrash.Click += new System.EventHandler(this.Action_EmptyTrash);
            // 
            // ctxMnuNoteNode
            // 
            this.ctxMnuNoteNode.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmnuDelete,
            this.cmnuPermanentDelete,
            this.cmnuRename,
            this.cmnuRestore});
            this.ctxMnuNoteNode.Name = "ctxMnuNoteNode";
            resources.ApplyResources(this.ctxMnuNoteNode, "ctxMnuNoteNode");
            // 
            // cmnuDelete
            // 
            this.cmnuDelete.Image = global::CloudNotes.DesktopClient.Properties.Resources.Delete;
            this.cmnuDelete.Name = "cmnuDelete";
            resources.ApplyResources(this.cmnuDelete, "cmnuDelete");
            this.cmnuDelete.Click += new System.EventHandler(this.Action_Delete);
            // 
            // cmnuPermanentDelete
            // 
            this.cmnuPermanentDelete.Name = "cmnuPermanentDelete";
            resources.ApplyResources(this.cmnuPermanentDelete, "cmnuPermanentDelete");
            this.cmnuPermanentDelete.Click += new System.EventHandler(this.Action_PermanentDelete);
            // 
            // cmnuRename
            // 
            this.cmnuRename.Image = global::CloudNotes.DesktopClient.Properties.Resources.Rename2;
            this.cmnuRename.Name = "cmnuRename";
            resources.ApplyResources(this.cmnuRename, "cmnuRename");
            this.cmnuRename.Click += new System.EventHandler(this.Action_Rename);
            // 
            // cmnuRestore
            // 
            this.cmnuRestore.Image = global::CloudNotes.DesktopClient.Properties.Resources.Restore;
            this.cmnuRestore.Name = "cmnuRestore";
            resources.ApplyResources(this.cmnuRestore, "cmnuRestore");
            this.cmnuRestore.Click += new System.EventHandler(this.Action_Restore);
            // 
            // FrmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FrmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Resize += new System.EventHandler(this.FrmMain_Resize);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.trayIconContextMenu.ResumeLayout(false);
            this.ctxMnuNotesNode.ResumeLayout(false);
            this.ctxMnuTrashNode.ResumeLayout(false);
            this.ctxMnuNoteNode.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripButton tbtnNew;
        private System.Windows.Forms.ToolStripButton tbtnOpen;
        private System.Windows.Forms.ToolStripButton tbtnSave;
        private System.Windows.Forms.ToolStripMenuItem mnuNew;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripMenuItem mnuTools;
        private System.Windows.Forms.ImageList tvImageList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripButton tbtnDelete;
        private System.Windows.Forms.ToolStripStatusLabel slblStatus;
        private System.Windows.Forms.ToolStripProgressBar sp;
        private System.Windows.Forms.ToolStripMenuItem mnuSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tbtnSettings;
        private System.Windows.Forms.ContextMenuStrip trayIconContextMenu;
        private System.Windows.Forms.ToolStripMenuItem cmnuExit;
        private System.Windows.Forms.ToolStripButton tbtnRename;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuReconnect;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem cmnuOpenMainWindow;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem mnuChangePassword;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ImageList tabImageList;
        private System.Windows.Forms.SplitContainer splitContainer;
        private YARTE.UI.HtmlEditor htmlEditor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDatePublished;
        private System.Windows.Forms.ToolStripMenuItem mnuNote;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuRename;
        private System.Windows.Forms.ToolStripButton tbtnRestore;
        private System.Windows.Forms.ToolStripMenuItem mnuRestore;
        private System.Windows.Forms.ToolStripMenuItem mnuPermanentDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem mnuEmptyTrash;
        private System.Windows.Forms.ContextMenuStrip ctxMnuNotesNode;
        private System.Windows.Forms.ToolStripMenuItem cmnuNew;
        private System.Windows.Forms.ContextMenuStrip ctxMnuTrashNode;
        private System.Windows.Forms.ToolStripMenuItem cmnuEmptyTrash;
        private System.Windows.Forms.ContextMenuStrip ctxMnuNoteNode;
        private System.Windows.Forms.ToolStripMenuItem cmnuDelete;
        private System.Windows.Forms.ToolStripMenuItem cmnuPermanentDelete;
        private System.Windows.Forms.ToolStripMenuItem cmnuRename;
        private System.Windows.Forms.ToolStripMenuItem cmnuRestore;
        private System.Windows.Forms.ToolStripMenuItem mnuPrint;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem mnuCloudNotesTech;
        private System.Windows.Forms.ToolStripStatusLabel slblUpdateAvailable;
        private System.Windows.Forms.ToolStripMenuItem mnuSourceCodeRepository;
        private Controls.TreeViewEx tvNotes;
    }
}

