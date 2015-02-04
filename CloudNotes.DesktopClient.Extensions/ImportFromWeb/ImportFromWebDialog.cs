

namespace CloudNotes.DesktopClient.Extensions.ImportFromWeb
{
    using CloudNotes.DesktopClient.Extensibility;
    using CloudNotes.Infrastructure;
    using System;
    using System.Net;
    using System.Text;
    using System.Windows.Forms;

    public partial class ImportFromWebDialog : Form
    {
        private readonly ImportFromWebSetting setting;
        private readonly WebClient webClient = new WebClient();
        private string htmlContent;


        public ImportFromWebDialog()
        {
            InitializeComponent();
        }

        public ImportFromWebDialog(ImportFromWebSetting setting)
            : this()
        {
            this.setting = setting;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (string.IsNullOrEmpty(txtLink.Text))
            {
                errorProvider.SetError(txtLink, "Link cannot be empty.");
                this.DialogResult = DialogResult.None;
                return;
            }

            Uri uri = null;
            try
            {
                uri = new Uri(txtLink.Text);
            }
            catch
            {
                errorProvider.SetError(txtLink, "Link is not valid.");
                this.DialogResult = DialogResult.None;
                return;
            }

            btnOK.Enabled = false;
            txtLink.ReadOnly = true;
            
            webClient.Encoding = Encoding.GetEncoding(this.setting.EncodingCodePage);
            progressBar.Visible = true;
            progressBar.Style = ProgressBarStyle.Marquee;

            webClient.DownloadStringCompleted += async (sdSender, sdArgs) =>
                {
                    if (sdArgs.Error != null)
                    {
                        FrmExceptionDialog.ShowException(sdArgs.Error);
                        this.DialogResult = DialogResult.Cancel;
                        this.Close();
                        return;
                    }

                    if (!sdArgs.Cancelled)
                    {
                        this.htmlContent = sdArgs.Result;
                        if (this.setting.EmbedImages)
                        {
                            btnCancel.Enabled = false;
                            this.ControlBox = false;
                            progressBar.Style = ProgressBarStyle.Continuous;
                            this.htmlContent = await HtmlUtilities.ReplaceWebImagesAsync(this.htmlContent, (a, b) =>
                                {
                                    progressBar.Maximum = b;
                                    progressBar.Value = a;
                                });
                        }
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                };

            webClient.DownloadStringAsync(new Uri(txtLink.Text));            
        }

        public string HtmlContent
        {
            get { return this.htmlContent; }
        }

        private void ImportFromWebDialog_Shown(object sender, EventArgs e)
        {
            progressBar.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.webClient.CancelAsync();
        }
    }
}
