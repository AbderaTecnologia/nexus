using Nexus.Cadastro.Domain.Entities;

namespace Nexus.Cadastro.Application.Queries;

public class ProdutosQuery : IRequest<IEnumerable<Produto>>
{
    public string Categoria { get; set; }
    public double PrecoMinimo { get; set; }
    public double PrecoMaximo { get; set; }
    public int EstoqueMinimo { get; set; }
    public int EstoqueMaximo { get; set; }
}