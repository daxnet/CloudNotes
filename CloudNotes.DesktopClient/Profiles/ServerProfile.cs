
namespace CloudNotes.DesktopClient.Profiles
{
    /// <summary>
    /// Represents the server profile.
    /// </summary>
    public class ServerProfile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServerProfile"/> class.
        /// </summary>
        public ServerProfile()
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerProfile"/> class.
        /// </summary>
        /// <param name="uri">The URI of the server.</param>
        public ServerProfile(string uri)
        {
            Uri = uri;
        }

        /// <summary>
        /// Gets or sets the URI.
        /// </summary>
        /// <value>
        /// The URI.
        /// </value>
        public string Uri { get; set; }

        public bool IsSelected { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Uri))
            {
                return Uri;
            }
            return base.ToString();
        }
    }
}
