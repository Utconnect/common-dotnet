using Microsoft.Extensions.DependencyInjection;
using Utconnect.Common.Services.Abstractions;
using Utconnect.Common.Services.Implementations;

namespace Utconnect.Common
{
    /// <summary>
    /// Provides extension methods for configuring common services.
    /// </summary>
    public static class ConfigureServices
    {
        /// <summary>
        /// Registers common services with the <see cref="IServiceCollection"/>.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to which the services will be added.</param>
        public static void AddCommon(this IServiceCollection services)
        {
            services.AddTransient<IDateTime, DateTimeService>();
        }
    }
}