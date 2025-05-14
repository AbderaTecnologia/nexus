using System.Data.Entity;
using Nexus.Cadastro.Application.Models;
using Nexus.Cadastro.Infra.Persistence;

namespace Nexus.Cadastro.Application.Handlers.Produtos.List;

public sealed record ListProdutosQuery : IRequest<IResult>;

public class ListProdutoQueryHandler(CadastroDbContext cadastroDbContext) : IRequestHandler<ListProdutosQuery, IResult>
{
    public async Task<IResult> Handle(ListProdutosQuery request, CancellationToken cancellationToken)
    {
        var produtos = await cadastroDbContext.Produtos
            .AsNoTracking().Select(c => new ProdutoViewModel
            {
                Id = c.Id,
                Nome = c.Nome,
                Descricao = c.Descricao,
                Preco = c.Preco,
                Estoque = c.Estoque,

            })
            .ToListAsync(cancellationToken);
        return Results.Ok(produtos);
    }
}