

namespace CloudNotes.DesktopClient.Extensibility
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public abstract class ExtensionSettingProvider
    {
        private readonly Extension extension;
        private UserControl settingControl;

        public ExtensionSettingProvider(Extension extension)
        {
            this.extension = extension;
        }

        private static string GetExtensionSettingFileName(Extension extension)
        {
            var extensionSettingsFolder = Path.Combine("Extensions", "Settings");
            var relativeFileName = Path.Combine(extensionSettingsFolder, string.Format("extension.{0}.{1}.setting.json", extension.Name, extension.ID.ToString().Replace('-', '_').ToUpper()));
            var fullName = Directories.GetFullName(relativeFileName);
            var directoryName = Path.GetDirectoryName(fullName);
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }
            return fullName;
        }

        private static T ReadSetting<T>(Extension extension)
            where T : class, IExtensionSetting
        {
            var settingFile = GetExtensionSettingFileName(extension);
            if (!File.Exists(settingFile))
            {
                return null;
            }
            var settingJson = File.ReadAllText(settingFile);
            return JsonConvert.DeserializeObject<T>(settingJson);
        }

        private static void WriteSetting<T>(Extension extension, T setting)
            where T : class, IExtensionSetting
        {
            var settingFile = GetExtensionSettingFileName(extension);
            var settingJson = JsonConvert.SerializeObject(setting);
            File.WriteAllText(settingFile, settingJson);
        }

        private static IExtensionSetting ReadSetting(Extension extension, Type type)
        {
            if (!typeof(IExtensionSetting).IsAssignableFrom(type))
                throw new InvalidOperationException();

            var settingFile = GetExtensionSettingFileName(extension);
            if (!File.Exists(settingFile))
            {
                return null;
            }
            var settingJson = File.ReadAllText(settingFile);
            return (IExtensionSetting)JsonConvert.DeserializeObject(settingJson, type);
        }

        private static void WriteSetting(Extension extension, object setting)
        {
            var settingFile = GetExtensionSettingFileName(extension);
            var settingJson = JsonConvert.SerializeObject(setting);
            File.WriteAllText(settingFile, settingJson);
        }

        protected abstract Type SettingControlType { get; }

        protected abstract Type ExtensionSettingType { get; }

        protected abstract IExtensionSetting DefaultSetting { get; }

        protected abstract void DoBindSettingsToControl(IExtensionSetting setting);

        protected abstract IExtensionSetting DoCollectSettingsFromControl();

        public IExtensionSetting Setting
        {
            get
            {
                var setting = ReadSetting(this.extension, this.ExtensionSettingType);
                if (setting == null)
                    setting = this.DefaultSetting;
                return setting;
            }
        }

        public UserControl SettingControl
        {
            get
            {
                if (settingControl == null)
                {
                    if (this.SettingControlType == null)
                        throw new InvalidOperationException();
                    if (!this.SettingControlType.IsSubclassOf(typeof(UserControl)))
                        throw new InvalidOperationException();

                    settingControl = (UserControl)Activator.CreateInstance(this.SettingControlType);
                    settingControl.Tag = this.extension;
                    settingControl.Dock = DockStyle.Fill;
                    return settingControl;

                }
                return settingControl;
            }
        }

        public void BindSetting()
        {
            this.DoBindSettingsToControl(this.Setting);
        }

        public void SaveSettings()
        {
            var setting = this.DoCollectSettingsFromControl();
            WriteSetting(this.extension, setting);
        }
    }
}
