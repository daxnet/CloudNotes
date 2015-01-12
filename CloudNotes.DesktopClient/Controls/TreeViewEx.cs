using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

using CloudNotes.DesktopClient.Properties;

namespace CloudNotes.DesktopClient.Controls
{
    using Extensibility.Data;

    /// <summary>
    /// Represents the extended TreeView control that can be used specifically by CloudNotes.
    /// </summary>
    public sealed class TreeViewEx : TreeView
    {
        #region Private Constants

        private const int WM_PRINTCLIENT = 792;

        private const int PRF_CLIENT = 4;
        #endregion

        #region Private Fields
        private int itemHeight;

        private int titleHeight;

        private int descriptionHeight;

        private volatile bool isItemHeightSet;
        #endregion

        #region Ctor
        /// <summary>
        /// Initialize a new instance of <c>TreeViewEx</c> class.
        /// </summary>
        public TreeViewEx()
        {
            this.DrawMode = TreeViewDrawMode.OwnerDrawText;
            this.HighlightBackgroundColor = SystemColors.Highlight;
            this.HighlightTextColor = SystemColors.HighlightText;
            this.TitleColor = ForeColor;
            this.DescriptionTextColor = ForeColor;
            this.NormalTextBackgroundColor = BackColor;
            this.FullRowSelect = true;
            this.ShowLines = false;
            this.ImageWidth = 80;
            this.DescriptionIndent = 0;

            // Enable default double buffering processing (DoubleBuffered returns true)
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.AllPaintingInWmPaint, true);
            // Disable default CommCtrl painting on non-Vista systems
            if (Environment.OSVersion.Version.Major < 6)
                SetStyle(ControlStyles.UserPaint, true);

            this.DoubleBuffered = true;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the background color of the highlighted item.
        /// </summary>
        [Category("TreeViewEx")]
        [Description("Gets or sets the background color of the highlighted item.")]
        public Color HighlightBackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the foreground color of the highlighted item.
        /// </summary>
        [Category("TreeViewEx")]
        [Description("Gets or sets the text color of the highlighted item.")]
        public Color HighlightTextColor { get; set; }

        /// <summary>
        /// Gets or sets the text color of the item description.
        /// </summary>
        [Category("TreeViewEx")]
        [Description("Gets or sets the text color of the item description.")]
        public Color DescriptionTextColor { get; set; }

        /// <summary>
        /// Gets or sets the text color of the item title.
        /// </summary>
        [Category("TreeViewEx")]
        [Description("Gets or sets the text color of the item title.")]
        public Color TitleColor { get; set; }

        /// <summary>
        /// Gets or sets the background color of the text for a normal tree node.
        /// </summary>
        [Category("TreeViewEx")]
        [Description("Gets or sets the background color of the text for a normal tree node.")]
        public Color NormalTextBackgroundColor { get; set; }

        private Font titleFont;
        /// <summary>
        /// Gets or sets the font of the item title.
        /// </summary>
        [Category("TreeViewEx")]
        [Description("Gets or sets the font of the item title.")]
        public Font TitleFont
        {
            get
            {
                return titleFont;
            }
            set
            {
                titleFont = value;
            }
        }

        /// <summary>
        /// Gets or sets the font of the item description.
        /// </summary>
        [Category("TreeViewEx")]
        [Description("Gets or sets the font of the item description.")]
        public Font DescriptionFont { get; set; }

        /// <summary>
        /// Gets or sets the maximum width of the image.
        /// </summary>
        [Category("TreeViewEx")]
        [Description("Gets or sets the maximum width of the image.")]
        public int ImageWidth { get; set; }

        /// <summary>
        /// Gets or sets the indent value of the item description.
        /// </summary>
        [Category("TreeViewEx")]
        [Description("Gets or sets the indent value of the item description.")]
        public int DescriptionIndent { get; set; }
        #endregion

        #region Private Static Methods
        private static Image FixedSize(Image imgPhoto, int width, int height, Color clearColor)
        {
            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;

            float nPercent;
            float nPercentW;
            float nPercentH;

            nPercentW = ((float)width / (float)sourceWidth);
            nPercentH = ((float)height / (float)sourceHeight);
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                destX = Convert.ToInt16((width - (sourceWidth * nPercent)) / 2);
            }
            else
            {
                nPercent = nPercentW;
                destY = Convert.ToInt16((height - (sourceHeight * nPercent)) / 2);
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(width, height,
                PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(clearColor);
            grPhoto.InterpolationMode =
                InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Adds a <see cref="TreeNodeExItem"/> object to the specified tree node collection.
        /// </summary>
        /// <param name="collection">The tree node collection to which the item should be added.</param>
        /// <param name="item">The <see cref="TreeNodeExItem"/> object to be added.</param>
        /// <returns>A <see cref="TreeNode"/> which contains the <see cref="TreeNodeExItem"/> data.</returns>
        public TreeNode AddItem(TreeNodeCollection collection, TreeNodeExItem item)
        {
            var imageIndex = this.ImageList == null ? -1 : this.ImageList.Images.Count + 1;
            var treeNode = collection.Add(item.Title);
            treeNode.Tag = item;
            treeNode.ImageIndex = treeNode.SelectedImageIndex = treeNode.StateImageIndex = imageIndex;
            return treeNode;
        }

        /// <summary>
        /// Adds a <see cref="TreeNodeExItem"/> object to the specified tree node collection.
        /// </summary>
        /// <param name="collection">The tree node collection to which the item should be added.</param>
        /// <param name="title">The title of the item.</param>
        /// <param name="description">The description of the item.</param>
        /// <param name="data">The data of the item.</param>
        /// <param name="image">The image of the data.</param>
        /// <returns>A <see cref="TreeNode"/> which contains the <see cref="TreeNodeExItem"/> data.</returns>
        public TreeNode AddItem(TreeNodeCollection collection, string title, string description, Note data, Image image = null)
        {
            return AddItem(collection, new TreeNodeExItem
                                           {
                                               Data = data,
                                               Description = description,
                                               Image = image,
                                               Title = title
                                           });
        }
        #endregion

        #region Overrides of TreeView

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.TreeView.DrawNode"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.DrawTreeNodeEventArgs"/> that contains the event data. </param>
        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            if (!isItemHeightSet)
            {
                isItemHeightSet = true;
                var graphics = this.CreateGraphics();
                titleHeight = Convert.ToInt32(graphics.MeasureString("T", this.TitleFont).Height);
                descriptionHeight = Convert.ToInt32(graphics.MeasureString("D", this.DescriptionFont).Height);
                itemHeight = titleHeight + descriptionHeight;
                this.ItemHeight = itemHeight;
            }
            var item = e.Node.Tag as TreeNodeExItem;
            var isFocused = (e.State & TreeNodeStates.Focused) != 0;
            var isSelected = (e.State & TreeNodeStates.Selected) != 0;
            var selectionRegion = new Rectangle(0, e.Bounds.Y, e.Node.TreeView.Width, e.Bounds.Height);

            if (item == null)
            {
                var normalTextForeColor = ForeColor;
                var normalTextBackColor = NormalTextBackgroundColor;
                if (isSelected || isFocused)
                {
                    normalTextForeColor = HighlightTextColor;
                    normalTextBackColor = HighlightBackgroundColor;
                    using (var brush = new SolidBrush(this.HighlightBackgroundColor))
                    {
                        e.Graphics.FillRectangle(brush, selectionRegion);
                    }
                }
                else
                {
                    using (var brush = new SolidBrush(normalTextBackColor))
                    {
                        e.Graphics.FillRectangle(brush, selectionRegion);
                    }
                }
                if (ShowPlusMinus && e.Node.Nodes.Count > 0)
                {
                    // Use the VisualStyles renderer to use the proper OS-defined glyphs
                    Rectangle expandRect = new Rectangle((e.Node.Level * this.Indent) + 1,
                        (e.Bounds.Top + e.Bounds.Bottom) / 2 - 7, 16, 16);

                    //VisualStyleElement element = (e.Node.IsExpanded)
                    //    ? VisualStyleElement.TreeView.Glyph.Opened
                    //    : VisualStyleElement.TreeView.Glyph.Closed;
                    //VisualStyleRenderer renderer = new VisualStyleRenderer(element);
                    //renderer.DrawBackground(e.Graphics, expandRect);
                    e.Graphics.DrawImage(e.Node.IsExpanded ? Resources.Expanded : Resources.Collapsed, expandRect);
                }

                var normalTextIndent = this.Indent;
                if (e.Node.TreeView.ImageList != null && e.Node.ImageIndex >= 0)
                {
                    var imageList = e.Node.TreeView.ImageList;
                    var normalTextImageRegion = new Rectangle(
                        (e.Node.Level * this.Indent) + 18,
                        e.Bounds.Y + ((this.itemHeight - imageList.ImageSize.Height)/2),
                        imageList.ImageSize.Width,
                        imageList.ImageSize.Height);
                    e.Graphics.DrawImage(imageList.Images[e.Node.ImageIndex], normalTextImageRegion);
                    normalTextIndent = (e.Node.Level * this.Indent);
                }

                const TextFormatFlags normalTextFlag =
                    TextFormatFlags.Left | TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter
                    | TextFormatFlags.EndEllipsis;
                var normalTextRegion = new Rectangle(
                    e.Bounds.X + normalTextIndent,
                    e.Bounds.Y,
                    e.Node.TreeView.Width - normalTextIndent,
                    e.Bounds.Height);

                TextRenderer.DrawText(
                    e.Graphics,
                    e.Node.Text,
                    Font,
                    normalTextRegion,
                    normalTextForeColor,
                    normalTextBackColor,
                    normalTextFlag);
                return;
            }

            var itemIndent = e.Node.TreeView.ImageList == null ? 0 : e.Node.TreeView.ImageList.ImageSize.Width / 2;

            var itemRegion = item.Image != null
                ? new Rectangle(
                    e.Bounds.X - itemIndent,
                    e.Bounds.Y,
                    e.Node.TreeView.Width - e.Bounds.X - ImageWidth + itemIndent,
                    e.Bounds.Height)
                : new Rectangle(
                    e.Bounds.X - itemIndent,
                    e.Bounds.Y,
                    e.Node.TreeView.Width - e.Bounds.X + itemIndent,
                    e.Bounds.Height);

            var imageRegion = new Rectangle(
                itemRegion.X + itemRegion.Width,
                itemRegion.Y,
                ImageWidth - 5,
                itemRegion.Height - 2);

            var titleColor = TitleColor;
            var backColor = BackColor;
            var descriptionTextColor = DescriptionTextColor;
            if (isFocused)
            {
                titleColor = HighlightTextColor;
                descriptionTextColor = HighlightTextColor;
                backColor = HighlightBackgroundColor;
                using (var brush = new SolidBrush(backColor))
                {
                    e.Graphics.FillRectangle(brush, selectionRegion);
                }
            }

            // draw title
            const TextFormatFlags titleTextFormatFlags = TextFormatFlags.Left | TextFormatFlags.SingleLine
                                                         | TextFormatFlags.Top | TextFormatFlags.EndEllipsis | TextFormatFlags.GlyphOverhangPadding;

            TextRenderer.DrawText(e.Graphics, item.Title, TitleFont, itemRegion, titleColor,
                titleTextFormatFlags);

            // draw description
            const TextFormatFlags descriptionTextFormatFlags = TextFormatFlags.Left | TextFormatFlags.SingleLine
                                                               | TextFormatFlags.Top | TextFormatFlags.EndEllipsis | TextFormatFlags.GlyphOverhangPadding;
            var descriptionTextRegion = new Rectangle(
                itemRegion.X + this.DescriptionIndent,
                itemRegion.Y + titleHeight,
                itemRegion.Width - this.DescriptionIndent,
                itemRegion.Height - titleHeight);

            TextRenderer.DrawText(
                e.Graphics,
                item.Description,
                DescriptionFont,
                descriptionTextRegion,
                descriptionTextColor,
                descriptionTextFormatFlags);

            // draw image
            if (item.Image != null)
            {
                e.Graphics.DrawImage(FixedSize(item.Image, imageRegion.Width, this.ItemHeight, backColor), imageRegion);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            this.Refresh();
            base.OnResize(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (GetStyle(ControlStyles.UserPaint))
            {
                var m = new Message
                            {
                                HWnd = Handle,
                                Msg = WM_PRINTCLIENT,
                                WParam = e.Graphics.GetHdc(),
                                LParam = (IntPtr)PRF_CLIENT
                            };
                DefWndProc(ref m);
                e.Graphics.ReleaseHdc(m.WParam);
            }
            base.OnPaint(e);
        }

        #endregion

        #region Nested Classes
        /// <summary>
        /// Represents the item that will be held by the node in the <see cref="TreeViewEx"/> control.
        /// </summary>
        public sealed class TreeNodeExItem
        {
            /// <summary>
            /// Gets or sets the title of the item.
            /// </summary>
            public string Title { get; set; }
            /// <summary>
            /// Gets or sets the description of the item.
            /// </summary>
            public string Description { get; set; }
            /// <summary>
            /// Gets or sets the data of the item.
            /// </summary>
            public Note Data { get; set; }
            /// <summary>
            /// Gets or sets the image of the item.
            /// </summary>
            public Image Image { get; set; }

            public override string ToString()
            {
                return this.Title;
            }
        }
        #endregion
    }
}
