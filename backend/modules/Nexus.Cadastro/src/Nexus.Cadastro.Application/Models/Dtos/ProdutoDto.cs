namespace Nexus.Cadastro.Application.Models.Dtos;

public class ProdutoDto
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public double Preco { get; set; }
    public int Estoque { get; set; }
}