using Nexus.Core.Domain.Entities;
using Nexus.Core.Domain.Entities.Interfaces;

namespace Nexus.Cadastro.Domain.Entities;

public class Cliente : Company, ICustomerCompany
{
    public Guid ContabilidadeId { get; set; }
    public Contabilidade Contabilidade { get; set; } = null!;
    public string Identifier { get; init; } = string.Empty; // CPF or CNPJ
    public Guid EnderecoId { get; set; }
    public Endereco Endereco { get; set; } 
    
    public string Telefone { get; set; }
}