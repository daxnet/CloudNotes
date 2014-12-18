using CloudNotes.DesktopClient.Properties;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

using CloudNotes.DESecurity;
using CloudNotes.Infrastructure;

namespace CloudNotes.DesktopClient
{
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
            if (string.Compare(txtNewPassword.Text, txtConfirmPassword.Text, StringComparison.InvariantCulture)!=0)
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

                var encodedOldPassword = Convert.ToBase64String(Encoding.ASCII.GetBytes(Crypto.ComputeHash(oldPassword, this.clientCredential.UserName)));
                var encodedNewPassword = Convert.ToBase64String(Encoding.ASCII.GetBytes(Crypto.ComputeHash(newPassword, this.clientCredential.UserName)));

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
