using Common.Diacritics.Implementations;
using Diacritics;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Diacritics;

public static class ConfigureServices
{
    public static void AddHelpers(this IServiceCollection services)
    {
        services.AddTransient<IDiacriticsMapper, CommonDiacriticsMapper>();
        services.AddTransient<StringHelper>();
    }
}