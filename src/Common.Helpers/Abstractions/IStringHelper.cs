namespace Utconnect.Common.Helpers.Abstractions
{
    /// <summary>
    /// Defines methods for processing and manipulating strings.
    /// </summary>
    public interface IStringHelper
    {
        /// <summary>
        /// Removes diacritical marks (accents) from the specified string.
        /// </summary>
        /// <param name="str">The string from which to remove diacritics.</param>
        /// <returns>A new string with diacritical marks removed.</returns>
        string RemoveDiacritics(string str);
    }
}