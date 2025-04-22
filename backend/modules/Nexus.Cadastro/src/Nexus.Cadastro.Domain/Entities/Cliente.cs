using Nexus.Core.Domain.Entities;
using Nexus.Core.Domain.Entities.Interfaces;

namespace Nexus.Cadastro.Domain.Entities;

public sealed class Cliente : Company, ICustomerCompany
{
    public Guid ContabilidadeId { get; set; }
    public Contabilidade Contabilidade { get; set; } = null!;
    public string Identifier { get; init; } = string.Empty; // CPF or CNPJ
    public Guid AddressId { get; set; }
    public Address Address { get; set; }
    public string AvatarUrl { get; init; } = string.Empty;
}