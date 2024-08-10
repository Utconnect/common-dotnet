using Diacritics;
using Diacritics.AccentMappings;

namespace Utconnect.Common.Helpers.Models;

/// <summary>
/// Provides a default implementation of the <see cref="DiacriticsMapper"/> class 
/// that uses Vietnamese accent mapping for diacritical mark removal.
/// </summary>
internal class CommonDiacriticsMapper : DiacriticsMapper
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CommonDiacriticsMapper"/> class.
    /// </summary>
    public CommonDiacriticsMapper() : base(new VietnameseAccentsMapping())
    {
    }
}