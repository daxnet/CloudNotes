using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CloudNotes.DesktopClient
{
    using CloudNotes.DesktopClient.Controls;
    using CloudNotes.DesktopClient.Extensibility;
    using CloudNotes.DesktopClient.Properties;
    using CloudNotes.DesktopClient.Settings;

    public partial class FrmSettings : Form
    {
        private readonly SortedDictionary<string, string> SupportedLanguages = new SortedDictionary<string, string>()
                                                                             {
                                                                                 {"en-US", Resources.EnglishUS },
                                                                                 {"zh-CN", Resources.SimplifiedChinesePRC }
                                                                             };

        private readonly DesktopClientSettings settings;
        private readonly ExtensionManager extensionManager;

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
            lvExtensions.Items.Clear();
            this.splitContainer.Panel2.Controls.Clear();
            foreach(var extension in extensionManager.AllExtensions)
            {
                var lvi = new ListViewItem(extension.Value.DisplayName);
                lvi.Tag = extension.Key;
                lvExtensions.Items.Add(lvi);
            }
            if (lvExtensions.Items.Count>0)
            {
                this.BindExtension((Guid)lvExtensions.Items[0].Tag);
            }
        }

        private void BindExtension(Guid extensionId)
        {
            var extension = this.extensionManager.GetByKey(extensionId);
            this.splitContainer.Panel2.Controls.Clear();
            if (extension.SettingProvider == null)
            {
                var noSettingsControl = new NoSettingsControl();
                noSettingsControl.Dock = DockStyle.Fill;
                this.splitContainer.Panel2.Controls.Add(noSettingsControl);
            }
            else
            {
                this.splitContainer.Panel2.Controls.Add(extension.SettingProvider.SettingControl);
                extension.SettingProvider.BindSettings();
            }
        }

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.InitializeSettings();
            this.InitializeExtensions();
        }

        private void cbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            settings.General.Language = ((KeyValuePair<string, string>)cbLanguage.SelectedItem).Key;
            DesktopClientSettings.WriteSettings(settings);
        }
    }
}
