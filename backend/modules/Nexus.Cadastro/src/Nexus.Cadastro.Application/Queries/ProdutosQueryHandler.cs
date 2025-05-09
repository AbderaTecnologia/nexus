using Nexus.Cadastro.Application.Models.Dtos;
using Nexus.Cadastro.Domain.Entities;
using Nexus.Cadastro.Infra.Repositories;

namespace Nexus.Cadastro.Application.Queries;

public class ProdutosQueryHandler : IRequestHandler<ProdutosQuery, List<ProdutoDto>>
{
  public readonly IProdutoRepository Repository;

  public ProdutosQueryHandler(IProdutoRepository repository)
  {
    Repository = repository;
  }
  public Task<List<ProdutoDto>> Handle(ProdutosQuery request, CancellationToken cancellationToken)
  {
    var query = Repository.Query();

    if (!string.IsNullOrWhiteSpace(request.Categoria))
      query = query.Where(p => p.Categoria == request.Categoria);

    if (request.PrecoMinimo.HasValue)
      query = query.Where(p => p.Preco >= request.PrecoMinimo.Value);

    if (request.PrecoMaximo.HasValue)
      query = query.Where(p => p.Preco >= request.PrecoMaximo.Value);
    
    if(request.EstoqueMinimo.HasValue)
      query = query.Where(p => p.Estoque >= request.EstoqueMinimo.Value);
    
    if(request.EstoqueMaximo.HasValue)
      query = query.Where(p => p.Estoque <= request.EstoqueMaximo.Value);

    return Task.FromResult(query
      .Skip((request.PageNumber -1) * request.PageSize).Take(request.PageSize).ToList());
  }

}
