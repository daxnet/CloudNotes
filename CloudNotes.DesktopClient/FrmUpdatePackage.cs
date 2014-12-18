using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace CloudNotes.DesktopClient
{
    public partial class FrmUpdatePackage : Form
    {
        private readonly dynamic packageInformation;

        public FrmUpdatePackage(dynamic packageInformation)
        {
            InitializeComponent();
            this.packageInformation = packageInformation;
        }

        private void FrmUpdatePackage_Load(object sender, EventArgs e)
        {
            lblLatestVersion.Text = packageInformation.Version.ToString();
            lblPublished.Text = ((DateTime) packageInformation.DatePublished).ToLocalTime().ToLongDateString();
            lblCurrentVersion.Text = typeof (Program).Assembly.GetName().Version.ToString();
            wbReleaseNotes.DocumentText = packageInformation.ReleaseNotes.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var processStartInfo = new ProcessStartInfo("Updater\\cnupdater.exe", string.Format("{0} {1}", packageInformation.PackageDownloadURL.ToString(), Thread.CurrentThread.CurrentUICulture.Name));
            Process.Start(processStartInfo);
            Application.Exit();
        }
    }
}
