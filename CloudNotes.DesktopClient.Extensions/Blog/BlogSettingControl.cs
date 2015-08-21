
namespace CloudNotes.DesktopClient.Extensions.Blog
{
    using System;
    using System.Windows.Forms;
    using CloudNotes.DesktopClient.Extensibility;
    using CloudNotes.DesktopClient.Extensions.Properties;

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
                var gateway = new BlogGateway(txtMetaWeblogAddress.Text, txtUserName.Text, txtPassword.Text);
                if (await gateway.TestConnectionAsync())
                {
                    MessageBox.Show(Resources.TestConnectionSucceeded, Resources.Information, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(Resources.TestConnectionFailed, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
            
        }
    }
}
