using Nexus.Cadastro.Application.Models.Dtos;

namespace Nexus.Cadastro.Application.Queries;

public class ProdutosQuery : IRequest<List<ProdutoDto>>
{
    public string? Nome { get; set; }
    public string? Categoria { get; set; }
    public double PrecoMinimo { get; set; }
    public double PrecoMaximo { get; set; }
    public int EstoqueMinimo { get; set; }
    public int EstoqueMaximo { get; set; }
}