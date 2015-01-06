namespace CloudNotes.DesktopClient.Profiles
{
    /// <summary>
    /// Represents the user profile.
    /// </summary>
    public class UserProfile
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
        /// Gets or sets a value indicating whether this instance is selected.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is selected; otherwise, <c>false</c>.
        /// </value>
        public bool IsSelected { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the password is remembered.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the password is remembered; otherwise, <c>false</c>.
        /// </value>
        public bool RememberPassword { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the current user can login automatically.
        /// </summary>
        /// <value>
        ///   <c>true</c> if the current user can login automatically; otherwise, <c>false</c>.
        /// </value>
        public bool AutoLogin { get; set; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return UserName;
        }
    }
}
