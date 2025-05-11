namespace Nexus.Cadastro.Application.Handlers.Products.Create;

public sealed record CreateProductCommand(
    string Name,
    string Description,
    string Barcode,
    string UnitOfMeasure,
    decimal Price,
    decimal CostPrice
) : IRequest<IResult>;