using System.Net;

namespace Utconnect.Common.Models.Errors
{
    /// <summary>
    /// Represents an error indicating a bad request with a 400 HTTP status code.
    /// </summary>
    public class BadRequestError : Error
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BadRequestError"/> class.
        /// </summary>
        /// <param name="message">The error message. Defaults to "This request cannot be handled" if not provided.</param>
        public BadRequestError(string message = "This request cannot be handled") : base(HttpStatusCode.BadRequest, message)
        {
        }
    }
}