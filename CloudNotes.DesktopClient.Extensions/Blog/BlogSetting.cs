namespace CloudNotes.DesktopClient.Extensions.Blog
{
    using CloudNotes.DesktopClient.Extensibility.Extensions;

    /// <summary>
    /// Represents the setting data for the blog extension.
    /// </summary>
    public sealed class BlogSetting : IExtensionSetting
    {
        #region Public Fields
        /// <summary>
        /// The default setting data for the blog extension.
        /// </summary>
        public static readonly BlogSetting Default = new BlogSetting();
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the meta weblog address.
        /// </summary>
        /// <value>
        /// The meta weblog address.
        /// </value>
        public string MetaWeblogAddress { get; set; }

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
        #endregion
    }
}
