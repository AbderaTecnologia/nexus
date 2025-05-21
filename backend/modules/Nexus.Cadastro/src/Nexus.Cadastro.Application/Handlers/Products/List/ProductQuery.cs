using Nexus.Cadastro.Application.Models.Dtos;

namespace Nexus.Cadastro.Application.Handlers.Products.List;

public class ProductQuery : IRequest<List<ProdutosDto>>
{
    public double? PrecoMinimo { get; set; }
    public double? PrecoMaximo { get; set; }
    public int? EstoqueMinimo { get; set; }
    public int? EstoqueMaximo { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    
}