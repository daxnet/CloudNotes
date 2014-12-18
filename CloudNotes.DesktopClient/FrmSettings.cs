using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CloudNotes.DesktopClient
{
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

        public FrmSettings(DesktopClientSettings settings)
        {
            InitializeComponent();
            this.settings = settings;
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

        private void FrmSettings_Load(object sender, EventArgs e)
        {
            this.InitializeControls();
            this.InitializeSettings();
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
