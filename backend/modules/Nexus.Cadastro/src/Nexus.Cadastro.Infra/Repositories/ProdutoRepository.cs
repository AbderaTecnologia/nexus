namespace Nexus.Cadastro.Infra.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly List<Produto> _produtos;

    public ProdutoRepository()
    {
        _produtos = new List<Produto>()
        {
            new Produto { Id = Guid.NewGuid(), 
                Nome = "Camisa", Descricao = "Camisa de Algodão",
                Preco = 190, Estoque = 10,}
            };
        }
    public IQueryable<Produto> Query()
    {
        return _produtos.AsQueryable();
    }
}
