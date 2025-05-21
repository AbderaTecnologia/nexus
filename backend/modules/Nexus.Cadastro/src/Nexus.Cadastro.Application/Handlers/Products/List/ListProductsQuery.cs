using System.Data.Entity;
using Nexus.Cadastro.Application.Models;
using Nexus.Cadastro.Infra.Persistence;

namespace Nexus.Cadastro.Application.Handlers.Products.List;

public sealed record ListProductsQuery : IRequest<IResult>;

public class ListProdutoQueryHandler(CadastroDbContext cadastroDbContext) : IRequestHandler<ListProductsQuery, IResult>
{
    public async Task<IResult> Handle(ListProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await cadastroDbContext.Products
            .AsNoTracking().Select(c => new ProductViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                Price = c.Price,
                Stock = c.Stock,

            })
            .ToListAsync(cancellationToken);
        return Results.Ok(products);
    }
}