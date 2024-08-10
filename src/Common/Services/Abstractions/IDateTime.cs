namespace Utconnect.Common.Services.Abstractions;

/// <summary>
/// Provides access to the current date and time.
/// </summary>
public interface IDateTime
{
    /// <summary>
    /// Gets the current date and time.
    /// </summary>
    DateTime Now { get; }
}