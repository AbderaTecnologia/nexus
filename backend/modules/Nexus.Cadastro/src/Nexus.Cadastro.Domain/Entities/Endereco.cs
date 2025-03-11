namespace Nexus.Cadastro.Domain.Entities;

public class Endereco
{
    public Guid EnderecoId { get; set; } 
    public Cliente Cliente { get; set; }
    int cep;
    string rua;
    int numero;
    string bairro;
    string cidade;
    string estado;
  
}
