using Utconnect.Common.Exceptions.Core;

namespace Utconnect.Common.Identity.Exceptions;

internal class InvalidClaimUnixDateTimeException()
    : InternalServerErrorException("Unix DateTime cannot be parsed, user cannot be identified");