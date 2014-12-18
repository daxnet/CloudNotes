using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace CloudNotes.WebAPI.Models.Exceptions
{
    public class InsufficientPriviledgeException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InsufficientPriviledgeException"/> class.
        /// </summary>
        public InsufficientPriviledgeException()
            : base()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InsufficientPriviledgeException"/> class.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        public InsufficientPriviledgeException(string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InsufficientPriviledgeException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the <paramref name="innerException" /> parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public InsufficientPriviledgeException(string message, Exception innerException)
            : base(message, innerException)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InsufficientPriviledgeException"/> class.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected InsufficientPriviledgeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}