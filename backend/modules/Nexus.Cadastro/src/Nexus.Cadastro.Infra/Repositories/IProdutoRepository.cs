namespace Nexus.Cadastro.Infra.Repositories;

public interface IProdutoRepository
{
    IQueryable<Produto> Query();
}