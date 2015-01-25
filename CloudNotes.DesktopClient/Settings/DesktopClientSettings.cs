
namespace CloudNotes.DesktopClient.Settings
{
    using System.Threading;

    using Newtonsoft.Json;
    using System.IO;
    using System.Windows.Forms;
    using System.Configuration;
    using CloudNotes.Infrastructure;
    using CloudNotes.DesktopClient.Extensibility;

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
            Default.PackageServer = ConfigurationManager.AppSettings[Constants.PackageServerSettingKey];
        }

        private GeneralSettings general;
        public GeneralSettings General
        {
            get
            {
                if (general != null)
                    return general;
                return Default.General;
            }
            set
            {
                general = value;
            }
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
            set
            {
                packageServer = value;
            }
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
