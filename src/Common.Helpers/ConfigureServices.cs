using Common.Helpers.Implementations;
using Common.Helpers.Models;
using Diacritics;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Helpers;

public static class ConfigureServices
{
    public static void AddHelpers(this IServiceCollection services)
    {
        services.AddTransient<IDiacriticsMapper, CommonDiacriticsMapper>();
        services.AddTransient<StringHelper>();
    }
}