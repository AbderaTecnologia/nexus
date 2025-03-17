namespace Nexus.Cadastro.Domain.Entities;

public class Endereco
{
    public Guid EnderecoId { get; set; } 
    public string Cep { get; set; }
    public string Rua { get; set; }
    public string Numero { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }

    public  Endereco()
    {
        EnderecoId = Guid.NewGuid();
    }
    public Endereco (string cep, string rua, string numero, 
        string bairro, string cidade, string estado)
    {
        EnderecoId = Guid.NewGuid();
        Cep = cep;
        Rua = rua;
        Numero = numero;
        Bairro = bairro;
        Cidade = cidade;
        Estado = estado;
    }
}
