
namespace CloudNotes.Infrastructure
{
    /// <summary>
    /// Represents the static class that holds all the API privilege keys.
    /// </summary>
    public static class Privileges
    {
        /// <summary>
        /// The API create user privilege key.
        /// </summary>
        public const string ApiCreateUser = "Api.CreateUser";
        /// <summary>
        /// The API update user privilege key.
        /// </summary>
        public const string ApiUpdateUser = "Api.UpdateUser";
        /// <summary>
        /// The API ping privilege key.
        /// </summary>
        public const string ApiPing = "Api.Ping";

        /// <summary>
        /// The API get package privilege key.
        /// </summary>
        public const string ApiGetPackage = "Api.GetPackage";

        /// <summary>
        /// The API post package privilege key.
        /// </summary>
        public const string ApiPostPackage = "Api.PostPackage";
    }
}
