using Utconnect.Common.Exceptions.Core;

namespace Utconnect.Common.Identity.Exceptions;

internal class NoClaimException()
    : InternalServerErrorException("No user claims, user cannot be identified");