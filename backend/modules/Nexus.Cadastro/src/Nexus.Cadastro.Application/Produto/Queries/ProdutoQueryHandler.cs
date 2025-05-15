using Microsoft.EntityFrameworkCore;
using Nexus.Cadastro.Application.Models.Dtos;
using Nexus.Cadastro.Infra.Persistence;

namespace Nexus.Cadastro.Application.Produto.Queries;

public class ProdutoQueryHandler : IRequestHandler<ProdutoQuery, List<ProdutosDto>>
{
  private readonly CadastroDbContext _context;

  public ProdutoQueryHandler(CadastroDbContext context)
  {
    _context = context;
  }

  public async Task<List<ProdutosDto>> Handle(ProdutoQuery request, CancellationToken cancellationToken)
  {
    var query = _context.Produtos.AsNoTracking().AsQueryable();

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

    var produtosDto = produtos.Select(p => new ProdutosDto(
    
      p.Id,
      p.Nome,
      p.Preco,
      p.Estoque,
      p.Descricao
    )).ToList();
    
    return await Task.FromResult(produtosDto);
  }
}