using Nexus.Core.Domain.Entities.Base;

namespace Nexus.Cadastro.Domain.Modules.Inventory;

public sealed class StockAdjustment : EntityBase
{
    public StockAdjustment(
        Guid stockId,
        Guid stockAdjustmentTypeId,
        decimal quantity,
        string description
    )
    {
        StockId = stockId;
        StockAdjustmentTypeId = stockAdjustmentTypeId;
        Quantity = quantity;
        Description = description;
    }

    public StockAdjustment()
    {
    }

    public Guid StockId { get; private set; } = Guid.Empty;
    public Guid StockAdjustmentTypeId { get; private set; } = Guid.Empty;
    public decimal Quantity { get; private set; }
    public string Description { get; private set; } = string.Empty;
}