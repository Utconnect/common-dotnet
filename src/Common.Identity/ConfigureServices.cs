using Common.Identity.Services;
using Common.Identity.Services.Abstractions;
using Common.Identity.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Identity;

public static class ConfigureServices
{
    public static void AddCommonIdentity(this IServiceCollection services)
    {
        services.AddTransient<IIdentityService, IdentityService>();
    }
}