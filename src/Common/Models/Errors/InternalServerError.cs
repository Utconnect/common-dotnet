using System.Net;

namespace Utconnect.Common.Models.Errors;

/// <summary>
/// Represents an error indicating an internal server error with a 500 HTTP status code.
/// </summary>
public class InternalServerError : Error
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InternalServerError"/> class.
    /// </summary>
    /// <param name="message">The error message. Defaults to "Server error" if not provided.</param>
    public InternalServerError(string message = "Server error") : base(HttpStatusCode.InternalServerError, message)
    {
    }
}