using CloudNotes.DesktopClient.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudNotes.DesktopClient.Extensions
{
    public sealed class CustomSettingProvider : ExtensionSettingProvider
    {
        public CustomSettingProvider(Extension extension)
            : base(extension)
        { }

        protected override Type SettingControlType
        {
            get { return typeof(CustomSettingControl); }
        }

        protected override Type ExtensionSettingType
        {
            get { return typeof(CustomSetting); }
        }

        protected override void DoBindSettingsToControl(IExtensionSetting setting)
        {
            var localSetting = (CustomSetting)setting;
            
            this.GetSettingControl<CustomSettingControl>().txtGreeting.Text = localSetting.Greeting;
        }

        protected override IExtensionSetting DoCollectSettingsFromControl()
        {
            return new CustomSetting
            {
                Greeting = this.GetSettingControl<CustomSettingControl>().txtGreeting.Text
            };
        }

        protected override IExtensionSetting DefaultSetting
        {
            get { return new CustomSetting { Greeting = "Hello World" }; }
        }
    }
}
