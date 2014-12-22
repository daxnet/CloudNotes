using System;
using System.Text;
using System.Windows.Forms;

using CloudNotes.DESecurity;

namespace CloudNotes.DesktopClient
{
    using CloudNotes.DesktopClient.Properties;
    using CloudNotes.Infrastructure;
    using Newtonsoft.Json;
    using System.Net.Http;
    using System.Text.RegularExpressions;

    public partial class FrmRegister : Form
    {
        private readonly string defaultServerUri;
        public FrmRegister(string defaultServerUri)
        {
            InitializeComponent();
            this.defaultServerUri = defaultServerUri;
        }

        internal string UserName { get; private set; }
        internal string Password { get; private set; }
        internal string ServerUri { get; private set; }

        private void FrmRegister_Load(object sender, EventArgs e)
        {
            txtUserName.Focus();
            if (!string.IsNullOrEmpty(this.defaultServerUri))
            {
                txtServer.Text = this.defaultServerUri;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            this.DialogResult = DialogResult.OK;
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                errorProvider.SetError(txtUserName, Resources.UserNameRequired);
                txtUserName.Focus();
                this.DialogResult = DialogResult.None;
                return;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                errorProvider.SetError(txtPassword, Resources.PasswordRequired);
                txtPassword.Focus();
                this.DialogResult = DialogResult.None;
                return;
            }
            if (string.IsNullOrEmpty(txtConfirm.Text))
            {
                errorProvider.SetError(txtConfirm, Resources.ConfirmPasswordRequired);
                txtConfirm.Focus();
                this.DialogResult = DialogResult.None;
                return;
            }
            if (string.Compare(txtPassword.Text, txtConfirm.Text, StringComparison.InvariantCultureIgnoreCase) != 0)
            {
                errorProvider.SetError(txtConfirm, Resources.IncorrectConfirmPassword);
                txtConfirm.Focus();
                this.DialogResult = DialogResult.None;
                return;
            }
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, Resources.EmailRequired);
                txtEmail.Focus();
                this.DialogResult = DialogResult.None;
                return;
            }
            var regex = new Regex(Constants.EmailAddressFormatPattern);
            if (!regex.IsMatch(txtEmail.Text))
            {
                errorProvider.SetError(txtEmail, Resources.InvalidEmailAddress);
                txtEmail.Focus();
                this.DialogResult = DialogResult.None;
                return;
            }
            if (string.IsNullOrEmpty(txtServer.Text))
            {
                errorProvider.SetError(txtServer, Resources.ServerRequired);
                txtServer.Focus();
                this.DialogResult = DialogResult.None;
                return;
            }
            try
            {
                txtUserName.Enabled = false;
                txtPassword.Enabled = false;
                txtConfirm.Enabled = false;
                txtEmail.Enabled = false;
                txtServer.Enabled = false;
                btnOK.Enabled = false;
                using (
                    var proxy =
                        new ServiceProxy(
                            new ClientCredential
                            {
                                UserName = Constants.ProxyUserName,
                                Password = Constants.ProxyUserPassword,
                                ServerUri = txtServer.Text.Trim()
                            }))
                {
                    var result =
                        proxy.PutAsJsonAsync(
                            "api/users/create",
                            new
                                {
                                    UserName = txtUserName.Text.Trim(),
                                    Password =
                                        Convert.ToBase64String(
                                            Encoding.ASCII.GetBytes(
                                                Crypto.ComputeHash(txtPassword.Text.Trim(), txtUserName.Text.Trim()))),
                                    Email = txtEmail.Text.Trim()
                                }).Result;
                    // Here we cannot use the async/await feature, since
                    // the dialog will be closed even if we set the DialogResult to None.
                    if (result.IsSuccessStatusCode)
                    {
                        this.UserName = txtUserName.Text.Trim();
                        this.Password = txtPassword.Text.Trim();
                        this.ServerUri = txtServer.Text.Trim();
                        MessageBox.Show(
                            Resources.CreateAccountSuccessful,
                            this.Text,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        dynamic details = JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result);
                        if (details != null)
                        {
                            MessageBox.Show(
                                details.ExceptionMessage.ToString(),
                                Resources.Error,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Register failed!", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        this.DialogResult = DialogResult.None;
                    }
                }

            }
            catch (Exception ex)
            {
                FrmExceptionDialog.ShowException(ex);
                this.DialogResult = DialogResult.None;
            }
            finally
            {
                txtUserName.Enabled = true;
                txtPassword.Enabled = true;
                txtConfirm.Enabled = true;
                txtEmail.Enabled = true;
                txtServer.Enabled = true;
                btnOK.Enabled = true;
            }
        }
    }
}
