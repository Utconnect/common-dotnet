using Common.Identity.Models;

namespace Common.Identity.Services.Abstractions;

public interface IIdentityService
{
    IUser? GetCurrent();
}