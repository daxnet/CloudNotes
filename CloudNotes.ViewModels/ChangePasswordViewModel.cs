
namespace CloudNotes.ViewModels
{
    /// <summary>
    /// Represents the change password view model.
    /// </summary>
    public class ChangePasswordViewModel : ViewModel
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName { get; set; }
        /// <summary>
        /// Gets or sets the old password.
        /// </summary>
        /// <value>
        /// The old password.
        /// </value>
        public string EncodedOldPassword { get; set; }
        /// <summary>
        /// Gets or sets the new password.
        /// </summary>
        /// <value>
        /// The new password.
        /// </value>
        public string EncodedNewPassword { get; set; }
    }
}
