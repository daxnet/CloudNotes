using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudNotes.DesktopClient.Extensions.Blog
{
    using System.Drawing;
    using System.Windows.Forms;
    using CloudNotes.DesktopClient.Extensibility;
    using CloudNotes.DesktopClient.Extensibility.Extensions;
    using CloudNotes.DesktopClient.Extensions.Properties;
    using CloudNotes.Infrastructure;

    [Extension("321945D2-9CF8-40A7-B794-323A27CF8900", "Blog", typeof(BlogSettingProvider))]
    public class BlogExtension : ToolExtension
    {
        public BlogExtension()
            : base("Publish to Blog...")
        {
        }

        protected override void DoExecute(IShell shell)
        {
            //var note = shell.Note;
            //var cleanup = HtmlUtilities.Tidy(note.Content);
            //new Form1(cleanup).ShowDialog();

            var blogSetting = this.SettingProvider.GetExtensionSetting<BlogSetting>();
            var blogPublishDialog = new FrmBlogPublish(blogSetting);
            if (blogPublishDialog.ShowDialog() == DialogResult.OK)
            {
                
            }
        }

        public override string Manufacture
        {
            get { return "Sunny Chen"; }
        }

        public override string Description
        {
            get { return "Publish the current note to the blog which has been pre-configured in Desktop Client settings."; }
        }

        public override Image ToolIcon
        {
            get { return Resources.BlogIcon; }
        }
    }
}
