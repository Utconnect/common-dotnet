using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Utconnect.Common.Identity.Services.Abstractions;
using Utconnect.Common.Infrastructure.Db.Entities;
using Utconnect.Common.Services.Abstractions;

namespace Utconnect.Common.Infrastructure.Db.Interceptors
{
    /// <summary>
    /// Intercepts and updates entities during the save changes process to apply auditing information.
    /// </summary>
    public class AuditableEntitySaveChangesInterceptor : SaveChangesInterceptor
    {
        private readonly IIdentityService _identityService;
        private readonly IDateTime _dateTime;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuditableEntitySaveChangesInterceptor"/> class.
        /// </summary>
        /// <param name="identityService">The service for retrieving the current user's identity.</param>
        /// <param name="dateTime">The service for retrieving the current date and time.</param>
        public AuditableEntitySaveChangesInterceptor(IIdentityService identityService, IDateTime dateTime)
        {
            _identityService = identityService;
            _dateTime = dateTime;
        }

        /// <summary>
        /// Called before changes are saved to the database to update entities with auditing information.
        /// </summary>
        /// <param name="eventData">The event data for saving changes.</param>
        /// <param name="result">The result of the interception.</param>
        /// <returns>The updated result of the interception.</returns>
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            UpdateEntities(eventData.Context);

            return base.SavingChanges(eventData, result);
        }

        /// <summary>
        /// Called after changes are saved to the database to update entities with auditing information.
        /// </summary>
        /// <param name="eventData">The event data for saved changes.</param>
        /// <param name="result">The result of the operation.</param>
        /// <param name="cancellationToken">A cancellation token for the asynchronous operation.</param>
        /// <returns>The result of the asynchronous operation.</returns>
        public override ValueTask<int> SavedChangesAsync(
            SaveChangesCompletedEventData eventData,
            int result,
            CancellationToken cancellationToken = new CancellationToken())
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
                Guid userId = _identityService.GetCurrent()?.Id ?? Guid.Empty;

                if (entry.State != EntityState.Added &&
                    entry.State != EntityState.Modified &&
                    !entry.HasChangedOwnedEntities())
                {
                    continue;
                }

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedBy = userId;
                    entry.Entity.CreatedAt = _dateTime.Now;
                }

                entry.Entity.CreatedBy = userId;
                entry.Entity.CreatedAt = _dateTime.Now;
            }
        }
    }

    /// <summary>
    /// Provides extension methods for entity entries.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Determines whether the entity entry has any owned entities that have changed.
        /// </summary>
        /// <param name="entry">The entity entry to check.</param>
        /// <returns><c>true</c> if the entity entry has changed owned entities; otherwise, <c>false</c>.</returns>
        public static bool HasChangedOwnedEntities(this EntityEntry entry) =>
            entry.References.Any(r =>
                r.TargetEntry != null &&
                r.TargetEntry.Metadata.IsOwned() &&
                (r.TargetEntry.State == EntityState.Added || r.TargetEntry.State == EntityState.Modified));
    }
}