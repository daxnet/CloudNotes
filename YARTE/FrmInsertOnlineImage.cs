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

namespace YARTE
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Net;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using YARTE.Properties;

    public partial class FrmInsertOnlineImage : Form
    {
        private const string ImageUriPattern =
            @"^http://([\w-]+\.)+[\w-]+(/[\w- ./]*)+\.(?:gif|jpg|jpeg|png|bmp|GIF|JPEG|JPG|PNG|BMP|Gif|Jpg|Jpeg|Png|Bmp)$";

        private readonly Regex regex = new Regex(ImageUriPattern);
        private readonly WebClient webClient = new WebClient();

        public FrmInsertOnlineImage()
        {
            InitializeComponent();
            webClient.DownloadFileCompleted += (dfSender, dfArgs) =>
            {
                txtUri.ReadOnly = false;
                btnOK.Enabled = true;
                if (dfArgs.Error == null)
                {
                    try
                    {
                        var fileName = (string) dfArgs.UserState;
                        var img = Image.FromFile(fileName);
                        pictureBox.Image = img;
                    }
                    catch
                    {
                        pictureBox.Image = null;
                        errorProvider.SetError(txtUri, Resources.DownloadImageFailed);
                    }
                }
                else
                {
                    pictureBox.Image = null;
                    errorProvider.SetError(txtUri, Resources.DownloadImageFailed);
                }
            };
        }

        public string ImageBase64 { get; private set; }

        public string Alt { get { return this.txtUri.Text; } }

        private void txtUri_TextChanged(object sender, EventArgs e)
        {
            if (regex.IsMatch(txtUri.Text))
            {
                errorProvider.Clear();
                var fileName = Path.GetTempFileName();
                txtUri.ReadOnly = true;
                pictureBox.Image = Resources.Progress;
                btnOK.Enabled = false;
                webClient.DownloadFileAsync(new Uri(txtUri.Text), fileName, fileName);
            }
            else
            {
                pictureBox.Image = null;
                errorProvider.SetError(txtUri, Resources.InvalidImageURI);
            }
        }

        private void FrmOpenOnlineImage_Shown(object sender, EventArgs e)
        {
            txtUri.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (pictureBox.Image == null)
            {
                errorProvider.SetError(txtUri, Resources.NoImage);
                DialogResult = DialogResult.None;
                return;
            }
            using (var ms = new MemoryStream())
            {
                pictureBox.Image.Save(ms, ImageFormat.Png);
                this.ImageBase64 = Convert.ToBase64String(ms.ToArray());
            }
        }
    }
}