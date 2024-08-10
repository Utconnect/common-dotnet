using Microsoft.Extensions.DependencyInjection;
using Utconnect.Common.Identity.Services.Abstractions;
using Utconnect.Common.Identity.Services.Implementations;

namespace Utconnect.Common.Identity;

public static class ConfigureServices
{
    public static void AddCommonIdentity(this IServiceCollection services)
    {
        services.AddTransient<IIdentityService, IdentityService>();
    }
}