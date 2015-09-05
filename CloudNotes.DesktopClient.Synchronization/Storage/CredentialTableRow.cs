namespace CloudNotes.DesktopClient.Synchronization.Storage
{
    [TableMapping("Credentials")]
    internal sealed class CredentialTableRow
    {
        public string UserName { get; set; }
        public string PasswordEncrypted { get; set; }

        public string Id { get; set; }

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
