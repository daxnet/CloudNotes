namespace CloudNotes.DesktopClient.Synchronization.Storage
{
    using System;

    [TableMapping("Notes")]
    internal sealed class NoteTableRow
    {
        /// <summary>
        /// Gets or sets the ID of the note.
        /// </summary>
        public string Id { get; set; }

        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the title of the note.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the short description of the note.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the HTML content of the note.
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// Gets or sets the BASE64 encoded string of the thumbnail image.
        /// </summary>
        public string ThumbnailImageBase64 { get; set; }
        /// <summary>
        /// Gets or sets the date on which the note was published.
        /// </summary>
        public DateTime DatePublished { get; set; }
        /// <summary>
        /// Gets or sets the date on which the note was modified last time.
        /// </summary>
        public DateTime? DateLastModified { get; set; }
        /// <summary>
        /// Gets or sets the <c>DeleteFlag</c> which indicates the note deletion state.
        /// </summary>
        public int DeletedFlag { get; set; }

        /// <summary>
        /// Gets or sets the revision number of the note.
        /// </summary>
        /// <value>
        /// The revision.
        /// </value>
        public int Revision { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return Title;
        }
    }
}
