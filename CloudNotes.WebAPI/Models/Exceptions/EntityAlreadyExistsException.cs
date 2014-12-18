using System;
using System.Runtime.Serialization;

namespace CloudNotes.WebAPI.Models.Exceptions
{
    /// <summary>
    /// Represents the error occurred when the application is going to add a new
    /// entity to its repository but the entity has already been existed.
    /// </summary>
    public class EntityAlreadyExistsException : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityAlreadyExistsException"/> class.
        /// </summary>
        public EntityAlreadyExistsException()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityAlreadyExistsException"/> class.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        public EntityAlreadyExistsException(string message)
            : base(message)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityAlreadyExistsException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the <paramref name="innerException" /> parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public EntityAlreadyExistsException(string message, Exception innerException)
            : base(message, innerException)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityAlreadyExistsException"/> class.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        protected EntityAlreadyExistsException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
    }
}