using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Utconnect.Common.Configurations;

/// <summary>
/// Provides extension methods for configuring services in the dependency injection container.
/// </summary>
public static class ConfigureServices
{
    /// <summary>
    /// Adds a configuration section to the service collection and binds it to a specified options class.
    /// </summary>
    /// <typeparam name="TOptions">The type of the options class to bind the configuration section to. Must be a reference type.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection"/> to which the configuration will be added.</param>
    /// <param name="configuration">The <see cref="IConfiguration"/> instance containing the application configuration.</param>
    /// <param name="sectionName">The name of the configuration section to bind. If not provided, the name of the options class <typeparamref name="TOptions"/> is used.</param>
    /// <remarks>
    /// This method retrieves the specified configuration section from the provided <paramref name="configuration"/>
    /// and binds it to the specified options class <typeparamref name="TOptions"/>. 
    /// If the <paramref name="sectionName"/> is not provided, it defaults to the name of the options class.
    /// </remarks>
    public static void AddConfiguration<TOptions>(
        this IServiceCollection services,
        IConfiguration configuration,
        string? sectionName = null)
        where TOptions : class
    {
        if (string.IsNullOrEmpty(sectionName))
        {
            sectionName = typeof(TOptions).Name;
        }

        services.Configure<TOptions>(configuration.GetSection(sectionName));
    }
}