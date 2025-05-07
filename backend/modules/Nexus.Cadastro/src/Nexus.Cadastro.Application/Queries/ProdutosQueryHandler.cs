using Nexus.Cadastro.Domain.Entities;

namespace Nexus.Cadastro.Application.Queries;

public class ProdutosQueryHandler : IRequestHandler<ProdutosQuery, IEnumerable<Produto>>
{
  private readonly IProdutoRepository _produtoRepository; 
  
  public ProdutosQueryHandler(IProdutoRepository repository)
  {
    _repository = repository;
  }
  
  
}
