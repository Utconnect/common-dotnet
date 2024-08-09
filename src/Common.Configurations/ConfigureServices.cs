using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Configurations;

public static class ConfigureServices
{
    public static void AddConfiguration<TOptions>(this IServiceCollection services,
        IConfiguration configuration,
        string? sectionName)
        where TOptions : class
    {
        if (string.IsNullOrEmpty(sectionName))
        {
            sectionName = typeof(TOptions).Name;
        }

        services.Configure<TOptions>(configuration.GetSection(sectionName));
    }
}