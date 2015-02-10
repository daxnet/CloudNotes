//  =======================================================================================================
// 
//     ,uEZGZX  LG                             Eu       iJ       vi                                              
//    BB7.  .:  uM                             8F       0BN      Bq             S:                               
//   @X         LO    rJLYi    :     i    iYLL XJ       Xu7@     Mu    7LjL;   rBOii   7LJ7    .vYUi             
//  ,@          LG  7Br...SB  vB     B   B1...7BL       0S i@,   OU  :@7. ,u@   @u.. :@:  ;B  LB. ::             
//  v@          LO  B      Z0 i@     @  BU     @Y       qq  .@L  Oj  @      5@  Oi   @.    MB U@                 
//  .@          JZ :@      :@ rB     B  @      5U       Eq    @0 Xj ,B      .B  Br  ,B:rv777i  :0ZU              
//   @M         LO  @      Mk :@    .@  BL     @J       EZ     GZML  @      XM  B;   @            Y@             
//    ZBFi::vu  1B  ;B7..:qO   BS..iGB   BJ..:vB2       BM      rBj  :@7,.:5B   qM.. i@r..i5. ir. UB             
//      iuU1vi   ,    ;LLv,     iYvi ,    ;LLr  .       .,       .     rvY7:     rLi   7LLr,  ,uvv:  
// 
// 
//  Copyright 2014-2015 daxnet
//  
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//  
//      http://www.apache.org/licenses/LICENSE-2.0
//  
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//  =======================================================================================================

namespace CloudNotes.DesktopClient.Extensions.ImportFromWeb
{
    using System;
    using System.Net;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    using CloudNotes.DesktopClient.Extensibility;
    using CloudNotes.DesktopClient.Extensions.Properties;
    using CloudNotes.Infrastructure;

    /// <summary>
    ///     Represents the dialog with which CloudNotes users are able to import the note
    ///     from a web page on the internet.
    /// </summary>
    public partial class ImportFromWebDialog : Form
    {
        #region Private Fields

        private readonly ImportFromWebSetting setting;
        private readonly WebClient webClient = new WebClient();
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        #endregion

        #region Ctor

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImportFromWebDialog" /> class.
        /// </summary>
        public ImportFromWebDialog()
        {
            this.InitializeComponent();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImportFromWebDialog" /> class.
        /// </summary>
        /// <param name="setting">
        ///     The <see cref="ImportFromWebSetting" /> instance which contains the settings for the
        ///     <see cref="ImportFromWebExtension" />.
        /// </param>
        public ImportFromWebDialog(ImportFromWebSetting setting)
            : this()
        {
            this.setting = setting;
        }

        #endregion

        #region Private Event Handlers

        private void btnOK_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (string.IsNullOrEmpty(txtLink.Text))
            {
                errorProvider.SetError(txtLink, Resources.LinkEmpty);
                this.DialogResult = DialogResult.None;
                return;
            }
            string baseUri;
            try
            {
                var uri = new Uri(txtLink.Text);
                baseUri = string.Format("{0}://{1}", uri.Scheme, uri.DnsSafeHost);
                if ((uri.Scheme == Uri.UriSchemeHttps && uri.Port != 443) || (uri.Scheme == Uri.UriSchemeHttp && uri.Port != 80))
                {
                    baseUri = string.Format("{0}:{1}", baseUri, uri.Port);
                }
            }
            catch
            {
                errorProvider.SetError(txtLink, Resources.LinkNotValid);
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
                    this.HtmlContent = sdArgs.Result;
                    if (this.setting.EmbedImages)
                    {
                        slblStatus.Text = Resources.ProcessingImages;
                        progressBar.Style = ProgressBarStyle.Continuous;
                        this.HtmlContent =
                            await
                                HtmlUtilities.ReplaceWebImagesAsync(this.HtmlContent, baseUri,
                                    this.cancellationTokenSource.Token,
                                    (a, b) =>
                                    {
                                        progressBar.Maximum = b;
                                        progressBar.Value = a;
                                    });
                    }
                    slblStatus.Text = string.Empty;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            };
            slblStatus.Text = Resources.DownloadingWebPage;
            slblStatus.Visible = true;
            webClient.DownloadStringAsync(new Uri(txtLink.Text));
        }

        public string HtmlContent { get; private set; }

        private void ImportFromWebDialog_Shown(object sender, EventArgs e)
        {
            progressBar.Visible = false;
            slblStatus.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.webClient.CancelAsync();
            this.cancellationTokenSource.Cancel();
        }

        #endregion
    }
}