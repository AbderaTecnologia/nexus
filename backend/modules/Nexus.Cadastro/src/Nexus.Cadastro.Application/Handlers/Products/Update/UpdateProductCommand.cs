namespace Nexus.Cadastro.Application.Handlers.Products.Update;

public sealed record UpdateProductCommand : IRequest<IResult>
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string Barcode { get; init; } = string.Empty;
    public string UnitOfMeasure { get; init; } = string.Empty;
    public decimal Price { get; init; }
    public decimal CostPrice { get; init; }
}