using Nexus.Cadastro.Domain.Entities;
using Nexus.Cadastro.Infra.Persistence;

namespace Nexus.Cadastro.Application.Handlers.Produtos.List;

public sealed record ListProdutoQuery : IRequest<IResult>;

public class ListProdutoQueryHandler(CadastroDbContext cadastroDbContext) : IRequestHandler<ListProdutoQuery, IResult>
{
    public Task<IResult> Handle(ListProdutoQuery request, CancellationToken cancellationToken)
    {
        var Produtos = cadastroDbContext.Produto
    }
}