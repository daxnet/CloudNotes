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
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using CloudNotes.DesktopClient.Controls;
    using CloudNotes.DesktopClient.Extensibility;
    using CloudNotes.DesktopClient.Properties;
    using CloudNotes.DesktopClient.Settings;

    public partial class FrmSettings : Form
    {
        private readonly SortedDictionary<string, string> SupportedLanguages = new SortedDictionary<string, string>()
        {
            {"en-US", Resources.EnglishUS},
            {"zh-CN", Resources.SimplifiedChinesePRC}
        };

        private readonly DesktopClientSettings settings;
        private readonly ExtensionManager extensionManager;
        private readonly Dictionary<Guid, IExtensionSetting> cachedSettings = new Dictionary<Guid, IExtensionSetting>();

        internal FrmSettings(DesktopClientSettings settings, ExtensionManager extensionManager)
        {
            InitializeComponent();
            this.settings = settings;
            this.extensionManager = extensionManager;
        }

        private void InitializeControls()
        {
            cbLanguage.DataSource = new BindingSource(SupportedLanguages, null);
            cbLanguage.DisplayMember = "Value";
            cbLanguage.ValueMember = "Key";
        }

        private void InitializeSettings()
        {
            cbLanguage.SelectedItem = SupportedLanguages.First(k => k.Key == settings.General.Language);
            chkShowExtensionInMenuGroup.Checked = this.settings.General.ShowUnderExtensionsMenu;
            chkOnlyShowWhenMoreThan.Checked = this.settings.General.OnlyShowForMaximumExtensionsLoaded;
            numMaxExtensionsLoaded.Value = this.settings.General.MaximumExtensionsLoadedValue;
            chkOnlyShowWhenMoreThan.Enabled = chkShowExtensionInMenuGroup.Checked;
            numMaxExtensionsLoaded.Enabled = chkShowExtensionInMenuGroup.Checked;
            lblOnlyShowWhenMoreThan.Enabled = chkShowExtensionInMenuGroup.Checked;
        }

        private void InitializeExtensions()
        {
            if (this.extensionManager.HasExtension)
            {
                splitContainer.Visible = true;
                lvExtensions.Groups.Clear();
                var grpToolExtension = lvExtensions.Groups.Add("grpToolExtension", Resources.ToolExtensionGroupName);
                var grpExportExtension = lvExtensions.Groups.Add("grpExportExtension",
                    Resources.ExportExtensionGroupName);

                lvExtensions.Items.Clear();
                ilExtensions.Images.Clear();
                ilExtensions.Images.Add("plugin.png", Resources.plugin);

                pnlSettings.Controls.Clear();
                // Create the Tool Extensions items.
                foreach (var kvp in extensionManager.AllExtensions)
                {
                    var extension = kvp.Value;
                    var lvi = new ListViewItem(extension.DisplayName.Trim('.'));
                    lvi.Tag = extension.ID;
                    if (extension.Kind == typeof (ToolExtension))
                    {
                        lvi.Group = grpToolExtension;
                        ilExtensions.Images.Add(extension.ID.ToString(), ((ToolExtension) extension).ToolIcon);
                        lvi.ImageKey = extension.ID.ToString();
                    }
                    else if (extension.Kind == typeof (ExportExtension))
                    {
                        lvi.Group = grpExportExtension;
                        lvi.ImageKey = "plugin.png";
                    }
                    lvExtensions.Items.Add(lvi);
                }
                lvExtensions.Sort();
                if (grpToolExtension.Items.Count > 0)
                {
                    grpToolExtension.Items[0].Selected = true;
                    this.BindExtension((Guid) grpToolExtension.Items[0].Tag);
                }
                else if (grpExportExtension.Items.Count > 0)
                {
                    grpExportExtension.Items[0].Selected = true;
                    this.BindExtension((Guid) grpExportExtension.Items[0].Tag);
                }
            }
            else
            {
                splitContainer.Visible = false;
                var noExtensionControl = new NoExtensionControl {Dock = DockStyle.Fill};
                this.tpExtensions.Controls.Add(noExtensionControl);
            }
        }

        private void BindExtension(Guid extensionId)
        {
            var extension = this.extensionManager.GetByKey(extensionId);
            pnlSettings.Controls.Clear();
            if (extension.SettingProvider == null)
            {
                var noSettingsControl = new NoSettingsControl();
                noSettingsControl.Dock = DockStyle.Fill;
                pnlSettings.Controls.Add(noSettingsControl);
            }
            else
            {
                pnlSettings.Controls.Add(extension.SettingProvider.SettingControl);
                if (cachedSettings.ContainsKey(extensionId))
                {
                    extension.SettingProvider.BindSetting(cachedSettings[extensionId]);
                }
                else
                {
                    extension.SettingProvider.BindSetting(extension.SettingProvider.ExtensionSetting);
                }
            }
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.InitializeSettings();
            this.InitializeExtensions();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Saves the extension settings
            foreach (var extension in this.extensionManager.AllExtensions)
            {
                var settingProvider = extension.Value.SettingProvider;
                if (settingProvider != null)
                {
                    settingProvider.PersistSettings();
                }
            }

            settings.General.Language = ((KeyValuePair<string, string>) cbLanguage.SelectedItem).Key;
            settings.General.ShowUnderExtensionsMenu = chkShowExtensionInMenuGroup.Checked;
            settings.General.OnlyShowForMaximumExtensionsLoaded = chkOnlyShowWhenMoreThan.Checked;
            settings.General.MaximumExtensionsLoadedValue = Convert.ToInt32(numMaxExtensionsLoaded.Value);
            DesktopClientSettings.WriteSettings(settings);
        }

        private void lvExtensions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvExtensions.SelectedItems.Count > 0)
            {
                var item = this.lvExtensions.SelectedItems[0];
                var extensionId = (Guid) item.Tag;
                this.BindExtension(extensionId);
            }
        }

        private void pnlSettings_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (e.Control.Tag != null)
            {
                var extension = e.Control.Tag as Extension;
                if (extension != null && extension.SettingProvider != null)
                {
                    var setting = extension.SettingProvider.CollectedSetting;
                    this.cachedSettings[extension.ID] = setting;
                }
            }
        }

        private void chkShowExtensionInMenuGroup_Click(object sender, EventArgs e)
        {
            chkOnlyShowWhenMoreThan.Enabled = chkShowExtensionInMenuGroup.Checked;
            numMaxExtensionsLoaded.Enabled = chkShowExtensionInMenuGroup.Checked;
            lblOnlyShowWhenMoreThan.Enabled = chkShowExtensionInMenuGroup.Checked;
        }
    }
}