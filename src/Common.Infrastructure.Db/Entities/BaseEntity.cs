using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Utconnect.Common.Infrastructure.Db.Entities
{
    /// <summary>
    /// Represents a base class for entities with a GUID as the identifier.
    /// </summary>
    public abstract class BaseEntity : BaseEntity<Guid>
    {
    }

    /// <summary>
    /// Represents a base class for entities with a specified identifier type.
    /// </summary>
    /// <typeparam name="T">The type of the entity's identifier.</typeparam>
    public abstract class BaseEntity<T>
    {
        /// <summary>
        /// Gets or sets the unique identifier for the entity.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public T Id { get; set; } = default!;
    }
}