
namespace CloudNotes.DesktopClient.Extensions.Blog
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using CloudNotes.DesktopClient.Extensibility;
    using CloudNotes.DesktopClient.Extensions.Blog.MetaWeblogSharp;

    public partial class BlogSettingControl : UserControl
    {
        public BlogSettingControl()
        {
            InitializeComponent();
        }

        private async void btnTestConnection_Click(object sender, EventArgs e)
        {
            await SafeExecutionContext.ExecuteAsync(this.ParentForm, async () =>
            {
                var connectionInfo = new BlogConnectionInfo(string.Empty, txtMetaWeblogAddress.Text, string.Empty,
                 txtUserName.Text, txtPassword.Text);
                var client = new Client(connectionInfo);
                var blog = (await client.GetUsersBlogsAsync()).FirstOrDefault();
                if (blog != null)
                {
                    MessageBox.Show("Test connection succeeded.", "Information", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Unable to connect to blog service.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            });
            
        }
    }
}
