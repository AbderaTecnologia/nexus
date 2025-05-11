using Nexus.Core.Domain.Entities.Base;

namespace Nexus.Cadastro.Domain.Modules.Inventory;

public class Warehouse : EntityCompanyBase
{
    public Warehouse(string name, string address)
    {
        Name = name;
        Address = address;
    }

    public Warehouse()
    {
    }

    public string Name { get; private set; } = string.Empty;
    public string Address { get; private set; } = string.Empty;
    public ICollection<Stock> Stocks { get; private set; } = [];
}