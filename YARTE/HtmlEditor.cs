using mshtml;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using YARTE.UI.Buttons;

namespace YARTE.UI
{
    public partial class HtmlEditor : UserControl
    {
        private readonly HtmlDocument _doc;

        private readonly IList<IHTMLEditorButton> _customButtons;

        private static string[] styles =
            {
                "Normal", "Heading 1", "Heading 2", "Heading 3", "Heading 4", "Heading 5",
                "Heading 6", "Heading 7"
            };

        private bool updatingStyle;

        private bool updatingFontSize;

        private string originalText = string.Empty;

        public HtmlEditor()
        {
            InitializeComponent();

            InitializeWebBrowserAsEditor();

            _doc = textWebBrowser.Document;
            _customButtons = new List<IHTMLEditorButton>();

            updateToolBarTimer.Start();
            updateToolBarTimer.Tick += updateToolBarTimer_Tick;
        }

        public event EventHandler DocumentTextChanged;

        public event EventHandler<PreviewKeyDownEventArgs> DocumentPreviewKeyDown;

        private void OnDocumentTextChanged()
        {
            var handler = this.DocumentTextChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        private void OnDocumentPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            var handler = this.DocumentPreviewKeyDown;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void AddFontSizeSelector(IEnumerable<int> fontSizes)
        {
            if (fontSizes.Min() < 1 || fontSizes.Max() > 7)
            {
                throw new ArgumentException("Allowable font sizes are 1 through 7");
            }

            var fontSizeBox = new ToolStripComboBox();
            fontSizeBox.Items.AddRange(fontSizes.Select(f => f.ToString()).ToArray());
            fontSizeBox.Name = "fontSizeSelector";
            fontSizeBox.Size = new System.Drawing.Size(25, 25);
            fontSizeBox.SelectedIndexChanged += (sender, o) =>
                {
                    if (!updatingFontSize) return;
                    var size = ((ToolStripComboBox)sender).SelectedItem;
                    _doc.ExecCommand("FontSize", false, size);
                };
            fontSizeBox.Enter += (es, eo) => updatingFontSize = true;
            fontSizeBox.Leave += (ls, lo) => updatingFontSize = false;
            fontSizeBox.DropDownStyle = ComboBoxStyle.DropDownList;

            this.AddToolbarItem(fontSizeBox);
        }

        internal void AddStyleSelector()
        {
            var styleBox = new ToolStripComboBox();
            styleBox.Items.AddRange(styles.Select(s => s.ToString()).ToArray());
            styleBox.Name = "styleSelector";
            styleBox.Size = new Size(80, 25);
            styleBox.SelectedIndexChanged += (s, o) =>
                {
                    var value = ((ToolStripComboBox)s).SelectedItem;
                    _doc.ExecCommand("formatblock", false, value);
                };
            styleBox.Enter += (es, eo) => updatingStyle = true;
            styleBox.Leave += (ls, lo) => updatingStyle = false;
            styleBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.AddToolbarItem(styleBox);
        }

        public void AddFontSelector(IEnumerable<string> fontNames)
        {
            var dropDown = new ToolStripDropDownButton();
            foreach (var fontName in fontNames)
            {
                dropDown.DropDownItems.Add(GetFontDropDownItem(fontName));
            }
            dropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            dropDown.Name = "Font";
            dropDown.Size = new System.Drawing.Size(29, 22);
            dropDown.Text = "Font";

            this.AddToolbarItem(dropDown);
        }

        private ToolStripItem GetFontDropDownItem(string fontName)
        {
            var dropDownItem = new ToolStripMenuItem();
            dropDownItem.Font = new Font(fontName, 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dropDownItem.Name = "fontMenuItem" + Guid.NewGuid();
            dropDownItem.Size = new Size(173, 22);
            dropDownItem.Text = fontName;
            dropDownItem.Click += (sender, e) => _doc.ExecCommand("FontName", false, fontName);
            return dropDownItem;
        }

        public void AddToolbarItem(ToolStripItem toolStripItem)
        {
            editcontrolsToolStrip.Items.Add(toolStripItem);
        }

        public void AddToolbarItems(IEnumerable<ToolStripItem> toolStripItems)
        {
            foreach (var stripItem in toolStripItems)
            {
                editcontrolsToolStrip.Items.Add(stripItem);
            }
        }

        public void AddToolbarItem(IHTMLEditorButton toolbarItem)
        {
            _customButtons.Add(toolbarItem);
            editcontrolsToolStrip.Items.Add(CreateButton(toolbarItem));
        }

        public void AddToolbarItems(IEnumerable<IHTMLEditorButton> toolbarItems)
        {
            foreach (var toolbarItem in toolbarItems)
            {
                AddToolbarItem(toolbarItem);
            }
        }

        public void AddToolbarDivider()
        {
            var divider = new ToolStripSeparator();
            divider.Size = new System.Drawing.Size(6, 25);
            editcontrolsToolStrip.Items.Add(divider);
        }

        public void ExecuteButtonFunction<T>(params object[] arguments)
            where T : IHTMLEditorButton
        {
            var button = (IHTMLEditorButton)Activator.CreateInstance(typeof(T), arguments);
            var args = new HTMLEditorButtonArgs { Document = this._doc, Editor = this };
            button.IconClicked(args);
        }

        private ToolStripItem CreateButton(IHTMLEditorButton toolbarItem)
        {
            var toolStripButton = new ToolStripButton();
            toolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton.Image = toolbarItem.IconImage;
            toolStripButton.ImageScaling = ToolStripItemImageScaling.None;
            toolStripButton.ImageTransparentColor = Color.Magenta;
            toolStripButton.Name = toolbarItem.IconName;
            toolStripButton.Size = new Size(25, 24);
            toolStripButton.Text = toolbarItem.IconTooltip;
            toolStripButton.MergeAction = MergeAction.Append;

            var args = new HTMLEditorButtonArgs { Document = this._doc, Editor = this };

            IHTMLEditorButton button = toolbarItem;
            toolStripButton.Click += (sender, o) => button.IconClicked(args);

            return toolStripButton;
        }

        public bool ReadOnly
        {
            get
            {
                if (textWebBrowser.Document != null)
                {
                    var doc = textWebBrowser.Document.DomDocument as IHTMLDocument2;
                    if (doc != null)
                    {
                        return doc.designMode != "On";
                    }
                }
                return false;
            }
            set
            {
                if (textWebBrowser.Document != null)
                {
                    var designMode = value ? "Off" : "On";
                    var doc = textWebBrowser.Document.DomDocument as IHTMLDocument2;
                    if (doc != null) doc.designMode = designMode;
                }
            }
        }

        public bool ShowToolbar
        {
            get
            {
                if (editcontrolsToolStrip != null)
                {
                    return editcontrolsToolStrip.Visible;
                }
                return true;
            }
            set
            {
                editcontrolsToolStrip.Visible = value;
            }
        }

        public ToolStrip Toolbar
        {
            get
            {
                return this.editcontrolsToolStrip;
            }
        }

        private void updateToolBarTimer_Tick(object sender, System.EventArgs e)
        {
            CheckCommandStateChanges();
            if (string.Compare(this.originalText, this.textWebBrowser.DocumentText, StringComparison.InvariantCulture)
                != 0)
            {
                this.originalText = this.textWebBrowser.DocumentText;
                this.OnDocumentTextChanged();
            }
        }

        private void InitializeWebBrowserAsEditor()
        {
            // It is necessary to add a body to the control before you can apply changes to the DOM document
            textWebBrowser.DocumentText = "<html><body></body></html>";
            if (textWebBrowser.Document != null)
            {
                var doc = textWebBrowser.Document.DomDocument as IHTMLDocument2;
                if (doc != null) doc.designMode = "On";

                // replace the context menu for the web browser control so the default IE browser context menu doesn't show up
                textWebBrowser.IsWebBrowserContextMenuEnabled = false;
                if (this.ContextMenuStrip == null)
                {
                    textWebBrowser.Document.ContextMenuShowing += (sender, e) => { ; };
                }
            }
        }

        private void Document_ContextMenuShowing(object sender, HtmlElementEventArgs e)
        {
            this.ContextMenuStrip.Show(this, this.PointToClient(Cursor.Position));
        }

        public string Html
        {
            get
            {
                return textWebBrowser.DocumentText;
            }
            set
            {
                if (SetHtml(value))
                {
                    this.originalText = textWebBrowser.DocumentText;
                }
            }
        }

        internal bool SetHtml(string html)
        {
            if (textWebBrowser.Document != null)
            {
                // updating this way avoids an alert box
                var doc = textWebBrowser.Document.DomDocument as IHTMLDocument2;
                if (doc != null)
                {
                    doc.write(html);
                    doc.close();
                    return true;
                }
            }
            return false;
        }

        public string InsertTextAtCursor
        {
            set
            {
                _doc.ExecCommand("Paste", false, value);
            }
        }

        private void CheckCommandStateChanges()
        {
            var doc = (IHTMLDocument2)_doc.DomDocument;

            var commands = _customButtons.Select(c => c.CommandIdentifier).Where(c => !string.IsNullOrEmpty(c));

            foreach (var command in commands)
            {
                var button = (ToolStripButton)editcontrolsToolStrip.Items[command];

                if (button == null) continue;

                if (doc.queryCommandState(command))
                {
                    if (button.CheckState != CheckState.Checked)
                    {
                        button.Checked = true;
                    }
                }
                else
                {
                    if (button.CheckState == CheckState.Checked)
                    {
                        button.Checked = false;
                    }
                }
            }

            var styleSelector =
                (ToolStripComboBox)editcontrolsToolStrip.Items.Find("styleSelector", false).FirstOrDefault();
            if (styleSelector != null && !updatingStyle)
            {
                var currentStyle = doc.queryCommandValue("formatblock");
                styleSelector.SelectedItem = currentStyle;
            }

            var fontSizeSelector =
                (ToolStripComboBox)editcontrolsToolStrip.Items.Find("fontSizeSelector", false).FirstOrDefault();
            if (fontSizeSelector != null && !updatingFontSize)
            {
                var currentFontSize = doc.queryCommandValue("FontSize");
                var currentFontSizeStr = currentFontSize.ToString();
                updatingFontSize = false;
                fontSizeSelector.SelectedItem = currentFontSizeStr;
            }
        }

        private void HtmlEditor_ContextMenuStripChanged(object sender, System.EventArgs e)
        {
            if (textWebBrowser.Document != null)
            {
                textWebBrowser.Document.ContextMenuShowing += Document_ContextMenuShowing;
            }
        }

        private void textWebBrowser_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            this.OnDocumentPreviewKeyDown(e);
        }
    }
}
