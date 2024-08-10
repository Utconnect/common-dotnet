using Utconnect.Common.Identity.Models;

namespace Utconnect.Common.Identity.Services.Abstractions;

public interface IIdentityService
{
    IUser? GetCurrent();
}