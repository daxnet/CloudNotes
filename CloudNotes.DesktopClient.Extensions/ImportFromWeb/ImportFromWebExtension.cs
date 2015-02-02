using CloudNotes.DesktopClient.Extensibility;
using CloudNotes.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CloudNotes.DesktopClient.Extensions.ImportFromWeb
{
    [Extension("D3C4C8BB-38E0-4EEE-9263-C83F3F4C39E0", "ImportFromWeb", typeof(ImportFromWebSettingProvider))]
    public sealed class ImportFromWebExtension : ToolExtension
    {
        public ImportFromWebExtension()
            : base("Import From Web...")
        { }

        protected async override void DoExecute(IShell shell)
        {
            var setting = this.SettingProvider.GetExtensionSetting<ImportFromWebSetting>();
            var dialog = new ImportFromWebDialog();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var webClient = new WebClient();
                webClient.Encoding = Encoding.GetEncoding(setting.EncodingCodePage);
                var html = await webClient.DownloadStringTaskAsync(dialog.Url);
                await shell.ImportNote(new Extensibility.Data.Note
                    {
                        Title = Guid.NewGuid().ToString(),
                        Content = html
                    });
            }
        }

        public override string Manufacture
        {
            get
            {
                return "daxnet";
            }
        }

        public override string Description
        {
            get
            {
                return "Imports the web page as a note.";
            }
        }
    }
}
