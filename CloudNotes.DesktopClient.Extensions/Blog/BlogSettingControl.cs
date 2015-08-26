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
            bool hasError = false;
            errorProvider.Clear();
            if (string.IsNullOrEmpty(txtMetaWeblogAddress.Text))
            {
                errorProvider.SetError(txtMetaWeblogAddress, "Please input the MetaWeblog address.");
                hasError = true;
            }
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                errorProvider.SetError(txtUserName, "Please input the user name.");
                hasError = true;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                errorProvider.SetError(txtPassword, "Please input the password.");
                hasError = true;
            }
            if (hasError)
            {
                return;
            }

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
