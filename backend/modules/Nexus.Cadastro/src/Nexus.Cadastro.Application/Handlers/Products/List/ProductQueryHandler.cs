using System.Data.Entity;
using Nexus.Cadastro.Application.Models.Dtos;
using Nexus.Cadastro.Infra.Persistence;

namespace Nexus.Cadastro.Application.Handlers.Products.List;

public class ProductQueryHandler : IRequestHandler<ProductQuery, List<ProductsDto>>
{
    private readonly CadastroDbContext _context;

    public ProductQueryHandler(CadastroDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProductsDto>> Handle(ProductQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Products.AsNoTracking().AsQueryable();

        if (request.MinimumPrice.HasValue)
            query = query.Where(p => p.Price >= request.MinimumPrice.Value);

        if (request.MaximumPrice.HasValue)
            query = query.Where(p => p.Price <= request.MaximumPrice.Value);

        if (request.MinimumStock.HasValue)
            query = query.Where(p => p.Stock >= request.MinimumStock.Value);

        if (request.MaximumStock.HasValue)
            query = query.Where(p => p.Stock <= request.MaximumStock.Value);

        var products = query
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToList();

        var productsDto = products.Select(p => new ProductsDto(
            p.Id,
            p.Name,
            p.Price,
            p.Stock,
            p.Description
        )).ToList();

        return await Task.FromResult(productsDto);
    }
}