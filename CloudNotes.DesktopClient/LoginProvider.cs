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
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using CloudNotes.DesktopClient.Extensibility;
    using CloudNotes.DesktopClient.Profiles;
    using CloudNotes.DesktopClient.Settings;
    using CloudNotes.DESecurity;
    using CloudNotes.Infrastructure;

    public static class LoginProvider
    {
        public static ClientCredential Login(Action cancelCallback, DesktopClientSettings settings,
            bool alwaysShowDialog = false)
        {
            var crypto = Crypto.CreateDefaultCrypto();
            Profile profile;
            var profileFile = Directories.GetFullName(Constants.ProfileFileName);
            var profileDirectory = Path.GetDirectoryName(profileFile);
            if (string.IsNullOrEmpty(profileDirectory))
                throw new InvalidOperationException("The directory name is invalid (empty).");
            if (!Directory.Exists(profileDirectory))
            {
                Directory.CreateDirectory(profileDirectory);
                profile = new Profile();
            }
            else
            {
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