// =======================================================================================================
//
//    ,uEZGZX  LG                             Eu       iJ       vi                                              
//   BB7.  .:  uM                             8F       0BN      Bq             S:                               
//  @X         LO    rJLYi    :     i    iYLL XJ       Xu7@     Mu    7LjL;   rBOii   7LJ7    .vYUi             
// ,@          LG  7Br...SB  vB     B   B1...7BL       0S i@,   OU  :@7. ,u@   @u.. :@:  ;B  LB. ::             
// v@          LO  B      Z0 i@     @  BU     @Y       qq  .@L  Oj  @      5@  Oi   @.    MB U@                 
// .@          JZ :@      :@ rB     B  @      5U       Eq    @0 Xj ,B      .B  Br  ,B:rv777i  :0ZU              
//  @M         LO  @      Mk :@    .@  BL     @J       EZ     GZML  @      XM  B;   @            Y@             
//   ZBFi::vu  1B  ;B7..:qO   BS..iGB   BJ..:vB2       BM      rBj  :@7,.:5B   qM.. i@r..i5. ir. UB             
//     iuU1vi   ,    ;LLv,     iYvi ,    ;LLr  .       .,       .     rvY7:     rLi   7LLr,  ,uvv:  
//
//
// Copyright 2014-2015 daxnet
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// =======================================================================================================

namespace CloudNotes.DesktopClient
{
    using Controls;
    using DESecurity;
    using Extensibility;
    using Extensibility.Data;
    using Infrastructure;
    using Properties;
    using Settings;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using YARTE.Buttons;
    using YARTE.UI.Buttons;

    /// <summary>
    /// Represents the main form for CloudNotes desktop client.
    /// </summary>
    public sealed partial class FrmMain : Form, IShell
    {
        private readonly ClientCredential credential;

        private readonly Crypto crypto = Crypto.CreateDefaultCrypto();

        private Note currentNote;

        private Workspace workspace;

        private volatile bool closingSignal; // Indicates the closing signal that is sent to the form's closing event.

        private readonly TreeNode notesNode;

        private readonly TreeNode trashNode;

        private readonly DesktopClientSettings settings;

        private readonly ExtensionManager extensionManager;

        private CheckUpdateResult checkUpdateResult;

        internal FrmMain(ClientCredential credential, DesktopClientSettings settings, ExtensionManager extensionManager)
        {
            this.credential = credential;

            this.settings = settings;

            this.extensionManager = extensionManager;

            this.InitializeComponent();

            this.InitializeHtmlEditor();

            this.InitializeExtensions();

            this.Text = string.Format("CloudNotes - {0}@{1}", credential.UserName, credential.ServerUri);

            this.notifyIcon.Text = string.Format("CloudNotes - {0}", credential.UserName);

            this.notesNode = this.tvNotes.Nodes.Add("NotesRoot", Resources.NotesNodeTitle, 0, 0);
            this.trashNode = this.tvNotes.Nodes.Add("TrashRoot", Resources.TrashNodeTitle, 1, 1);

            Application.Idle += (s, e) =>
            {
                this.slblStatus.Text = Resources.Ready;
            };
        }


        #region Private Methods

        private void InitializeHtmlEditor()
        {
            PredefinedButtonSets.SetupDefaultButtons(this.htmlEditor);
            this.htmlEditor.DocumentTextChanged += (s, e) =>
            {
                if (this.workspace != null)
                {
                    this.workspace.Content = this.htmlEditor.Html;
                }
            };
            this.htmlEditor.DocumentPreviewKeyDown += async (kds, kde) =>
            {
                if (kde.KeyData == (Keys.Control | Keys.S))
                {
                    await this.DoSaveAsync();
                }
            };
        }

        private void InitializeExtensions()
        {
            // Initialize tool extensions
            var toolExtensions = this.extensionManager.ToolExtensions.ToList();
            if (toolExtensions.Count > 0)
            {
                mnuTools.DropDownItems.Add("-");
                foreach(var toolExtension in toolExtensions)
                {
                    var extensionToolStrip = mnuTools.DropDownItems.Add(toolExtension.ToolName);
                    extensionToolStrip.Image = toolExtension.ToolIcon;
                    extensionToolStrip.ToolTipText = toolExtension.ToolTip;
                    extensionToolStrip.Tag = toolExtension.ID;
                    extensionToolStrip.Click += (s, e) =>
                    {
                        SafeExecutionContext.Execute(this, () => toolExtension.Execute(this));
                    };
                }
            }
        }

        /// <summary>
        /// Creates the Data Access Proxy for use by the Desktop Client.
        /// </summary>
        /// <returns>The <see cref="DataAccessProxy"/> instance.</returns>
        private DataAccessProxy CreateDataAccessProxy()
        {
            return new WebApiDataAccessProxy(this.credential);
        }

        /// <summary>
        /// Corrects the current node selection in the notes tree view, before the current node is going
        /// to be removed.
        /// </summary>
        /// <param name="currentNode">The current node that is going to be removed.</param>
        private async Task CorrectNodeSelectionAsync(TreeNode currentNode)
        {
            var previousNode = currentNode.PrevNode;
            if (previousNode == null)
            {
                previousNode = currentNode.Parent;
            }
            if (previousNode == this.notesNode || previousNode == this.trashNode)
            {
                this.lblTitle.Text = string.Empty;
                this.lblDatePublished.Text = string.Empty;
                this.htmlEditor.Enabled = false;
                this.htmlEditor.Html = string.Empty;
                this.mnuPrint.Enabled = false;
            }
            else
            {
                var note = GetItem(previousNode).Data;
                await this.LoadNoteAsync(note.ID);
            }
            this.tvNotes.SelectedNode = previousNode;
        }

        private void ResortNodes(TreeNode parent)
        {
            var tempNodes = new TreeNode[parent.Nodes.Count];
            parent.Nodes.CopyTo(tempNodes, 0);
            var sortedList = new List<TreeNode>(tempNodes);
            sortedList.Sort(
                (x, y) =>
                {
                    var xTag = GetItem(x).Data;
                    var yTag = GetItem(y).Data;
                    return yTag.DatePublished.CompareTo(xTag.DatePublished);
                });
            parent.Nodes.Clear();
            parent.Nodes.AddRange(sortedList.ToArray());
        }

        private void UpdateSettings()
        {

        }

        private TreeNode FindNoteNode(Guid noteId)
        {
            foreach (TreeNode node in this.notesNode.Nodes)
            {
                if (GetItem(node).Data.ID == noteId)
                {
                    return node;
                }
            }
            foreach (TreeNode node in this.trashNode.Nodes)
            {
                if (GetItem(node).Data.ID == noteId)
                {
                    return node;
                }
            }
            return null;
        }

        private static TreeViewEx.TreeNodeExItem GetItem(TreeNode treeNode)
        {
            if (treeNode != null && treeNode.Tag != null)
            {
                var item = treeNode.Tag as TreeViewEx.TreeNodeExItem;
                if (item != null) return item;
            }
            throw new InvalidOperationException();
        }

        private static string ReplaceFileSystemImages(string html)
        {
            var matches = Regex.Matches(
                html,
                @"<img[^>]*?src\s*=\s*([""']?[^'"">]+?['""])[^>]*?>",
                RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline);
            foreach (Match match in matches)
            {
                string src = match.Groups[1].Value;
                src = src.Trim('\"');
                if (File.Exists(src))
                {
                    var ext = Path.GetExtension(src);
                    if (ext.Length > 0)
                    {
                        ext = ext.Substring(1);
                        src = string.Format(
                            "'data:image/{0};base64,{1}'",
                            ext,
                            Convert.ToBase64String(File.ReadAllBytes(src)));
                        html = html.Replace(match.Groups[1].Value, src);
                    }
                }
            }
            return html;
        }

        /// <summary>
        /// Determines whether the note data contained within the specified tree node has already
        /// been marked as deleted.
        /// </summary>
        /// <param name="node">The tree node that contains the note data.</param>
        /// <returns>True if the note was marked as deleted. Otherwise false.</returns>
        private static bool IsMarkedAsDeletedNoteNode(TreeNode node)
        {
            if (node.Tag == null) return false;
            var note = GetItem(node).Data;
            if (note == null || note.DeletedFlag == null) return false;
            return (int)note.DeletedFlag == (int)DeleteFlag.MarkDeleted;
        }

        private async Task LoadNotesAsync()
        {
            this.lblTitle.Text = string.Empty;
            this.lblDatePublished.Text = string.Empty;
            this.htmlEditor.Html = string.Empty;
            this.htmlEditor.Enabled = false;

            this.mnuOpen.Enabled = false;
            this.tbtnOpen.Enabled = false;
            this.mnuDelete.Enabled = false;
            this.tbtnDelete.Enabled = false;
            this.mnuPermanentDelete.Enabled = false;
            this.mnuRestore.Enabled = false;
            this.tbtnRestore.Enabled = false;
            this.mnuRename.Enabled = false;
            this.tbtnRename.Enabled = false;
            this.tbtnSave.Enabled = false;
            this.mnuSave.Enabled = false;
            this.mnuEmptyTrash.Enabled = false;
            this.cmnuEmptyTrash.Enabled = false;
            this.mnuPrint.Enabled = false;

            this.notesNode.Nodes.Clear();
            this.trashNode.Nodes.Clear();

            using (var dataAccessProxy = this.CreateDataAccessProxy())
            {
                // Retrieves all the notes that are not marked as deleted or deleted, then
                // list all those notes under My Notes folder.
                var notes =
                    await
                        dataAccessProxy.GetNotesAsync();
                foreach (var note in notes)
                {
                    Image image = null;
                    if (!string.IsNullOrEmpty(note.ThumbnailImageBase64))
                    {
                        image = Image.FromStream(new MemoryStream(Convert.FromBase64String(note.ThumbnailImageBase64)));
                    }
                    this.tvNotes.AddItem(this.notesNode.Nodes, note.Title, note.Description, note, image);
                }

                // Retrieves all the marked as deleted notes
                var markedAsDeletedNotes = await dataAccessProxy.GetNotesAsync(true);
                foreach (var note in markedAsDeletedNotes)
                {
                    Image image = null;
                    if (!string.IsNullOrEmpty(note.ThumbnailImageBase64))
                    {
                        image = Image.FromStream(new MemoryStream(Convert.FromBase64String(note.ThumbnailImageBase64)));
                    }
                    this.tvNotes.AddItem(this.trashNode.Nodes, note.Title, note.Description, note, image);
                }
            }

            if (this.notesNode.Nodes.Count > 0)
            {
                var note = GetItem(this.notesNode.Nodes[0]).Data;
                var id = note.ID;
                await this.LoadNoteAsync(id);

                this.tvNotes.SelectedNode = this.notesNode.Nodes[0];
            }
            else
            {
                this.ClearWorkspace();
            }

        }

        private void ClearWorkspace()
        {
            if (this.workspace != null)
            {
                this.workspace.PropertyChanged -= this.workspace_PropertyChanged;
                this.workspace = null;
            }
        }

        private async Task LoadNoteAsync(Guid id)
        {
            using (var dataAccessProxy = this.CreateDataAccessProxy())
            {
                this.currentNote = await dataAccessProxy.GetNoteAsync(id);
            }
            this.ClearWorkspace();
            this.workspace = new Workspace(this.currentNote);
            this.workspace.PropertyChanged += this.workspace_PropertyChanged;
            this.lblTitle.Text = this.workspace.Title;
            var datePublished = this.workspace.DatePublished;
            this.lblDatePublished.Text = datePublished.ToLocalTime()
                .ToString("G", new CultureInfo(this.settings.General.Language));
            this.htmlEditor.Html = this.workspace.Content;
            this.htmlEditor.Enabled = true;
            this.tbtnSave.Enabled = false;
            this.mnuSave.Enabled = false;
            this.mnuPrint.Enabled = true;
        }

        private async Task SaveWorkspaceSlientlyAsync()
        {
            var currentNoteId = this.workspace.ID;
            var currentNoteTitle = this.workspace.Title;
            var currentNoteDescription = string.Empty;
            Image currentNoteThumbnailImage = null;

            string currentNoteContent = this.crypto.Encrypt("<p />");
            if (!string.IsNullOrEmpty(this.workspace.Content))
            {
                var content = ReplaceFileSystemImages(this.workspace.Content);
                currentNoteDescription = content.ExtractDescription();
                var currentNoteThumbnailImageBase64 = content.ExtractThumbnailImageBase64();
                if (!string.IsNullOrEmpty(currentNoteThumbnailImageBase64))
                {
                    currentNoteThumbnailImage =
                        Image.FromStream(new MemoryStream(Convert.FromBase64String(currentNoteThumbnailImageBase64)));
                }
                currentNoteContent = this.crypto.Encrypt(content);
            }

            using (var dataAccessProxy = this.CreateDataAccessProxy())
            {
                if (currentNoteId == Guid.Empty)
                {
                    this.workspace.ID = await dataAccessProxy.CreateNoteAsync(new Note
                    {
                        Title = currentNoteTitle,
                        Content = currentNoteContent
                    });
                }
                else
                {
                    await dataAccessProxy.UpdateNoteAsync(new Note
                    {
                        ID = currentNoteId,
                        Title = currentNoteTitle,
                        Content = currentNoteContent
                    });
                }
            }

            this.workspace.IsSaved = true;
            var node = this.FindNoteNode(currentNoteId);
            if (node != null)
            {
                var item = GetItem(node);
                item.Title = this.workspace.Title;
                item.Description = currentNoteDescription;
                item.Image = currentNoteThumbnailImage;
                this.tvNotes.Refresh();
            }
        }

        private async Task<bool> SaveWorkspaceAsync()
        {
            var canceled = false;
            if (this.workspace != null)
            {
                if (!this.workspace.IsSaved)
                {
                    var saveConfirm = MessageBox.Show(
                        Resources.SaveConfirm,
                        Resources.Confirmation,
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Question);
                    switch (saveConfirm)
                    {
                        case DialogResult.Yes:
                            await this.SaveWorkspaceSlientlyAsync();
                            break;
                        case DialogResult.No:
                            break;
                        case DialogResult.Cancel:
                            canceled = true;
                            break;
                    }
                }
            }
            return canceled;
        }

        private async Task OpenTreeNodeAsync(TreeNode treeNode)
        {
            var canceled = await this.SaveWorkspaceAsync();
            if (!canceled)
            {
                var noteItem = GetItem(treeNode).Data;
                await this.LoadNoteAsync(noteItem.ID);
            }
            else
            {
                if (this.workspace != null)
                {
                    Parallel.ForEach(
                        this.notesNode.Nodes.Cast<TreeNode>(),
                        p =>
                        {
                            var note = GetItem(p).Data;
                            if (this.workspace.ID == note.ID) this.tvNotes.SelectedNode = p;
                        });
                }
            }
        }

        #endregion

        #region Async Handlers

        private async Task DoNewAsync()
        {
            await SafeExecutionContext.ExecuteAsync(
                this,
                async () =>
                {
                    var newNoteForm = new FrmNewNote(
                            this.notesNode.Nodes.Cast<TreeNode>().Select(tn => tn.Text));
                    if (newNoteForm.ShowDialog() == DialogResult.OK)
                    {
                        var title = newNoteForm.NoteTitle;
                        var note =
                            new Note
                            {
                                ID = Guid.Empty,
                                Title = title,
                                Content = string.Empty,
                                DatePublished = DateTime.UtcNow
                            };
                        await this.AddNoteAsync(note);
                    }
                });
        }

        private async Task DoOpenAsync()
        {
            await
                SafeExecutionContext.ExecuteAsync(
                    this,
                    async () => await this.OpenTreeNodeAsync(this.tvNotes.SelectedNode),
                    () =>
                    {
                        this.slblStatus.Text = Resources.Opening;
                        this.sp.Visible = true;
                    },
                    () => this.sp.Visible = false);
        }

        private async Task DoSaveAsync()
        {
            if (!this.workspace.IsSaved)
            {
                await SafeExecutionContext.ExecuteAsync(
                    this,
                    async () => await this.SaveWorkspaceSlientlyAsync(),
                    () =>
                    {
                        this.slblStatus.Text = Resources.Saving;
                        this.sp.Visible = true;
                    },
                    () => this.sp.Visible = false);
            }
        }

        private async Task DoMarkDeleteAsync()
        {
            await SafeExecutionContext.ExecuteAsync(
                this,
                async () =>
                {
                    var treeNode = this.tvNotes.SelectedNode;
                    if (treeNode != null)
                    {
                        var item = GetItem(treeNode);
                        var note = item.Data;
                        using (var dataAccessProxy = this.CreateDataAccessProxy())
                        {
                            await dataAccessProxy.MarkDeleteAsync(note.ID);
                        }
                        treeNode.Remove();

                        this.tvNotes.AddItem(this.trashNode.Nodes, item);

                        note.DeletedFlag = (int)DeleteFlag.MarkDeleted;

                        this.ResortNodes(this.trashNode);
                        if (this.trashNode.Nodes.Count > 0)
                        {
                            this.mnuEmptyTrash.Enabled = true;
                            this.cmnuEmptyTrash.Enabled = true;
                        }
                        this.mnuEmptyTrash.Enabled = true;
                        this.cmnuEmptyTrash.Enabled = true;
                    }
                },
                () =>
                {
                    this.slblStatus.Text = Resources.Deleting;
                    this.sp.Visible = true;
                },
                () => this.sp.Visible = false);
        }

        private async Task DoDeleteAsync()
        {
            await SafeExecutionContext.ExecuteAsync(
                this,
                async () =>
                {
                    var confirmResult = MessageBox.Show(
                        Resources.DeleteNoteConfirm,
                        Resources.Confirmation,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2);
                    if (confirmResult == DialogResult.Yes)
                    {
                        this.slblStatus.Text = Resources.Deleting;
                        this.sp.Visible = true;
                        var treeNode = this.tvNotes.SelectedNode;
                        if (treeNode != null)
                        {
                            var note = GetItem(treeNode).Data;
                            using (var dataAccessProxy = this.CreateDataAccessProxy())
                            {
                                await dataAccessProxy.DeleteAsync(note.ID);
                            }
                            await this.LoadNotesAsync();
                        }
                        if (this.trashNode.Nodes.Count == 0)
                        {
                            this.mnuEmptyTrash.Enabled = false;
                            this.cmnuEmptyTrash.Enabled = false;
                        }
                    }
                },
                null,
                () => this.sp.Visible = false);
        }

        private async Task DoRestoreAsync()
        {
            await SafeExecutionContext.ExecuteAsync(
                this,
                async () =>
                {
                    var treeNode = this.tvNotes.SelectedNode;
                    if (treeNode != null)
                    {
                        var item = GetItem(treeNode);
                        var note = item.Data;
                        using (var dataAccessProxy = this.CreateDataAccessProxy())
                        {
                            await dataAccessProxy.RestoreAsync(note.ID);
                        }
                        await this.CorrectNodeSelectionAsync(treeNode);
                        treeNode.Remove();
                        this.tvNotes.AddItem(this.notesNode.Nodes, item);
                        note.DeletedFlag = DeleteFlag.None;

                        this.ResortNodes(this.notesNode);
                        if (this.trashNode.Nodes.Count == 0)
                        {
                            this.mnuEmptyTrash.Enabled = false;
                            this.cmnuEmptyTrash.Enabled = false;
                        }
                    }
                },
                () =>
                {
                    this.slblStatus.Text = Resources.Restoring;
                    this.sp.Visible = true;
                },
                () => this.sp.Visible = false);
        }

        private async Task DoEmptyTrashAsync()
        {
            await SafeExecutionContext.ExecuteAsync(
                this,
                async () =>
                {
                    var confirmResult = MessageBox.Show(
                        Resources.DeleteNoteConfirm,
                        Resources.Confirmation,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2);
                    if (confirmResult == DialogResult.Yes)
                    {
                        this.slblStatus.Text = Resources.Deleting;
                        this.sp.Visible = true;
                        using (var dataAccessProxy = this.CreateDataAccessProxy())
                        {
                            await dataAccessProxy.EmptyTrashAsync();
                        }

                        this.trashNode.Nodes.Clear();
                        if (this.notesNode.Nodes.Count > 0)
                        {
                            var firstNode = this.notesNode.Nodes[0];
                            var firstNote = GetItem(firstNode).Data;
                            await this.LoadNoteAsync(firstNote.ID);
                        }
                        else
                        {
                            this.tvNotes.SelectedNode = this.notesNode;
                            this.lblTitle.Text = string.Empty;
                            this.lblDatePublished.Text = string.Empty;
                            this.htmlEditor.Enabled = false;
                            this.htmlEditor.Html = string.Empty;
                        }
                    }
                },
                null,
                () => this.sp.Visible = false);
        }

        private void DoRename()
        {
            SafeExecutionContext.Execute(
                this,
                () =>
                {
                    var node = this.tvNotes.SelectedNode;
                    node.BeginEdit();
                });
        }

        private async Task DoReconnectAsync()
        {
            await SafeExecutionContext.ExecuteAsync(
                this,
                async () =>
                {
                    bool canceled = false;
                    var localCredential = LoginProvider.Login(delegate { canceled = true; }, this.settings, true);
                    if (!canceled && localCredential != null)
                    {
                        this.credential.UserName = localCredential.UserName;
                        this.credential.Password = localCredential.Password;
                        this.credential.ServerUri = localCredential.ServerUri;
                        this.Text = string.Format(
                            "CloudNotes - {0}@{1}",
                            this.credential.UserName,
                            this.credential.ServerUri);
                        await this.LoadNotesAsync();
                    }
                });
        }

        #endregion

        private void workspace_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var obj = sender as Workspace;
            if (obj != null)
            {
                switch (e.PropertyName)
                {
                    case "Content":
                        this.mnuSave.Enabled = true;
                        this.tbtnSave.Enabled = true;
                        break;
                    case "IsSaved":
                        this.mnuSave.Enabled = !obj.IsSaved;
                        this.tbtnSave.Enabled = !obj.IsSaved;
                        break;
                }
            }
        }

        private async void Action_New(object sender, EventArgs e)
        {
            await this.DoNewAsync();
        }

        private async void Action_Open(object sender, EventArgs e)
        {
            await this.DoOpenAsync();
        }

        private async void Action_Save(object sender, EventArgs e)
        {
            await this.DoSaveAsync();
        }

        private void Action_Print(object sender, EventArgs e)
        {
            SafeExecutionContext.Execute(this, () => this.htmlEditor.ExecuteButtonFunction<PrintButton>());
        }

        private async void Action_Delete(object sender, EventArgs e)
        {
            var treeNode = this.tvNotes.SelectedNode;
            if (treeNode != null)
            {
                if (IsMarkedAsDeletedNoteNode(treeNode)) await this.DoDeleteAsync();
                else await this.DoMarkDeleteAsync();
            }
        }

        private async void Action_PermanentDelete(object sender, EventArgs e)
        {
            var treeNode = this.tvNotes.SelectedNode;
            if (treeNode != null)
            {
                await this.DoDeleteAsync();
            }
        }

        private async void Action_Restore(object sender, EventArgs e)
        {
            await this.DoRestoreAsync();
        }

        private async void Action_EmptyTrash(object sender, EventArgs e)
        {
            await this.DoEmptyTrashAsync();
        }

        private void Action_Rename(object sender, EventArgs e)
        {
            this.DoRename();
        }

        private async void Action_Reconnect(object sender, EventArgs e)
        {
            await this.DoReconnectAsync();
        }

        private void Action_ChangePassword(object sender, EventArgs e)
        {
            SafeExecutionContext.Execute(this, () =>
            {
                var changePasswordForm = new FrmChangePassword(this.credential);
                changePasswordForm.ShowDialog();
            });
        }

        private void Action_Settings(object sender, EventArgs e)
        {
            SafeExecutionContext.Execute(
                this,
                () =>
                {
                    var settingsForm = new FrmSettings(this.settings);
                    if (settingsForm.ShowDialog() == DialogResult.OK)
                    {
                        this.UpdateSettings();
                    }
                });
        }

        private void Action_OpenMainWindow(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void Action_Exit(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Action_About(object sender, EventArgs e)
        {
            SafeExecutionContext.Execute(this, () => new FrmAbout().ShowDialog());
        }

        private void Action_CloudNotesTech(object sender, EventArgs e)
        {
            "http://daxnetsvr.cloudapp.net/schen/cloudnotes".Navigate();
        }

        private void Action_SourceCodeRepository(object sender, EventArgs e)
        {
            "https://github.com/daxnet/CloudNotes".Navigate();
        }

        private async void FrmMain_Load(object sender, EventArgs e)
        {
            await SafeExecutionContext.ExecuteAsync(
                this,
                async () =>
                {
                    this.lblTitle.Text = string.Empty;
                    this.lblDatePublished.Text = string.Empty;
                    this.htmlEditor.Html = string.Empty;
                    this.htmlEditor.Enabled = false;
                    var desktopClientService = new DesktopClientService(this.settings);
                    this.checkUpdateResult = await desktopClientService.CheckUpdateAsync();
                    this.slblUpdateAvailable.Visible = this.checkUpdateResult.HasUpdate;
                    await this.LoadNotesAsync();
                },
                () =>
                {
                    this.slblStatus.Text = Resources.Loading;
                    this.sp.Visible = true;
                },
                () => this.sp.Visible = false);
        }

        private async void tvNotes_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Node != null && !ReferenceEquals(e.Node, this.notesNode)
                && !ReferenceEquals(e.Node, this.trashNode))
            {
                await SafeExecutionContext.ExecuteAsync(
                    this,
                    async () => await this.OpenTreeNodeAsync(e.Node),
                    () =>
                    {
                        this.slblStatus.Text = Resources.Opening;
                        this.sp.Visible = true;
                    },
                    () => this.sp.Visible = false);
            }
        }

        private async void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // If the closing event has not received the closing signal
            if (!this.closingSignal)
            {
                // Suppress the form from closing
                e.Cancel = true;

                // awaiting for the workspace saving task
                var canceled = await this.SaveWorkspaceAsync();

                // If the user didn't cancel the closing operation
                if (!canceled)
                {
                    // Signal the form's closing event
                    this.closingSignal = true;
                    // Closes the form
                    this.Close();
                }
            }
            else e.Cancel = false;
        }

        private void tvNotes_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    if (e.Node == this.notesNode)
                    {
                        this.ctxMnuNotesNode.Show(this.tvNotes, e.X, e.Y);
                    }
                    else if (e.Node == this.trashNode)
                    {
                        this.ctxMnuTrashNode.Show(this.tvNotes, e.X, e.Y);
                    }
                    else
                    {
                        this.cmnuRestore.Visible = IsMarkedAsDeletedNoteNode(e.Node);
                        this.ctxMnuNoteNode.Show(this.tvNotes, e.X, e.Y);
                    }
                    break;
            }
            this.tvNotes.SelectedNode = e.Node;
        }

        private void tvNotes_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null && !ReferenceEquals(e.Node, this.notesNode) && !ReferenceEquals(e.Node, this.trashNode))
            {
                this.mnuOpen.Enabled = true;
                this.tbtnOpen.Enabled = true;
                this.mnuDelete.Enabled = true;
                this.tbtnDelete.Enabled = true;
                this.mnuPermanentDelete.Enabled = true;
                this.mnuRename.Enabled = true;
                this.tbtnRename.Enabled = true;
                this.mnuRestore.Enabled = IsMarkedAsDeletedNoteNode(e.Node);
                this.tbtnRestore.Enabled = IsMarkedAsDeletedNoteNode(e.Node);
            }
            else
            {
                this.mnuOpen.Enabled = false;
                this.tbtnOpen.Enabled = false;
                this.mnuDelete.Enabled = false;
                this.tbtnDelete.Enabled = false;
                this.mnuPermanentDelete.Enabled = false;
                this.mnuRestore.Enabled = false;
                this.tbtnRestore.Enabled = false;
                this.mnuRename.Enabled = false;
                this.tbtnRename.Enabled = false;
            }
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            this.ShowInTaskbar = this.WindowState != FormWindowState.Minimized;
        }

        private async void tvNotes_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (!e.CancelEdit)
            {
                await SafeExecutionContext.ExecuteAsync(
                    this,
                    async () =>
                    {
                        var title = e.Label;
                        if (string.IsNullOrEmpty(title)) return;
                        this.slblStatus.Text = Resources.Renaming;
                        this.sp.Visible = true;
                        if (this.notesNode.Nodes.Cast<TreeNode>().Any(n => n != e.Node && n.Text == title))
                        {
                            MessageBox.Show(
                                Resources.TitleExists,
                                Resources.Error,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            e.CancelEdit = true;
                        }
                        else
                        {
                            var item = GetItem(e.Node);
                            var nodeMetadata = item.Data;
                            using (var dataAccessProxy = this.CreateDataAccessProxy())
                            {
                                var selectedNote = await dataAccessProxy.GetNoteAsync(nodeMetadata.ID);
                                var noteUpdate = new Note
                                {
                                    ID = nodeMetadata.ID,
                                    Title = title,
                                    Content = selectedNote.Content
                                };
                                await dataAccessProxy.UpdateNoteAsync(noteUpdate);
                                this.lblTitle.Text = title;
                                this.workspace.Title = title;
                                item.Title = title;
                                this.tvNotes.Refresh();
                            }
                        }
                    },
                    null,
                    () => this.sp.Visible = false);
            }
        }

        private void tvNotes_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (ReferenceEquals(e.Node, this.notesNode) || ReferenceEquals(e.Node, this.trashNode))
            {
                e.CancelEdit = true;
            }
        }

        private async void slblUpdateAvailable_Click(object sender, EventArgs e)
        {
            if (this.checkUpdateResult != null)
            {
                var canceled = await this.SaveWorkspaceAsync();
                if (!canceled)
                {
                    var updatePackageForm = new FrmUpdatePackage(this.checkUpdateResult.UpdatePackage);
                    updatePackageForm.ShowDialog();
                }
            }
        }

        public async Task AddNoteAsync(Note note)
        {
            var canceled = await this.SaveWorkspaceAsync();
            if (!canceled)
            {
                this.ClearWorkspace();
                note.Content = string.IsNullOrEmpty(note.Content) ? string.Empty : crypto.Encrypt(note.Content);
                this.workspace = new Workspace(note);
                this.workspace.PropertyChanged += this.workspace_PropertyChanged;
                await this.SaveWorkspaceSlientlyAsync();
                await this.LoadNotesAsync();
            }
        }
    }
}
