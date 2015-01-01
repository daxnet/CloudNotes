namespace CloudNotes.Infrastructure
{
    /// <summary>
    /// Represents the constants used by the CloudNotes solution.
    /// </summary>
    public static class Constants
    {
        #region Constants for Infrastructure
        /// <summary>
        /// The User Name of the Proxy account.
        /// </summary>
        public const string ProxyUserName = "proxy";
        /// <summary>
        /// The Password of the Proxy account.
        /// </summary>
        public const string ProxyUserPassword = "proxy";
        /// <summary>
        /// The Email Address of the Administrator account.
        /// </summary>
        public const string ProxyUserEmail = "proxy@cloudnotes.com";
        #endregion

        #region Constants for Application
        /// <summary>
        /// The Email Address validation regular expression.
        /// </summary>
        public const string EmailAddressFormatPattern = @"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$";
        /// <summary>
        /// The regular expression for extracting the Src value from an HTML Img tag.
        /// </summary>
        public const string ImgSrcFormatPattern = @"<img[^>]*?src\s*=\s*[""']?([^'"" >]+?)[ '""][^>]*?>";
        /// <summary>
        /// The key of the setting that represents the relative package location URI on the server file system. (server setting).
        /// </summary>
        public const string PackageLocationUriSettingKey = "cloudnotes:PackageLocationUri";
        /// <summary>
        /// The key of the setting that represents the URL of the server that provides the packages. (client setting).
        /// </summary>
        public const string PackageServerSettingKey = "cloudnotes:PackageServer";
        /// <summary>
        /// The name of the Desktop Client settings file.
        /// </summary>
        public const string DesktopClientSettingsFile = "settings.json";
        /// <summary>
        /// The name of the profile file used by the login provider.
        /// </summary>
        public const string ProfileFileName = "cloudnotes.profile";
        #endregion
    }
}
