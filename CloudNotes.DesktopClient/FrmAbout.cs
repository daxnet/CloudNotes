namespace CloudNotes.DesktopClient
{
    using CloudNotes.DesktopClient.Extensibility;
    using Infrastructure;
    using Properties;
    using System;
    using System.Diagnostics;
    using System.Reflection;
    using System.Threading;
    using System.Windows.Forms;

    public partial class FrmAbout : Form
    {
        private readonly ExtensionManager extensionManager;

        internal FrmAbout(ExtensionManager extensionManager)
        {
            this.InitializeComponent();
            this.extensionManager = extensionManager;
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

            this.lstExtensions.Groups.Clear();
            var grpToolExtension = this.lstExtensions.Groups.Add("grpToolExtension", Resources.ToolExtensionGroupName);
            var grpExportExtension = this.lstExtensions.Groups.Add("grpExportExtension", Resources.ExportExtensionGroupName);

            this.ilExtensions.Images.Clear();
            this.ilExtensions.Images.Add("plugin.png", Resources.plugin);
            // Displays all the extensions.
            foreach(var kvp in this.extensionManager.AllExtensions)
            {
                var extension = kvp.Value;
                var lvi = new ListViewItem(new[] { extension.DisplayName, extension.Version.ToString(), extension.Manufacture, extension.Description });
                if (extension.Kind == typeof(ToolExtension))
                {
                    lvi.Group = grpToolExtension;
                    this.ilExtensions.Images.Add(extension.ID.ToString(), ((ToolExtension)extension).ToolIcon);
                    lvi.ImageKey = extension.ID.ToString();
                }
                else if (extension.Kind == typeof(ExportExtension))
                {
                    lvi.Group = grpExportExtension;
                    lvi.ImageKey = "plugin.png";
                }
                this.lstExtensions.Items.Add(lvi);
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
