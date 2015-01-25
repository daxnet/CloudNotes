

namespace CloudNotes.DesktopClient.Extensibility.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ExtensionException : ApplicationException
    {
        public ExtensionException()
            : base()
        { }

        public ExtensionException(string message)
            : base(message)
        { }

        public ExtensionException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
