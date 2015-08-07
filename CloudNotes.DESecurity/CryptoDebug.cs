using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudNotes.DESecurity
{
#if DEBUG
    public class Crypto
    {
        /// <summary>
        ///     The User Name of the Proxy account.
        /// </summary>
        public const string ProxyUserName = "proxy";

        /// <summary>
        ///     The Password of the Proxy account.
        /// </summary>
        public const string ProxyUserPassword = "proxy";

        /// <summary>
        ///     The Email Address of the Administrator account.
        /// </summary>
        public const string ProxyUserEmail = "proxy@cloudnotes.com";

        public string Encrypt(string inputText)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(inputText));
        }

        public string Decrypt(string inputText)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(inputText));
        }

        public static string ComputeHash(string source, string salt, Encoding encoding = null)
        {
            return new Crypto().Encrypt(source);
        }

        public static Crypto CreateDefaultCrypto()
        {
            return new Crypto();
        }
    }
#endif
}
