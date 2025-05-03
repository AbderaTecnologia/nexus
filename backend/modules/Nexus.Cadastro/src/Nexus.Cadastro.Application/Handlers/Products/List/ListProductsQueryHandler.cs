using System.Data.Entity;
using Nexus.Cadastro.Infra.Persistence;

namespace Nexus.Cadastro.Application.Handlers.Products.List;

public sealed class ListProductsQueryHandler(CadastroDbContext _context) : IRequestHandler<ListProductsQuery, IResult>
{
    public async Task<IResult> Handle(ListProductsQuery request, CancellationToken cancellationToken)
    {
        var ListTenantsQuery = await _context.Products
            .Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                IsActive = p.IsActive
            }).ToListAsync(cancellationToken);

        return Ok(ListTenantsQuery);
    }
}