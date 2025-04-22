using Nexus.Core.Domain.Entities;

namespace Nexus.Cadastro.Domain.Entities;

public class Contabilidade : Company
{
    public ICollection<CompanyTenent> Clientes { get; set; } = [];
}