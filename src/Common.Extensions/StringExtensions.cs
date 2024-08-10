namespace Utconnect.Common.Extensions;

/// <summary>
/// Provides extension methods for working with strings.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Converts a string representing a Unix timestamp into a <see cref="DateTime"/> object.
    /// </summary>
    /// <param name="unixDate">The string representation of the Unix timestamp.</param>
    /// <returns>
    /// A <see cref="DateTime"/> object representing the date and time corresponding to the Unix timestamp, 
    /// or <c>null</c> if the conversion fails.
    /// </returns>
    public static DateTime? ToUnixDateTime(this string unixDate)
    {
        if (!long.TryParse(unixDate, out long longDate))
        {
            return null;
        }

        return DateTime.UnixEpoch.AddSeconds(longDate).ToLocalTime();
    }
}