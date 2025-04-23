using Nexus.Core.Domain.Entities;

namespace Nexus.Cadastro.Domain.Entities;

public class AccountingTenant : Company
{
    public ICollection<CompanyTenant> Clientes { get; set; } = [];
}