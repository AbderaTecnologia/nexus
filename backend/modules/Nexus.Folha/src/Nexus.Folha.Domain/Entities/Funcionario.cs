using System.Security.Cryptography.X509Certificates;

namespace Nexus.Folha.Domain.Entities;

public class Funcionario
{
    public int Id { get; set; } 
        
    public string NomeCompleto { get; set; }
    
    public string DataNascimento { get; set; }
    
    public string NomePai { get; set; }
    
    public string NomeMae { get; set; }

    public  string Cep { get; set; }
    
    public string Endereço { get;set; }                                             

    public string Cidade { get; set; }
    
    public string UF { get; set; }

    public string LocalNasimento { get; set; }

    public string Telefone { get; set; }
    
    public string NomeConjuge { get; set; }

}

