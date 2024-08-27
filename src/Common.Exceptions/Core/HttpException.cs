using System;
using System.Collections.Generic;
using System.Net;
using Utconnect.Common.Models.Errors;

namespace Utconnect.Common.Exceptions.Core
{
    /// <summary>
    /// Represents an exception that occurs during HTTP operations, including a status code and a collection of errors.
    /// </summary>
    public class HttpException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpException"/> class with the specified HTTP status code, errors, message, and an optional inner exception.
        /// </summary>
        /// <param name="statusCode">The HTTP status code associated with the exception.</param>
        /// <param name="errors">A collection of <see cref="Error"/> objects providing details about the errors that occurred.</param>
        /// <param name="message">The message that describes the error. This parameter is optional and defaults to an empty string.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. This parameter is optional and defaults to <c>null</c>.</param>
        public HttpException(
            HttpStatusCode statusCode,
            IEnumerable<Error> errors,
            string message = "",
            Exception? innerException = null) : base(message, innerException)
        {
            StatusCode = statusCode;
            Errors = errors;
        }

        /// <summary>
        /// Gets the HTTP status code associated with this exception.
        /// </summary>
        public HttpStatusCode StatusCode { get; }

        /// <summary>
        /// Gets a collection of <see cref="Error"/> objects that provide details about the errors that occurred.
        /// </summary>
        public IEnumerable<Error> Errors { get; }
    }
}