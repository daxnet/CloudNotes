namespace CloudNotes.DesktopClient.Extensibility.Styling
{
    using System;
    using Apworks;

    /// <summary>
    /// Represents the style of the letter paper.
    /// </summary>
    internal class Style : IEntity
    {
        /// <summary>
        /// Gets or sets the identifier of the style.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid ID { get; set; }

        /// <summary>
        /// Gets or sets the name of the style.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the style.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the author of the style.
        /// </summary>
        /// <value>
        /// The author.
        /// </value>
        public string Author { get; set; }

        /// <summary>
        /// Gets or sets the date on which the style was created.
        /// </summary>
        /// <value>
        /// The creation date.
        /// </value>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the CSS content of the style.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public string Content { get; set; }


        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
