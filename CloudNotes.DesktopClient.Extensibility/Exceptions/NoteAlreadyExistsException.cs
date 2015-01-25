

namespace CloudNotes.DesktopClient.Extensibility.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public sealed class NoteAlreadyExistsException : ApplicationException
    {
        public NoteAlreadyExistsException()
            : base()
        { }

        public NoteAlreadyExistsException(string message)
            : base(message)
        { }

        public NoteAlreadyExistsException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
