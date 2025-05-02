using Nexus.Cadastro.Domain.Modules.Inventory;
using Nexus.Cadastro.Infra.Persistence;

namespace Nexus.Cadastro.Application.Handlers.Products.Create;

public sealed class CreateProductCommandHandler(CadastroDbContext _context) : IRequestHandler<CreateProductCommand, IResult>
{
    public async Task<IResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product(
            request.Name,
            request.Description,
            request.Barcode,
            request.UnitOfMeasure,
            request.Price,
            request.CostPrice
        );

        _context.Products.Add(product);
        await _context.SaveChangesAsync(cancellationToken);

        return Created($"{product.Id}", new { ProductId = product.Id });
    }
}