using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using CloudNotes.DesktopClient.Updater.Properties;
using ICSharpCode.SharpZipLib.Zip;

namespace CloudNotes.DesktopClient.Updater
{
    public partial class FrmMain : Form
    {
        private readonly string[] args;
        private readonly WebClient webClient = new WebClient();
        private static readonly string CloudNotesPath = Directory.GetParent(Application.StartupPath).FullName;
        private static readonly string CloudNotesExeFile = Path.Combine(CloudNotesPath, "CloudNotes.exe");

        public FrmMain(string[] args)
        {
            InitializeComponent();
            this.args = args;

            webClient.DownloadProgressChanged += (pcSender, pcArgs) =>
            {
                progressBar.Maximum = Convert.ToInt32(pcArgs.TotalBytesToReceive);
                progressBar.Value = Convert.ToInt32(pcArgs.BytesReceived);
            };

            webClient.DownloadFileCompleted += async (dcSender, dcArgs) =>
            {
                if (dcArgs.Error != null)
                {
                    MessageBox.Show(Resources.UpdateFail, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    OpenCloudNotesExe();
                }
                try
                {
                    if (!dcArgs.Cancelled)
                    {
                        this.btnCancel.Enabled = false;
                        this.progressBar.Style = ProgressBarStyle.Marquee;
                        this.progressBar.MarqueeAnimationSpeed = 20;
                        this.lblIndicator.Text = Resources.ExtractingFiles;
                        var zipFile = (string) dcArgs.UserState;
                        await
                            Task.Factory.StartNew(
                                () =>
                                    new FastZip().ExtractZip(zipFile, CloudNotesPath, FastZip.Overwrite.Always, null,
                                        null, null,
                                        false));
                        OpenCloudNotesExe();
                    }
                }
                catch
                {
                    MessageBox.Show(Resources.UpdateFail, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    OpenCloudNotesExe();
                }
            };
        }

        private void OpenCloudNotesExe()
        {
            var processStartInfo = new ProcessStartInfo(CloudNotesExeFile);
            Process.Start(processStartInfo);
            Application.Exit();
        }

        private void Cancel()
        {
            webClient.CancelAsync();
            OpenCloudNotesExe();
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            try
            {
                var tmpFile = Path.GetTempFileName();
                this.lblIndicator.Text = Resources.DownloadingPackage;
                webClient.DownloadFileAsync(new Uri(this.args[0]), tmpFile, tmpFile);
            }
            catch
            {
                MessageBox.Show(Resources.UpdateFail, Resources.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                OpenCloudNotesExe();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cancel();
        }
    }
}
