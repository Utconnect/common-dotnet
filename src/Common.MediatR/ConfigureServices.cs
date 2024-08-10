using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Utconnect.Common.MediatR;

/// <summary>
/// Provides extension methods for configuring services related to MediatR and validation.
/// </summary>
public static class ConfigureServices
{
    /// <summary>
    /// Registers MediatR and FluentValidation services with the <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to which the services will be added.</param>
    /// <param name="assembly">The assembly from which to register MediatR handlers and FluentValidation validators.</param>
    public static void AddCommonMediatR(this IServiceCollection services, Assembly assembly)
    {
        services.AddMediatR(config => { config.RegisterServicesFromAssembly(assembly); });
        services.AddValidatorsFromAssembly(assembly);
    }
}