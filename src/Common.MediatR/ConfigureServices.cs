using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Utconnect.Common.MediatR;

public static class ConfigureServices
{
    public static void AddCommonMediatR(this IServiceCollection services, Assembly assembly)
    {
        services.AddMediatR(config => { config.RegisterServicesFromAssembly(assembly); });
        services.AddValidatorsFromAssembly(assembly);
    }
}