using System;

namespace Utconnect.Common.Infrastructure.Db.Entities
{
    /// <summary>
    /// Represents a base class for auditable entities with a GUID as the identifier.
    /// </summary>
    public abstract class BaseAuditableEntity : BaseAuditableEntity<Guid>
    {
    }

    /// <summary>
    /// Represents a base class for auditable entities with a specified identifier type.
    /// </summary>
    /// <typeparam name="T">The type of the entity's identifier.</typeparam>
    public abstract class BaseAuditableEntity<T> : BaseEntity<T>
    {
        /// <summary>
        /// Gets or sets the date and time when the entity was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the user who created the entity.
        /// </summary>
        public Guid? CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the entity was last modified.
        /// </summary>
        public DateTime? LastModifiedAt { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the user who last modified the entity.
        /// </summary>
        public Guid? LastModifiedBy { get; set; }
    }
}