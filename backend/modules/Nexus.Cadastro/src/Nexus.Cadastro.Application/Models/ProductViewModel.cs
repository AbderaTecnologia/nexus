namespace Nexus.Cadastro.Application.Models;

public sealed record ProductViewModel
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double Price { get; init; }
    public int Stock { get; set; }
    
}