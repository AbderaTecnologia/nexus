namespace Nexus.Cadastro.Application.Models;

public sealed record ProdutoViewModel
{
    public Guid Id { get; init; }
    public string Name { get; init; }
}