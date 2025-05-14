namespace Nexus.Cadastro.Application.Models;

public sealed record ProdutoViewModel
{
    public Guid Id { get; init; }
    public string Nome { get; init; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public double Preco { get; init; }
    public int Estoque { get; set; }
    
}