using Nexus.Core.Domain.Entities.Base;

namespace Nexus.Core.Domain.Entities;

public abstract class Company : EntitySoftDeletedBase
{
    public string Name { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
}