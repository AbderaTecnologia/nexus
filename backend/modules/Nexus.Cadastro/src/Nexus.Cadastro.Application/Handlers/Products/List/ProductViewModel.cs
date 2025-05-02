namespace Nexus.Cadastro.Application.Handlers.Products.List;

public sealed record ProductViewModel
{
    required public Guid Id { get; init; }
    required public string Name { get; init; }
    required public string Description { get; init; }
    required public decimal Price { get; init; }
    required public bool IsActive { get; init; }
}