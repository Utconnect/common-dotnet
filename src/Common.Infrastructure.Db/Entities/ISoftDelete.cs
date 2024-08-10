namespace Utconnect.Common.Infrastructure.Db.Entities;

/// <summary>
/// Defines an interface for entities that support soft deletion.
/// </summary>
public interface ISoftDelete
{
    /// <summary>
    /// Gets or sets the date and time when the entity was soft deleted.
    /// </summary>
    DateTime? DeletedAt { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the user who soft deleted the entity.
    /// </summary>
    Guid? DeletedBy { get; set; }
}