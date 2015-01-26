using CloudNotes.DesktopClient.Extensibility;
using CloudNotes.DesktopClient.Extensibility.Data;
using CloudNotes.DesktopClient.Extensibility.Exceptions;
using CloudNotes.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudNotes.DesktopClient.Extensions.Exporters
{
    [Extension("{E2A36337-D8C9-4AC7-BF59-26B7892C94E1}", "TextFileExporter")]
    public sealed class TextFileExporter : ExportExtension
    {
        public override string FileExtension
        {
            get { return "*.txt"; }
        }

        public override string FileExtensionDescription
        {
            get { return "Text Files (*.txt)"; }
        }

        protected override void DoExport(string fileName, Note note, object options)
        {
            var encodingInfo = (EncodingInfo)options;
            File.WriteAllText(fileName, note.Content.RemoveHtmlTags(), Encoding.GetEncoding(encodingInfo.CodePage));
        }

        protected override IExportOptionDialog OptionDialog
        {
            get
            {
                return new TextFileExporterOptionDialog();
            }
        }

        public override string Manufacture
        {
            get { return "daxnet"; }
        }

        public override string DisplayName
        {
            get { return "Text File Exporter"; }
        }

        public override string Description
        {
            get { return "Exports the current note to the text file."; }
        }
    }
}
