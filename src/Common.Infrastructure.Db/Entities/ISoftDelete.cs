namespace Common.Infrastructure.Db.Entities;

public interface ISoftDelete
{
    DateTime? DeletedAt { get; set; }
    Guid? DeletedBy { get; set; }
}