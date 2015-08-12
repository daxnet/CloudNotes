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

    /// <summary>
    /// Represents the manager that loads and manages the styles for CloudNotes desktop client.
    /// </summary>
    internal sealed class StyleManager : ExternalResourceManager<Style>
    {
        #region Private Constants
        private const string MetadataFileName = "metadata.json";
        private const string StyleFileName = "style.css";
        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="StyleManager"/> class.
        /// </summary>
        /// <param name="path">The path from which the styles is going to be searched.</param>
        public StyleManager(string path)
            : base(path, Constants.StyleFileSearchPattern)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StyleManager"/> class.
        /// </summary>
        public StyleManager()
            : this(Path.Combine(Application.StartupPath, Constants.StyleFolderName))
        {

        }
        #endregion

        #region Protected Methods

        /// <summary>
        /// Loads the resources from the given file.
        /// </summary>
        /// <param name="fileName">Name of the file from which the resource is loaded.</param>
        /// <returns>
        /// A list of resource instances.
        /// </returns>
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
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets a list of key-value-pairs that the key indicates the style Id, whereas the value
        /// indicates the corresponding style instance.
        /// </summary>
        /// <value>
        /// The list of key-value-pairs which contain the style Id and style instance.
        /// </value>
        public IEnumerable<KeyValuePair<Guid, Style>> Styles
        {
            get
            {
                return this.Resources;
            }
        }
        #endregion
    }
}
