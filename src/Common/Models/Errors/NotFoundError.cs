using System.Net;

namespace Utconnect.Common.Models.Errors;

/// <summary>
/// Represents an error indicating that a resource was not found, with a 404 HTTP status code.
/// </summary>
public class NotFoundError : Error
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundError"/> class.
    /// </summary>
    /// <param name="message">The error message.</param>
    public NotFoundError(string message) : base(HttpStatusCode.NotFound, message)
    {
    }
}

/// <summary>
/// Represents an error indicating that a resource of a specific type was not found, with a 404 HTTP status code.
/// </summary>
/// <typeparam name="T">The type of the resource that was not found.</typeparam>
public class NotFoundError<T> : NotFoundError
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundError{T}"/> class.
    /// </summary>
    /// <param name="value">The value of the identifier that was not found.</param>
    /// <param name="key">The name of the identifier. Defaults to "ID" if not provided.</param>
    public NotFoundError(string value, string key = "ID") : base($"{typeof(T).Name} with {key} {value} is not found")
    {
    }
}