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
    using CloudNotes.DesktopClient.Extensibility;
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
            try
            {
                var categories = await this.blogClient.GetCategoriesAsync();
                if (categories.Count > 0)
                {
                    foreach (var category in categories)
                    {
                        var listViewItem = lstCategories.Items.Add(category.Title);
                        listViewItem.Tag = category;
                    }
                }
            }
            catch (Exception ex)
            {
                FrmExceptionDialog.ShowException(ex);
            }
            
        }


    }
}
