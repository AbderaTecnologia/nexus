using Nexus.Cadastro.Application.Models.Dtos;
using Nexus.Cadastro.Infra.Repositories;

namespace Nexus.Cadastro.Application.Produtos.Queries;

public class ProdutosQueryHandler : IRequestHandler<ProdutosQuery, List<ProdutoDto>>
{
  private readonly IProdutoRepository _repository;

  public ProdutosQueryHandler(IProdutoRepository repository)
  {
    _repository = repository;
  }

  public async Task<List<ProdutoDto>> Handle(ProdutosQuery request, CancellationToken cancellationToken)
  {
    var query = _repository.Query();

    if (request.PrecoMinimo.HasValue)
      query = query.Where(p => p.Preco >= request.PrecoMinimo.Value);

    if (request.PrecoMaximo.HasValue)
      query = query.Where(p => p.Preco <= request.PrecoMaximo.Value);

    if (request.EstoqueMinimo.HasValue)
      query = query.Where(p => p.Estoque >= request.EstoqueMinimo.Value);

    if (request.EstoqueMaximo.HasValue)
      query = query.Where(p => p.Estoque <= request.EstoqueMaximo.Value);

    var produtos = query
      .Skip((request.PageNumber - 1) * request.PageSize)
      .Take(request.PageSize)
      .ToList();

    var produtoDto = produtos.Select(p => new ProdutoDto
    {
      Id = p.Id,
      Nome = p.Nome,
      Preco = p.Preco,
      Estoque = p.Estoque,
      Descricao = p.Descricao,
    }).ToList();
    
    return await Task.FromResult(produtoDto);
  }
}