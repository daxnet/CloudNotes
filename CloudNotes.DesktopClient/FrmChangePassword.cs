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

namespace CloudNotes.DesktopClient
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Windows.Forms;
    using CloudNotes.DesktopClient.Extensibility;
    using CloudNotes.DesktopClient.Properties;
    using CloudNotes.DESecurity;

    public partial class FrmChangePassword : Form
    {
        private readonly ClientCredential clientCredential;
        private string oldPassword;
        private string newPassword;

        public FrmChangePassword(ClientCredential credential)
        {
            InitializeComponent();
            this.clientCredential = credential;
        }

        private void FrmChangePassword_Shown(object sender, EventArgs e)
        {
            txtOldPassword.Text = string.Empty;
            txtNewPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
            txtOldPassword.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            var hasError = false;
            if (string.IsNullOrEmpty(txtOldPassword.Text))
            {
                errorProvider.SetError(txtOldPassword, Resources.OriginalPasswordRequired);
                hasError = true;
            }
            if (string.IsNullOrEmpty(txtNewPassword.Text))
            {
                errorProvider.SetError(txtNewPassword, Resources.NewPasswordRequired);
                hasError = true;
            }
            if (string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                errorProvider.SetError(txtConfirmPassword, Resources.ConfirmPasswordRequired);
                hasError = true;
            }
            if (string.Compare(txtNewPassword.Text, txtConfirmPassword.Text, StringComparison.InvariantCulture) != 0)
            {
                errorProvider.SetError(txtConfirmPassword, Resources.IncorrectConfirmPassword);
                hasError = true;
            }
            if (hasError)
            {
                this.DialogResult = DialogResult.None;
            }
            else
            {
                oldPassword = txtOldPassword.Text;
                newPassword = txtNewPassword.Text;

                var encodedOldPassword =
                    Convert.ToBase64String(
                        Encoding.ASCII.GetBytes(Crypto.ComputeHash(oldPassword, this.clientCredential.UserName)));
                var encodedNewPassword =
                    Convert.ToBase64String(
                        Encoding.ASCII.GetBytes(Crypto.ComputeHash(newPassword, this.clientCredential.UserName)));

                using (var proxy = new ServiceProxy(this.clientCredential))
                {
                    try
                    {
                        txtConfirmPassword.Enabled = false;
                        txtNewPassword.Enabled = false;
                        txtOldPassword.Enabled = false;
                        btnOK.Enabled = false;
                        var result =
                            proxy.PostAsJsonAsync(
                                "api/users/password/change",
                                new
                                {
                                    clientCredential.UserName,
                                    EncodedOldPassword = encodedOldPassword,
                                    EncodedNewPassword = encodedNewPassword
                                }).Result;
                        switch (result.StatusCode)
                        {
                            case HttpStatusCode.OK:
                                // Re-assign the new password to client credential
                                clientCredential.Password = newPassword;
                                MessageBox.Show(
                                    Resources.PasswordChangedSuccessfully,
                                    Resources.Information,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                                break;
                            case HttpStatusCode.Forbidden:
                                MessageBox.Show(
                                    Resources.IncorrectUserNamePassword,
                                    Resources.Error,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                                this.DialogResult = DialogResult.None;
                                return;
                            default:
                                var message = result.Content.ReadAsStringAsync().Result;
                                MessageBox.Show(
                                    message,
                                    Resources.Error,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                                this.DialogResult = DialogResult.None;
                                return;
                        }
                    }
                    catch (Exception ex)
                    {
                        FrmExceptionDialog.ShowException(ex);
                        this.DialogResult = DialogResult.None;
                    }
                    finally
                    {
                        txtConfirmPassword.Enabled = true;
                        txtNewPassword.Enabled = true;
                        txtOldPassword.Enabled = true;
                        btnOK.Enabled = true;
                    }
                }
            }
        }
    }
}