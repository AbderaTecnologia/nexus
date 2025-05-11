using Nexus.Cadastro.Infra.Persistence;

namespace Nexus.Cadastro.Application.Handlers.Products.Update;

public sealed class UpdateProductCommandHandler(CadastroDbContext cadastroDbContext) : IRequestHandler<UpdateProductCommand, IResult>
{
    public async Task<IResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await cadastroDbContext.Products.FindAsync([request.Id], cancellationToken: cancellationToken);

        if (product == null)
        {
            return NotFound();
        }

        product.Update(
            request.Name,
            request.Description,
            request.Barcode,
            request.UnitOfMeasure,
            request.Price,
            request.CostPrice
        );

        cadastroDbContext.Products.Update(product);
        await cadastroDbContext.SaveChangesAsync(cancellationToken);

        return Ok(product);
    }
}