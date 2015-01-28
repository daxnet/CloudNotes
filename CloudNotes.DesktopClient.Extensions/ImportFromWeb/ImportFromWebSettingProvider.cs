using CloudNotes.DesktopClient.Extensibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudNotes.DesktopClient.Extensions.ImportFromWeb
{
    public class ImportFromWebSettingProvider : ExtensionSettingProvider
    {
        public ImportFromWebSettingProvider(Extension extension)
            : base(extension)
        { }

        protected override Type SettingControlType
        {
            get { return typeof(ImportFromWebSettingControl); }
        }

        protected override Type ExtensionSettingType
        {
            get { return typeof(ImportFromWebSetting); }
        }

        protected override IExtensionSetting DefaultSetting
        {
            get { return new ImportFromWebSetting { EncodingCodePage = Encoding.UTF8.CodePage, EmbedImages = true }; }
        }

        protected override void DoBindSettingsToControl(IExtensionSetting setting)
        {
            var encodingInforArray = Encoding.GetEncodings().OrderBy(p => p.DisplayName).ToList();

            var thisSetting = (ImportFromWebSetting)setting;
            var thisSettingControl = this.GetSettingControl<ImportFromWebSettingControl>();
            thisSettingControl.chkEmbedImages.Checked = thisSetting.EmbedImages;
            thisSettingControl.cbEncoding.SelectedItem = encodingInforArray.First(enc => enc.CodePage == thisSetting.EncodingCodePage);
        }

        protected override IExtensionSetting DoCollectSettingsFromControl()
        {
            var thisSettingControl = this.GetSettingControl<ImportFromWebSettingControl>();
            var codePage = ((EncodingInfo)thisSettingControl.cbEncoding.SelectedItem).CodePage;
            return new ImportFromWebSetting { EncodingCodePage = codePage, EmbedImages = thisSettingControl.chkEmbedImages.Checked };
        }
    }
}
