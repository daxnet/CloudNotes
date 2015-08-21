namespace CloudNotes.DesktopClient.Extensions.Blog
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using CloudNotes.DesktopClient.Extensibility;
    using CloudNotes.DesktopClient.Extensions.Blog.MetaWeblogSharp;

    public partial class FrmBlogPublish : Form
    {
        private readonly BlogGateway gateway;

        private FrmBlogPublish()
        {
            InitializeComponent();
            UpdateControlState();
        }

        public FrmBlogPublish(BlogGateway gateway)
            : this()
        {
            this.gateway = gateway;
        }

        public IEnumerable<CategoryInfo> SelectedCategories
        {
            get { return from ListViewItem item in lstCategories.CheckedItems select item.Tag as CategoryInfo; }
        }

        private void UpdateControlState()
        {
            btnOK.Enabled = lstCategories.CheckedItems.Count > 0;
        }

        private async Task ListCategoriesAsync()
        {
            try
            {
                lstCategories.Items.Clear();
                var categories = await this.gateway.GetCategoriesAsync();
                if (categories.Count > 0)
                {
                    foreach (var category in categories)
                    {
                        var listViewItem = lstCategories.Items.Add(category.Title);
                        listViewItem.Tag = category;
                    }
                }
                UpdateControlState();
            }
            catch (Exception ex)
            {
                FrmExceptionDialog.ShowException(ex);
            }
        }

        private void lstCategories_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            UpdateControlState();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await ListCategoriesAsync();
        }

        private async void FrmBlogPublish_Shown(object sender, EventArgs e)
        {
            await ListCategoriesAsync();
        }

    }
}
