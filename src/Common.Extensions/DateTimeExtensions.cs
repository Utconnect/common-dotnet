namespace Utconnect.Common.Extensions;

/// <summary>
/// Provides extension methods for <see cref="DateTime"/> objects.
/// </summary>
public static class DateTimeExtensions
{
    /// <summary>
    /// Converts the specified <see cref="DateTime"/> to a Unix timestamp.
    /// </summary>
    /// <param name="dateTime">The <see cref="DateTime"/> to convert.</param>
    /// <returns>The number of seconds that have elapsed since the Unix epoch (January 1, 1970).</returns>
    public static long ToTimestamp(this DateTime dateTime)
    {
        TimeSpan elapsedTime = dateTime - DateTime.UnixEpoch;
        return (long)elapsedTime.TotalSeconds;
    }
}