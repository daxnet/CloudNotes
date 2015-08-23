using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudNotes.DesktopClient.Extensions.InsertSourceCode
{
    using CloudNotes.DesktopClient.Extensibility.Extensions;

    public sealed class InsertSourceCodeSettingProvider : ExtensionSettingProvider
    {
        public InsertSourceCodeSettingProvider(Extension extension)
            : base(extension)
        {
        }

        protected override Type SettingControlType
        {
            get { return typeof(InsertSourceCodeSettingControl); }
        }

        protected override Type ExtensionSettingType
        {
            get { return typeof(InsertSourceCodeSetting); }
        }

        protected override IExtensionSetting DefaultSetting
        {
            get { return InsertSourceCodeSetting.Default; }
        }

        protected override void DoBindSettingsToControl(IExtensionSetting setting)
        {
            var thisSetting = (InsertSourceCodeSetting) setting;
            var thisSettingControl = this.GetSettingControl<InsertSourceCodeSettingControl>();
            thisSettingControl.chkAutoLinks.Checked = thisSetting.AutoLinks;
            thisSettingControl.chkCollapse.Checked = thisSetting.Collapse;
            thisSettingControl.chkGutter.Checked = thisSetting.Gutter;
            thisSettingControl.chkSmartTabs.Checked = thisSetting.SmartTabs;
            thisSettingControl.numTabSize.Value = thisSetting.TabSize;
            thisSettingControl.chkShowToolbar.Checked = thisSetting.ShowToolbar;
        }

        protected override IExtensionSetting DoCollectSettingsFromControl()
        {
            var thisSettingControl = this.GetSettingControl<InsertSourceCodeSettingControl>();
            return new InsertSourceCodeSetting
            {
                AutoLinks = thisSettingControl.chkAutoLinks.Checked,
                Collapse = thisSettingControl.chkCollapse.Checked,
                Gutter = thisSettingControl.chkGutter.Checked,
                SmartTabs = thisSettingControl.chkSmartTabs.Checked,
                TabSize = Convert.ToInt32(thisSettingControl.numTabSize.Value),
                ShowToolbar = thisSettingControl.chkShowToolbar.Checked
            };
        }

        
    }
}
