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

namespace CloudNotes.DesktopClient.Settings
{
    using System;
    using System.Configuration;
    using System.IO;
    using System.Threading;
    using CloudNotes.DesktopClient.Extensibility;
    using CloudNotes.Infrastructure;
    using Newtonsoft.Json;

    public class DesktopClientSettings
    {
        private static readonly string SettingsFile = Directories.GetFullName(Constants.DesktopClientSettingsFile);

        private static readonly DesktopClientSettings Default;

        static DesktopClientSettings()
        {
            Default = new DesktopClientSettings();
            Default.General = new GeneralSettings();
            Default.General.Language = Thread.CurrentThread.CurrentUICulture.Name;
            Default.General.ShowUnderExtensionsMenu = false;
            Default.General.OnlyShowForMaximumExtensionsLoaded = false;
            Default.General.MaximumExtensionsLoadedValue = 0;
            Default.Composing = new ComposingSettings();
            Default.Composing.DefaultStyleId = Guid.Empty;
            Default.PackageServer = ConfigurationManager.AppSettings[Constants.PackageServerSettingKey];
        }

        private GeneralSettings general;

        public GeneralSettings General
        {
            get
            {
                if (general != null)
                {
                    return general;
                }
                return Default.General;
            }
            set { general = value; }
        }

        private ComposingSettings composing;

        public ComposingSettings Composing
        {
            get
            {
                if (composing != null)
                {
                    return composing;
                }
                return Default.Composing;
            }
            set { composing = value; }
        }

        private string packageServer;

        public string PackageServer
        {
            get
            {
                if (!string.IsNullOrEmpty(this.packageServer))
                {
                    return this.packageServer;
                }
                return Default.PackageServer;
            }
            set { packageServer = value; }
        }

        public static DesktopClientSettings ReadSettings()
        {
            if (File.Exists(SettingsFile))
            {
                var json = File.ReadAllText(SettingsFile);
                return JsonConvert.DeserializeObject<DesktopClientSettings>(json);
            }
            return Default;
        }

        public static void WriteSettings(DesktopClientSettings settings)
        {
            var json = JsonConvert.SerializeObject(settings);
            File.WriteAllText(SettingsFile, json);
        }
    }
}