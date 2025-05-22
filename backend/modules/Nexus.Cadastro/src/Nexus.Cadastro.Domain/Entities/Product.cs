using Nexus.Core.Domain.Entities.Base;

namespace Nexus.Cadastro.Domain.Entities;

public sealed class Product : EntitySoftDeletedBase
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Stock { get; set; }
    public string Description { get; set; }
}