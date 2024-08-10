using System.Net;

namespace Utconnect.Common.Models.Errors;

/// <summary>
/// Represents an error with a message and optional HTTP status code or property information.
/// </summary>
public abstract class Error
{
    /// <summary>
    /// Gets the HTTP status code associated with the error, if any.
    /// </summary>
    public HttpStatusCode? Code { get; }

    /// <summary>
    /// Gets the error message.
    /// </summary>
    public string Message { get; }

    /// <summary>
    /// Gets the property associated with the error, if any.
    /// </summary>
    public string? Property { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Error"/> class with the specified error message.
    /// </summary>
    /// <param name="message">The error message.</param>
    protected Error(string message)
    {
        Message = message;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Error"/> class with the specified HTTP status code and error message.
    /// </summary>
    /// <param name="code">The HTTP status code associated with the error.</param>
    /// <param name="message">The error message.</param>
    protected Error(HttpStatusCode code, string message)
    {
        Code = code;
        Message = message;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Error"/> class with the specified property and error message.
    /// </summary>
    /// <param name="property">The property associated with the error.</param>
    /// <param name="message">The error message.</param>
    protected Error(string property, string message)
    {
        Property = property;
        Message = message;
    }
}