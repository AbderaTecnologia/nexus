using Nexus.Cadastro.Application.Models.Dtos;

namespace Nexus.Cadastro.Application.Produtos.Queries;

public class ProdutosQuery : IRequest<List<ProdutoDto>>
{
    public string Categoria { get; set; }
    public float? PrecoMinimo { get; set; }
    public float? PrecoMaximo { get; set; }
    public int? EstoqueMinimo { get; set; }
    public int? EstoqueMaximo { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    
}