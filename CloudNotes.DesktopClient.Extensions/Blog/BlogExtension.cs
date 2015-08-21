namespace CloudNotes.DesktopClient.Extensions.Blog
{
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using CloudNotes.DesktopClient.Extensibility;
    using CloudNotes.DesktopClient.Extensibility.Extensions;
    using CloudNotes.DesktopClient.Extensions.Blog.MetaWeblogSharp;
    using CloudNotes.DesktopClient.Extensions.Properties;
    using CloudNotes.Infrastructure;

    /// <summary>
    /// Represents the extension that can publish the current note to the web log.
    /// </summary>
    [Extension("321945D2-9CF8-40A7-B794-323A27CF8900", "Blog", typeof(BlogSettingProvider))]
    public class BlogExtension : ToolExtension
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlogExtension"/> class.
        /// </summary>
        public BlogExtension()
            : base(Resources.BlogExtensionToolName)
        {
        }

        /// <summary>
        /// Executes the current extension.
        /// </summary>
        /// <param name="shell">The <see cref="IShell" /> object on which the current extension will be executed.</param>
        protected async override void DoExecute(IShell shell)
        {
            await SafeExecutionContext.ExecuteAsync((Form) shell.Owner, async () =>
            {
                var blogSetting = this.SettingProvider.GetExtensionSetting<BlogSetting>();
                var gateway = new BlogGateway(blogSetting.MetaWeblogAddress, blogSetting.UserName, blogSetting.Password);
                if (await gateway.TestConnectionAsync())
                {
                    var blogPublishDialog = new FrmBlogPublish(gateway);
                    if (blogPublishDialog.ShowDialog() == DialogResult.OK)
                    {
                        var selectedCategories = blogPublishDialog.SelectedCategories.Select(s => s.Title).ToList();
                        var postInfo = new PostInfo
                        {
                            Categories = selectedCategories,
                            DateCreated = DateTime.Now,
                            Description = HtmlUtilities.Tidy(shell.Note.Content),
                            Title = shell.Note.Title
                        };
                        await gateway.PublishBlog(postInfo, selectedCategories);
                        shell.StatusText = Resources.PublishSucceeded;
                    }
                }
                else
                {
                    MessageBox.Show(Resources.BlogExtensionCannotConnectToBlogService, Resources.Error, MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            });
        }

        public override string Manufacture
        {
            get { return Resources.ManufactureName; }
        }

        public override Shortcut Shortcut
        {
            get { return Shortcut.CtrlShiftP; }
        }

        public override string Description
        {
            get { return Resources.BlogExtensionDescription; }
        }

        public override Image ToolIcon
        {
            get { return Resources.BlogIcon; }
        }
    }
}
