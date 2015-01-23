

namespace CloudNotes.DesktopClient
{
    using CloudNotes.DesktopClient.Controls;
    using CloudNotes.DesktopClient.Extensibility;
    using CloudNotes.DesktopClient.Properties;
    using CloudNotes.DesktopClient.Settings;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    public partial class FrmSettings : Form
    {
        private readonly SortedDictionary<string, string> SupportedLanguages = new SortedDictionary<string, string>()
                                                                             {
                                                                                 {"en-US", Resources.EnglishUS },
                                                                                 {"zh-CN", Resources.SimplifiedChinesePRC }
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
        }

        private void InitializeExtensions()
        {
            lvExtensions.Groups.Clear();
            var grpToolExtension = lvExtensions.Groups.Add("grpToolExtension", Resources.ToolsExtensionGroupName);

            lvExtensions.Items.Clear();
            ilExtensions.Images.Clear();
            pnlSettings.Controls.Clear();
            // Create the Tool Extensions items.
            foreach(var extension in extensionManager.ToolExtensions)
            {
                var lvi = new ListViewItem(extension.DisplayName.Trim('.'));
                lvi.Group = grpToolExtension;
                lvi.Tag = extension.ID;
                ilExtensions.Images.Add(extension.ID.ToString(), extension.ToolIcon);
                lvi.ImageKey = extension.ID.ToString();
                lvExtensions.Items.Add(lvi);
            }
            if (lvExtensions.Items.Count > 0)
            {
                lvExtensions.Items[0].Selected = true;
                this.BindExtension((Guid)this.lvExtensions.Items[0].Tag);
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

            settings.General.Language = ((KeyValuePair<string, string>)cbLanguage.SelectedItem).Key;
            DesktopClientSettings.WriteSettings(settings);
        }

        private void lvExtensions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvExtensions.SelectedItems.Count > 0)
            {
                var item = this.lvExtensions.SelectedItems[0];
                var extensionId = (Guid)item.Tag;
                this.BindExtension(extensionId);
            }
        }

        private void pnlSettings_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (e.Control.Tag != null)
            {
                var extension = e.Control.Tag as Extension;
                if (extension!=null && extension.SettingProvider!=null)
                {
                    var setting = extension.SettingProvider.CollectedSetting;
                    this.cachedSettings[extension.ID] = setting;
                }
            }
        }
    }
}
