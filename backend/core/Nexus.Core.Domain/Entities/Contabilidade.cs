namespace Nexus.Core.Domain.Entities;

public class Contabilidade : Company
{
    public ICollection<Cliente> Clientes { get; set; } = [];
}