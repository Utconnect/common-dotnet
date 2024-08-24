using Microsoft.Extensions.DependencyInjection;
using Utconnect.Common.Infrastructure.Db.Interceptors;

namespace Utconnect.Common.Infrastructure.Db;

public static class ConfigureServices
{
    public static void AddAuditableEntityInterceptor(this IServiceCollection services)
    {
        services.AddScoped<AuditableEntitySaveChangesInterceptor>();
    }
}