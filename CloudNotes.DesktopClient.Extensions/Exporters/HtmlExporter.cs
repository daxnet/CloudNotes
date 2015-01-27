using CloudNotes.DesktopClient.Extensibility;
using CloudNotes.DesktopClient.Extensibility.Data;
using CloudNotes.DesktopClient.Extensions.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudNotes.DesktopClient.Extensions.Exporters
{
    [Extension("62E24485-80EF-4D03-9DE7-8140071AE7B3", "HtmlExporter")]
    public sealed class HtmlExporter : ExportExtension
    {
        protected override void DoExport(string fileName, Note note, object options)
        {
            File.WriteAllText(fileName, note.Content, Encoding.UTF8);
        }

        public override string FileExtension
        {
            get { return "*.htm;*.html"; }
        }

        public override string FileExtensionDescription
        {
            get { return "HTML files (*.htm;*.html)"; }
        }

        public override string Manufacture
        {
            get { return "daxnet"; }
        }

        public override string DisplayName
        {
            get { return Resources.HtmlExporterDisplayName; }
        }

        public override string Description
        {
            get { return Resources.HtmlExporterDescription; }
        }
    }
}
