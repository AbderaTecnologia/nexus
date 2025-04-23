using Nexus.Core.Domain.Entities;
using Nexus.Core.Domain.Entities.Interfaces;

namespace Nexus.Cadastro.Domain.Entities;

public class CompanyTenant : Company, ICustomerCompany
{
    public Guid ContabilidadeId { get; set; }
    public AccountingTenant Contabilidade { get; set; } = null!;
    public string Identifier { get; init; } = string.Empty;
    public string AvatarUrl { get; init; } = string.Empty;
}