using Microsoft.Extensions.DependencyInjection;
using Utconnect.Common.Services.Abstractions;
using Utconnect.Common.Services.Implementations;

namespace Utconnect.Common;

public static class ConfigureServices
{
    public static void AddCommon(this IServiceCollection services)
    {
        services.AddTransient<IDateTime, DateTimeService>();
    }
}