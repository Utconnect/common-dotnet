using System.Net;
using Utconnect.Common.Models.Errors;

namespace Utconnect.Common.Exceptions.Core;

public class HttpException(
    HttpStatusCode statusCode,
    IEnumerable<Error> errors,
    string message = "",
    Exception? innerException = null)
    : Exception(message, innerException)
{
    public HttpStatusCode StatusCode { get; } = statusCode;

    public IEnumerable<Error> Errors { get; } = errors;
}