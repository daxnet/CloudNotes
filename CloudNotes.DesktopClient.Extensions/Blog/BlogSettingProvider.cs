using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudNotes.DesktopClient.Extensions.Blog
{
    using CloudNotes.DesktopClient.Extensibility.Extensions;

    public sealed class BlogSettingProvider : ExtensionSettingProvider
    {
        public BlogSettingProvider(Extension extension)
            : base(extension)
        {
        }

        protected override Type SettingControlType
        {
            get { return typeof(BlogSettingControl); }
        }

        protected override Type ExtensionSettingType
        {
            get { return typeof(BlogSetting); }
        }

        protected override IExtensionSetting DefaultSetting
        {
            get { return BlogSetting.Default; }
        }

        protected override void DoBindSettingsToControl(IExtensionSetting setting)
        {
            var ctrl = this.GetSettingControl<BlogSettingControl>();
            var thisSetting = (BlogSetting) setting;
            ctrl.txtMetaWeblogAddress.Text = thisSetting.MetaWeblogAddress;
            ctrl.txtUserName.Text = thisSetting.UserName;
            ctrl.txtPassword.Text = thisSetting.Password;
        }

        protected override IExtensionSetting DoCollectSettingsFromControl()
        {
            var ctrl = this.GetSettingControl<BlogSettingControl>();
            return new BlogSetting
            {
                MetaWeblogAddress = ctrl.txtMetaWeblogAddress.Text,
                UserName = ctrl.txtUserName.Text,
                Password = ctrl.txtPassword.Text
            };
        }

        
    }
}
