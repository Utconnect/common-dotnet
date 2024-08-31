using Microsoft.Extensions.DependencyInjection;
using Utconnect.Common.Infrastructure.Db.Interceptors;
using Utconnect.Common.Infrastructure.Db.Persistence;

namespace Utconnect.Common.Infrastructure.Db
{
    public static class ConfigureServices
    {
        public static void AddUnitOfWork<T>(this IServiceCollection services) where T : class, IUnitOfWork
        {
            services.AddScoped<IUnitOfWork, T>();
        }

        public static void AddAuditableEntityInterceptor(this IServiceCollection services)
        {
            services.AddScoped<AuditableEntitySaveChangesInterceptor>();
        }
    }
}