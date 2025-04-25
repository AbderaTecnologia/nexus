using Nexus.Core.Domain.Entities.Base;

namespace Nexus.Cadastro.Domain.Modules.Inventory;

public class Stock : EntityBase
{
    public Stock(Guid productId, Guid warehouseId, int quantity)
    {
        ProductId = productId;
        WarehouseId = warehouseId;
        Quantity = quantity;
    }

    public Stock()
    {
    }

    public Guid ProductId { get; private set; }
    public Product Product { get; private set; } = null!;
    public Guid WarehouseId { get; private set; }
    public Warehouse Warehouse { get; private set; } = null!;
    public int Quantity { get; private set; }

    public void UpdateQuantity(int quantity)
    {
        Quantity = quantity;
    }
}