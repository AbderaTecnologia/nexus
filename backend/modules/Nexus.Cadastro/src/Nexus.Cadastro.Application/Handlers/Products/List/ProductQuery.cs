using Nexus.Cadastro.Application.Models.Dtos;

namespace Nexus.Cadastro.Application.Handlers.Products.List;

public sealed class ProductQuery : IRequest<List<ProductsDto>>
{
    public double? MinimumPrice { get; set; }
    public double? MaximumPrice { get; set; }
    public int? MinimumStock { get; set; }
    public int? MaximumStock { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    
}