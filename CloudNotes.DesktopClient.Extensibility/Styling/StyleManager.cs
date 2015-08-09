namespace CloudNotes.DesktopClient.Extensibility.Styling
{
    using CloudNotes.Infrastructure;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;
    using ICSharpCode.SharpZipLib.Core;
    using ICSharpCode.SharpZipLib.Zip;
    using Newtonsoft.Json;

    internal sealed class StyleManager : ExternalResourceManager<Style>
    {
        private const string MetadataFileName = "metadata.json";
        private const string StyleFileName = "style.css";

        public StyleManager(string path)
            : base(path, Constants.StyleFileSearchPattern)
        {
        }

        public StyleManager()
            : this(Path.Combine(Application.StartupPath, Constants.StyleFolderName))
        {

        }

        public IEnumerable<KeyValuePair<Guid, Style>> Styles
        {
            get
            {
                return this.Resources;
            }
        }

        protected override IEnumerable<Style> LoadResources(string fileName)
        {
            try
            {
                var extractedContent = new Dictionary<string, string>();
                var zipFile = new ZipFile(fileName);
                foreach (ZipEntry entry in zipFile)
                {
                    if (!entry.IsFile ||
                        (string.Compare(entry.Name, MetadataFileName, StringComparison.InvariantCultureIgnoreCase) != 0 &&
                        string.Compare(entry.Name, StyleFileName, StringComparison.InvariantCultureIgnoreCase) != 0))
                        continue;

                    var buffer = new byte[4000];
                    var entryStream = zipFile.GetInputStream(entry);
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        StreamUtils.Copy(entryStream, memoryStream, buffer);
                        extractedContent[entry.Name] = Encoding.ASCII.GetString(memoryStream.ToArray());
                    }
                }
                if (extractedContent.ContainsKey(MetadataFileName) &&
                    extractedContent.ContainsKey(StyleFileName))
                {
                    var style = JsonConvert.DeserializeObject<Style>(extractedContent[MetadataFileName]);
                    if (style.ID == Guid.Empty)
                        return null;
                    style.Content = extractedContent[StyleFileName];
                    return new[] { style };
                }
            }
            catch
            {
            }
            
            return null;
        }
       
    }
}
