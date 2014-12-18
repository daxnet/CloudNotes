using System.Threading.Tasks;

using CloudNotes.DesktopClient.Profiles;
using CloudNotes.DesktopClient.Properties;
using CloudNotes.DesktopClient.Settings;
using CloudNotes.Infrastructure;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

using Newtonsoft.Json;
using CloudNotes.DESecurity;

namespace CloudNotes.DesktopClient
{
    public partial class FrmLogin : Form
    {
        private readonly Profile profile;

        private readonly string fileName;

        private readonly DesktopClientSettings settings;

        private ClientCredential credential;

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

        public ClientCredential Credential
        {
            get
            {
                return credential;
            }
        }

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
                    if (selectedUserProfile != null) selectedUserProfile.IsSelected = true;
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
            errorProvider.Clear();
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

            credential = new ClientCredential
            {
                Password = txtPassword.Text,
                ServerUri = cbServer.Text.Trim(),
                UserName = cbUserName.Text.Trim()
            };

            // reset the IsSelected property for users
            profile.UserProfiles.ForEach(up => up.IsSelected = false);
            var userProfile = profile.UserProfiles.FirstOrDefault(p => p.UserName == credential.UserName);
            var encryptedPassword = crypto.Encrypt(credential.Password);
            if (userProfile==null)
            {
                userProfile = new UserProfile
                                  {
                                      AutoLogin = chkAutomaticLogin.Checked,
                                      IsSelected = true,
                                      Password = encryptedPassword,
                                      RememberPassword = chkRememberPassword.Checked,
                                      UserName = credential.UserName
                                  };
                profile.UserProfiles.Add(userProfile);
            }
            else
            {
                userProfile.AutoLogin = chkAutomaticLogin.Checked;
                userProfile.IsSelected = true;
                userProfile.Password = encryptedPassword;
                userProfile.RememberPassword = chkRememberPassword.Checked;
                userProfile.UserName = credential.UserName;
            }
            // reset the IsSelected property for servers
            profile.ServerProfiles.ForEach(sp => sp.IsSelected = false);
            var serverProfile = profile.ServerProfiles.FirstOrDefault(p => p.Uri == credential.ServerUri);
            if (serverProfile == null)
            {
                serverProfile = new ServerProfile(credential.ServerUri) { IsSelected = true };
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
                using (var proxy = new ServiceProxy(credential))
                {
                    var result =
                        proxy.PostAsJsonAsync(
                            "api/users/authenticate",
                            new
                                {
                                    credential.UserName,
                                    EncodedPassword = Convert.ToBase64String(Encoding.ASCII.GetBytes(Crypto.ComputeHash(credential.Password, credential.UserName)))
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
            var registerForm = new FrmRegister();
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
