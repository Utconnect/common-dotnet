using Microsoft.Extensions.DependencyInjection;
using Utconnect.Common.Exceptions.Filters;

namespace Utconnect.Common.Exceptions
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
        public static void AddExceptionFilter(this IServiceCollection services)
        {
            services.AddScoped<HttpResponseExceptionFilter>();
        }
    }
}