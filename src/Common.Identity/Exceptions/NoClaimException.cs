using Utconnect.Common.Exceptions.Core;

namespace Utconnect.Common.Identity.Exceptions
{
    internal class NoClaimException
        : InternalServerErrorException
    {
        public NoClaimException() : base("No user claims, user cannot be identified")
        {
        }
    }
}