using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Utconnect.Common.Identity.Services.Abstractions;
using Utconnect.Common.Infrastructure.Db.Entities;
using Utconnect.Common.Services.Abstractions;

namespace Utconnect.Common.Infrastructure.Db.Interceptors;

public class AuditableEntitySaveChangesInterceptor(IIdentityService identityService, IDateTime dateTime)
    : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        UpdateEntities(eventData.Context);

        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData,
        int result,
        CancellationToken cancellationToken = new())
    {
        UpdateEntities(eventData.Context);
        return base.SavedChangesAsync(eventData, result, cancellationToken);
    }

    private void UpdateEntities(DbContext? context)
    {
        if (context == null)
        {
            return;
        }

        foreach (EntityEntry<BaseAuditableEntity> entry in context.ChangeTracker.Entries<BaseAuditableEntity>())
        {
            Guid userId = identityService.GetCurrent()?.Id ?? Guid.Empty;

            if (entry.State != EntityState.Added &&
                entry.State != EntityState.Modified &&
                !entry.HasChangedOwnedEntities())
            {
                continue;
            }

            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedBy = userId;
                entry.Entity.CreatedAt = dateTime.Now;
            }

            entry.Entity.CreatedBy = userId;
            entry.Entity.CreatedAt = dateTime.Now;
        }
    }
}

public static class Extensions
{
    public static bool HasChangedOwnedEntities(this EntityEntry entry) =>
        entry.References.Any(r =>
            r.TargetEntry != null &&
            r.TargetEntry.Metadata.IsOwned() &&
            r.TargetEntry.State is EntityState.Added or EntityState.Modified);
}