using System;

namespace Utconnect.Common.Exceptions.Core
{
    /// <summary>
    /// Represents an abstract base class for exceptions that can be wrapped into an <see cref="HttpException"/>.
    /// </summary>
    public abstract class InnerException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InnerException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception. This parameter is optional and defaults to <c>null</c>.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. This parameter is optional and defaults to <c>null</c>.</param>
        protected InnerException(string? message, Exception? innerException = null) : base(message, innerException)
        {
        }

        /// <summary>
        /// When overridden in a derived class, wraps the current exception in an <see cref="HttpException"/>.
        /// </summary>
        /// <returns>An <see cref="HttpException"/> that represents the wrapped exception.</returns>
        public abstract HttpException WrapException();
    }
}