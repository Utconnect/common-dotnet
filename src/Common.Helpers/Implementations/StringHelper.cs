using Diacritics;
using Utconnect.Common.Helpers.Abstractions;

namespace Utconnect.Common.Helpers.Implementations
{
    internal class StringHelper : IStringHelper
    {
        private readonly IDiacriticsMapper _diacriticsMapper;

        public StringHelper(IDiacriticsMapper diacriticsMapper)
        {
            _diacriticsMapper = diacriticsMapper;
        }

        public string RemoveDiacritics(string str)
        {
            return _diacriticsMapper.RemoveDiacritics(str);
        }
    }
}