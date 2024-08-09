using Common.Exceptions.Core;

namespace Common.Identity.Exceptions;

internal class NoClaimException()
    : InternalServerErrorException("No user claims, user cannot be identified");