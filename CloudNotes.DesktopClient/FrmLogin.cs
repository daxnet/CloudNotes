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
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Windows.Forms;
    using CloudNotes.DesktopClient.Extensibility;
    using CloudNotes.DesktopClient.Profiles;
    using CloudNotes.DesktopClient.Properties;
    using CloudNotes.DesktopClient.Settings;
    using CloudNotes.DESecurity;
    using Newtonsoft.Json;

    internal sealed partial class FrmLogin : Form
    {
        private readonly Profile profile;

        private readonly string fileName;

        private readonly DesktopClientSettings settings;

        private readonly Crypto crypto = Crypto.CreateDefaultCrypto();

        private dynamic availablePackage;

        public FrmLogin()
        {
            InitializeComponent();
        }

        public FrmLogin(Profile profile, DesktopClientSettings settings, string fileName)
            : this()
        {
            this.profile = profile;
            this.fileName = fileName;
            this.settings = settings;
        }

        public ClientCredential Credential { get; private set; }

        private void BindUserProfile(UserProfile userProfile)
        {
            if (userProfile != null)
            {
                var decryptedPassword = crypto.Decrypt(userProfile.Password);
                this.txtPassword.Text = userProfile.RememberPassword ? decryptedPassword : string.Empty;
                this.chkRememberPassword.Checked = userProfile.RememberPassword;
                this.chkAutomaticLogin.Checked = userProfile.AutoLogin;
            }
            else
            {
                this.txtPassword.Text = string.Empty;
                this.chkRememberPassword.Checked = false;
                this.chkAutomaticLogin.Checked = false;
            }
        }

        private void Action_DeleteUserProfile(object sender, EventArgs e)
        {
            var userName = cbUserName.Text;
            if (!string.IsNullOrEmpty(userName))
            {
                var delUserProfile = profile.UserProfiles.FirstOrDefault(up => up.UserName == userName);
                if (delUserProfile != null)
                {
                    profile.UserProfiles.Remove(delUserProfile);
                    var selectedUserProfile = profile.UserProfiles.FirstOrDefault();
                    if (selectedUserProfile != null)
                    {
                        selectedUserProfile.IsSelected = true;
                    }
                    Profile.Save(fileName, profile);
                    this.RefreshUserProfileList();
                }
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.RefreshUserProfileList();

            this.RefreshServerProfileList();
        }

        private void RefreshServerProfileList()
        {
            this.cbServer.Items.Clear();
            var selectedServerProfile = this.profile.ServerProfiles.FirstOrDefault(p => p.IsSelected);
            // add server list
            foreach (var serverProfile in this.profile.ServerProfiles)
            {
                this.cbServer.Items.Add(serverProfile);
            }

            this.cbServer.SelectedItem = selectedServerProfile;
        }

        private void RefreshUserProfileList()
        {
            this.cbUserName.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
            this.chkRememberPassword.Checked = false;
            this.chkAutomaticLogin.Checked = false;
            this.cbUserName.Items.Clear();
            var selectedUserProfile = this.profile.UserProfiles.FirstOrDefault(p => p.IsSelected);
            // add user list
            foreach (var userProfile in this.profile.UserProfiles)
            {
                this.cbUserName.Items.Add(userProfile);
            }
            this.cbUserName.SelectedItem = selectedUserProfile;
            if (selectedUserProfile != null)
            {
                if (selectedUserProfile.RememberPassword)
                {
                    this.txtPassword.Text = this.crypto.Decrypt(selectedUserProfile.Password);
                }
                this.chkRememberPassword.Checked = selectedUserProfile.RememberPassword;
                this.chkAutomaticLogin.Checked = selectedUserProfile.AutoLogin;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var hasError = false;
            this.errorProvider.Clear();
            if (string.IsNullOrWhiteSpace(cbUserName.Text))
            {
                hasError = true;
                errorProvider.SetError(cbUserName, Resources.UserNameRequired);
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                hasError = true;
                errorProvider.SetError(txtPassword, Resources.PasswordRequired);
            }
            if (string.IsNullOrWhiteSpace(cbServer.Text))
            {
                hasError = true;
                errorProvider.SetError(cbServer, Resources.ServerRequired);
            }
            if (hasError)
            {
                // prevent the dialog from closing
                this.DialogResult = DialogResult.None;
                return;
            }

            Credential = new ClientCredential
            {
                Password = txtPassword.Text,
                ServerUri = cbServer.Text.Trim(),
                UserName = cbUserName.Text.Trim()
            };

            // reset the IsSelected property for users
            profile.UserProfiles.ForEach(up => up.IsSelected = false);
            var userProfile = profile.UserProfiles.FirstOrDefault(p => p.UserName == Credential.UserName);
            var encryptedPassword = crypto.Encrypt(Credential.Password);
            if (userProfile == null)
            {
                userProfile = new UserProfile
                {
                    AutoLogin = chkAutomaticLogin.Checked,
                    IsSelected = true,
                    Password = encryptedPassword,
                    RememberPassword = chkRememberPassword.Checked,
                    UserName = Credential.UserName
                };
                profile.UserProfiles.Add(userProfile);
            }
            else
            {
                userProfile.AutoLogin = chkAutomaticLogin.Checked;
                userProfile.IsSelected = true;
                userProfile.Password = encryptedPassword;
                userProfile.RememberPassword = chkRememberPassword.Checked;
                userProfile.UserName = Credential.UserName;
            }
            // reset the IsSelected property for servers
            profile.ServerProfiles.ForEach(sp => sp.IsSelected = false);
            var serverProfile = profile.ServerProfiles.FirstOrDefault(p => p.Uri == Credential.ServerUri);
            if (serverProfile == null)
            {
                serverProfile = new ServerProfile(Credential.ServerUri) {IsSelected = true};
                profile.ServerProfiles.Add(serverProfile);
            }
            else
            {
                serverProfile.IsSelected = true;
                serverProfile.Uri = cbServer.Text;
            }

            try
            {
                cbUserName.Enabled = false;
                txtPassword.Enabled = false;
                cbServer.Enabled = false;
                btnOK.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                using (var proxy = new ServiceProxy(Credential))
                {
                    var result =
                        proxy.PostAsJsonAsync(
                            "api/users/authenticate",
                            new
                            {
                                Credential.UserName,
                                EncodedPassword =
                                    Convert.ToBase64String(
                                        Encoding.ASCII.GetBytes(Crypto.ComputeHash(Credential.Password,
                                            Credential.UserName)))
                            }).Result;
                    switch (result.StatusCode)
                    {
                        case HttpStatusCode.OK:
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
                            dynamic message = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result);
                            MessageBox.Show(
                                message.ExceptionMessage.ToString(),
                                Resources.Error,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                            this.DialogResult = DialogResult.None;
                            return;
                    }
                }

                Profile.Save(fileName, profile);
            }
            catch (Exception ex)
            {
                FrmExceptionDialog.ShowException(ex);
                this.DialogResult = DialogResult.None;
            }
            finally
            {
                cbUserName.Enabled = true;
                txtPassword.Enabled = true;
                cbServer.Enabled = true;
                btnOK.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        private void cbUserName_TextUpdate(object sender, EventArgs e)
        {
            var userProfile = profile.UserProfiles.FirstOrDefault(u => u.UserName == cbUserName.Text.Trim());
            this.BindUserProfile(userProfile);
        }

        private void cbUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var userProfile = cbUserName.SelectedItem as UserProfile;
            this.BindUserProfile(userProfile);
        }

        private void btnRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var registerForm = new FrmRegister(this.cbServer.Text);
            if (registerForm.ShowDialog() == DialogResult.OK)
            {
                this.cbUserName.Text = registerForm.UserName;
                this.txtPassword.Text = string.Empty;
                this.cbServer.Text = registerForm.ServerUri;
                this.chkAutomaticLogin.Checked = false;
                this.chkRememberPassword.Checked = false;
                this.txtPassword.Focus();
            }
        }

        private async void FrmLogin_Shown(object sender, EventArgs e)
        {
            var desktopClientService = new DesktopClientService(this.settings);
            var checkUpdateResult = await desktopClientService.CheckUpdateAsync();
            lblNewVersionNotify.Visible = checkUpdateResult.HasUpdate;
            this.availablePackage = checkUpdateResult.UpdatePackage;
        }

        private void lblNewVersionNotify_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var updatePackageForm = new FrmUpdatePackage(this.availablePackage);
            updatePackageForm.ShowDialog();
        }
    }
}