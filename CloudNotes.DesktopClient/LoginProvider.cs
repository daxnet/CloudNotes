using CloudNotes.DesktopClient.Profiles;
using CloudNotes.DesktopClient.Settings;
using CloudNotes.Infrastructure;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using CloudNotes.DESecurity;

namespace CloudNotes.DesktopClient
{
    public static class LoginProvider
    {
        public static ClientCredential Login(Action cancelCallback, DesktopClientSettings settings, bool alwaysShowDialog = false)
        {
            var crypto = Crypto.CreateDefaultCrypto();
            Profile profile;
            var profileFile = Directories.GetFullName(Constants.ProfileFileName);
            if (File.Exists(profileFile))
            {
                try
                {
                    profile = Profile.Load(profileFile);
                }
                catch
                {
                    profile = new Profile();
                }
            }
            else
            {
                profile = new Profile();
            }
            ClientCredential credential = null;
            var selectedUserProfile = profile.UserProfiles.FirstOrDefault(p => p.IsSelected);
            var selectedServerProfile = profile.ServerProfiles.FirstOrDefault(p => p.IsSelected);
            if (alwaysShowDialog || selectedUserProfile == null || !selectedUserProfile.AutoLogin)
            {
                var loginForm = new FrmLogin(profile, settings, profileFile);
                var dialogResult = loginForm.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    credential = loginForm.Credential;
                }
                else
                {
                    cancelCallback();
                }
            }
            else
            {
                credential = new ClientCredential
                {
                    Password = crypto.Decrypt(selectedUserProfile.Password),
                    ServerUri = selectedServerProfile == null ? string.Empty : selectedServerProfile.Uri,
                    UserName = selectedUserProfile.UserName
                };
            }
            return credential;
        }
    }
}
