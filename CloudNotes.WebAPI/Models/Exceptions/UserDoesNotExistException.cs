using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

using CloudNotes.WebAPI.Properties;

namespace CloudNotes.WebAPI.Models.Exceptions
{
    public class UserDoesNotExistException : EntityDoesNotExistException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserDoesNotExistException"/> class.
        /// </summary>
        public UserDoesNotExistException()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserDoesNotExistException"/> class.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        public UserDoesNotExistException(string userName)
            : base(string.Format(Resources.UserNameDoesNotExist, userName))
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserDoesNotExistException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the <paramref name="innerException" /> parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public UserDoesNotExistException(string message, Exception innerException)
            : base(message, innerException)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="UserDoesNotExistException"/> class.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected UserDoesNotExistException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}