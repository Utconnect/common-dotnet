using Diacritics;

namespace Common.Helpers.Implementations;

internal class StringHelper(IDiacriticsMapper diacriticsMapper)
{
    public string RemoveDiacritics(string str)
    {
        return diacriticsMapper.RemoveDiacritics(str);
    }
}