using Diacritics;
using Microsoft.Extensions.DependencyInjection;
using Utconnect.Common.Helpers.Implementations;
using Utconnect.Common.Helpers.Models;

namespace Utconnect.Common.Helpers;

public static class ConfigureServices
{
    public static void AddHelpers(this IServiceCollection services)
    {
        services.AddTransient<IDiacriticsMapper, CommonDiacriticsMapper>();
        services.AddTransient<StringHelper>();
    }
}