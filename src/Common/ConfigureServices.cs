using Common.Services.Abstractions;
using Common.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Common;

public static class ConfigureServices
{
    public static void AddCommon(this IServiceCollection services)
    {
        services.AddTransient<IDateTime, DateTimeService>();
    }
}