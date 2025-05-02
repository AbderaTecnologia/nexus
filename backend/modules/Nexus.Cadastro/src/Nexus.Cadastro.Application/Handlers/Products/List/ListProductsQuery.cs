namespace Nexus.Cadastro.Application.Handlers.Products.List;

public sealed record ListProductsQuery : IRequest<IEnumerable<ProductViewModel>>;