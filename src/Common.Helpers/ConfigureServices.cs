using Diacritics;
using Microsoft.Extensions.DependencyInjection;
using Utconnect.Common.Helpers.Abstractions;
using Utconnect.Common.Helpers.Implementations;
using Utconnect.Common.Helpers.Models;

namespace Utconnect.Common.Helpers
{
    /// <summary>
    /// Provides extension methods for configuring services in the dependency injection container.
    /// </summary>
    public static class ConfigureServices
    {
        /// <summary>
        /// Registers helper services with the <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to which the services will be added.</param>
        public static void AddHelpers(this IServiceCollection services)
        {
            services.AddTransient<IDiacriticsMapper, CommonDiacriticsMapper>();
            services.AddTransient<IStringHelper, StringHelper>();
        }
    }
}