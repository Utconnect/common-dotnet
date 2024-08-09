using System.Net;
using Common.Models.Errors;

namespace Common.Exceptions.Core;

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