using Common.Exceptions.Core;

namespace Common.Identity.Exceptions;

internal class InvalidClaimUnixDateTimeException()
    : InternalServerErrorException("Unix DateTime cannot be parsed, user cannot be identified");