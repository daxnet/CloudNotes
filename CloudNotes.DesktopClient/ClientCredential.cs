
namespace CloudNotes.DesktopClient
{
    /// <summary>
    /// Represents the client credentials.
    /// </summary>
    public sealed class ClientCredential
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the server URI.
        /// </summary>
        /// <value>
        /// The server URI.
        /// </value>
        public string ServerUri { get; set; }
    }
}
