using Nexus.Core.Domain.Entities.Base;
using Nexus.Core.Domain.Entities.Interfaces;

namespace Nexus.Cadastro.Domain.Modules.Inventory;

public class Product : EntityCompanyBase, IActivatable
{
    public Product(
        string name,
        string description,
        string barcode,
        string unitOfMeasure,
        decimal price,
        decimal costPrice
    )
    {
        Name = name;
        Description = description;
        Barcode = barcode;
        UnitOfMeasure = unitOfMeasure;
        Price = price;
        CostPrice = costPrice;
    }

    public Product()
    {
    }

    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public string Barcode { get; private set; } = string.Empty;
    public string UnitOfMeasure { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public decimal CostPrice { get; private set; }
    public bool IsActive { get; private set; } = true;

    public ICollection<Stock> Stocks { get; private set; } = [];

    public void Deactivate()
    {
        IsActive = false;
    }

    public void Activate()
    {
        IsActive = true;
    }

    public void UpdatePrice(decimal newPrice)
    {
        Price = newPrice;
    }

    public void UpdateCostPrice(decimal newCostPrice)
    {
        CostPrice = newCostPrice;
    }
}