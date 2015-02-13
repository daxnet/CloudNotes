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

namespace CloudNotes.DesktopClient.Updater
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Net;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using CloudNotes.DesktopClient.Updater.Properties;
    using ICSharpCode.SharpZipLib.Zip;

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