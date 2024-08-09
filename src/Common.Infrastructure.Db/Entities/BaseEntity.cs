using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Infrastructure.Db.Entities;

public abstract class BaseEntity : BaseEntity<Guid>;

public abstract class BaseEntity<T>
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public T Id { get; set; } = default!;
}