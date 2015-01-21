using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudNotes.DesktopClient.Extensibility
{
    public abstract class ExtensionSettingProvider
    {
        private readonly Extension extension;
        private UserControl settingControl;

        public ExtensionSettingProvider(Extension extension)
        {
            this.extension = extension;
        }

        protected abstract Type SettingControlType { get; }

        protected abstract Type ExtensionSettingType { get; }

        protected abstract IExtensionSetting DefaultSetting { get; }

        protected abstract void DoBindSettings(IExtensionSetting setting);

        public IExtensionSetting ReadSetting()
        {
            var setting = Extension.ReadSetting(this.extension, this.ExtensionSettingType);
            if (setting == null)
                setting = this.DefaultSetting;
            return setting;
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
                    settingControl.Dock = DockStyle.Fill;
                    return settingControl;

                }
                return settingControl;
            }
        }

        public void BindSettings()
        {
            this.DoBindSettings(this.ReadSetting());
        }
    }
}
