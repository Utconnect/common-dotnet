using System;
using System.Collections.Generic;
using System.Net;
using Utconnect.Common.Models.Errors;

namespace Utconnect.Common.Exceptions.Core
{
    /// <summary>
    /// Represents an exception that indicates an internal server error.
    /// This exception can be wrapped into an <see cref="HttpException"/> with a 500 Internal Server Error status code.
    /// </summary>
    public abstract class InternalServerErrorException : InnerException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InternalServerErrorException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception. This parameter is optional and defaults to <c>null</c>.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. This parameter is optional and defaults to <c>null</c>.</param>
        protected InternalServerErrorException(string? message, Exception? innerException = null) : base(message,
            innerException)
        {
        }

        /// <summary>
        /// Wraps the current exception into an <see cref="HttpException"/> with a 500 Internal Server Error status code.
        /// </summary>
        /// <returns>An <see cref="HttpException"/> that represents the wrapped exception with a 500 status code.</returns>
        public override HttpException WrapException()
        {
            List<Error> errorResponse = new List<Error>() { new InternalServerError(Message) };
            return new HttpException(HttpStatusCode.InternalServerError, errorResponse, Message, this);
        }
    }
}