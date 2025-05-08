using Nexus.Cadastro.Application.Models.Dtos;
using Nexus.Cadastro.Domain.Entities;

namespace Nexus.Cadastro.Application.Queries;

public class ProdutosQueryHandler : IRequestHandler<ProdutosQuery, List<ProdutoDto>>
{
  public readonly IProdutoRepository _repository;

  public ProdutosQueryHandler(IProdutoRepository repository)
  {
    _repository = repository;
  }

  public async Task<List<ProdutoDto>> Handle(ProdutosQuery request, CancellationToken cancellationToken)
  {
    var produtos = await _repository.ProdutosAsync(request.Nome);


    return produtos.Select(p => new ProdutoDto
    {
      Id = p.Id,
      Nome = p.Nome,
      Descricao = p.Descricao,
      Preco = p.Preco,
      Estoque = p.Estoque
    }).ToList();

    return ProdutoDto;
  }

}
