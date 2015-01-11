namespace CloudNotes.DesktopClient
{
    using System;
    using System.Diagnostics;
    using System.Reflection;
    using System.Threading;
    using System.Windows.Forms;
    using Infrastructure;
    using Properties;

    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            this.InitializeComponent();
        }

        private void ExecuteLink(string url)
        {
            Process.Start(url);
        }

        private void FrmAbout_Load(object sender, EventArgs e)
        {
            this.lblTitle.Text = string.Format(
                "{0} version {1}",
                this.GetType().Assembly.GetCustomAttribute<AssemblyTitleAttribute>().Title,
                this.GetType().Assembly.GetName().Version);
            this.txtLicense.Text = Resources.License;
            foreach (var assemblyName in this.GetType().Assembly.GetReferencedAssemblies())
            {
                this.lstAssemblies.Items.Add(
                    new ListViewItem(
                        new[] { assemblyName.Name, assemblyName.Version.ToString(), assemblyName.FullName },
                        "Assembly.png"));
            }
        }

        private void lblAuthorName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Thread.CurrentThread.CurrentUICulture.Name == "zh-CN")
            {
                "http://mvp.microsoft.com/zh-cn/mvp/Qingyang%20Chen-4038146".Navigate();
            }
            else
            {
                "http://mvp.microsoft.com/en-us/mvp/Qingyang%20Chen-4038146".Navigate();
            }
            
        }

        private void lblBlog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Thread.CurrentThread.CurrentUICulture.Name == "zh-CN")
            {
                "http://daxnet.cnblogs.com".Navigate();
            }
            else
            {
                "http://daxnetsvr.cloudapp.net/schen".Navigate();
            }
            
        }

        private void lblDonateLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            "http://www.alipay.com".Navigate();
        }
    }
}
