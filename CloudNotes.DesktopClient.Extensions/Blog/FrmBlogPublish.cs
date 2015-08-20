using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudNotes.DesktopClient.Extensions.Blog
{
    using CloudNotes.DesktopClient.Extensions.Blog.MetaWeblogSharp;

    public partial class FrmBlogPublish : Form
    {
        private readonly BlogSetting setting;
        private readonly Client blogClient;

        private FrmBlogPublish()
        {
            InitializeComponent();
        }

        public FrmBlogPublish(BlogSetting setting)
            : this()
        {
            this.setting = setting;
            var connectionInfo = new BlogConnectionInfo(string.Empty, setting.MetaWeblogAddress, string.Empty,
                 setting.UserName, setting.Password);
            blogClient = new Client(connectionInfo);
        }

        private async void FrmBlogPublish_Shown(object sender, EventArgs e)
        {
            var blogs = await blogClient.GetUsersBlogsAsync();
            
            if (blogs.Count > 0)
            {
                foreach (var blog in blogs)
                {
                    cbBlogs.Items.Add(blog.BlogName);
                }
                cbBlogs.SelectedIndex = 0;
            }
        }


    }
}
