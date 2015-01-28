using CloudNotes.DesktopClient.Extensibility;
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
            var html = new WebClient() { Encoding = Encoding.UTF8 }.DownloadString("http://www.cnblogs.com/daxnet/p/4208713.html");
            await shell.ImportNote(new Extensibility.Data.Note
                {
                    Title = Guid.NewGuid().ToString(),
                    Content = html
                });
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
