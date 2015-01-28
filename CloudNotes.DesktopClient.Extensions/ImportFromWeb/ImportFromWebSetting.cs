

namespace CloudNotes.DesktopClient.Extensions.ImportFromWeb
{
    using CloudNotes.DesktopClient.Extensibility;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents the setting for the ImportFromWeb extension.
    /// </summary>
    public sealed class ImportFromWebSetting : IExtensionSetting
    {
        /// <summary>
        /// Gets or sets the encoding code page.
        /// </summary>
        /// <value>
        /// The encoding code page.
        /// </value>
        public int EncodingCodePage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether images should be embedded into the note.
        /// </summary>
        /// <value>
        ///   <c>true</c> if images should be embedded into the note; otherwise, <c>false</c>.
        /// </value>
        public bool EmbedImages { get; set; }

    }
}
