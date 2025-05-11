using Nexus.Core.Domain.Entities.Base;

namespace Nexus.Cadastro.Domain.Modules.POS;

public class SaleItem : EntityBase
{
    public SaleItem(Guid saleId, Guid productId, decimal unitPrice, int quantity)
    {
        SaleId = saleId;
        ProductId = productId;
        UnitPrice = unitPrice;
        Quantity = quantity;
    }

    public SaleItem()
    {
    }

    public Guid SaleId { get; private set; } = Guid.Empty;
    public Guid ProductId { get; private set; } = Guid.Empty;
    public decimal UnitPrice { get; private set; }
    public int Quantity { get; private set; }
}