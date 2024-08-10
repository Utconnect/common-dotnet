using Diacritics;
using Utconnect.Common.Helpers.Abstractions;

namespace Utconnect.Common.Helpers.Implementations;

internal class StringHelper(IDiacriticsMapper diacriticsMapper) : IStringHelper
{
    public string RemoveDiacritics(string str)
    {
        return diacriticsMapper.RemoveDiacritics(str);
    }
}