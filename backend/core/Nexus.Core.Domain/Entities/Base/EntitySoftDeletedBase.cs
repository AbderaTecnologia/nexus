namespace Nexus.Core.Domain.Entities.Base;

public abstract class EntitySoftDeletedBase : EntityBase
{
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public Guid? DeletedBy { get; set; }
}