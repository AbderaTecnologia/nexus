using Nexus.Cadastro.Application.Models.Dtos;

namespace Nexus.Cadastro.Application.Produto.Queries;

public class ProdutoQuery : IRequest<List<ProdutoDto>>
{
    public double? PrecoMinimo { get; set; }
    public double? PrecoMaximo { get; set; }
    public int? EstoqueMinimo { get; set; }
    public int? EstoqueMaximo { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    
}