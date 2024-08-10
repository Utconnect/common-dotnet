namespace Utconnect.Common.Models.Errors;

/// <summary>
/// Represents a validation error associated with a specific property.
/// </summary>
public class ValidationError : Error
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ValidationError"/> class.
    /// </summary>
    /// <param name="property">The name of the property associated with the validation error.</param>
    /// <param name="message">The error message.</param>
    public ValidationError(string property, string message) : base(property, message)
    {
    }
}