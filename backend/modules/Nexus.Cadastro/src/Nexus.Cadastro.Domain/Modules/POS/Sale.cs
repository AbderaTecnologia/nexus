using Nexus.Core.Domain.Entities.Base;

namespace Nexus.Cadastro.Domain.Modules.POS;

public class Sale : EntityCompanyBase
{
    public Sale(
        Guid customerId,
        Guid financialAccountId,
        decimal totalAmount,
        string paymentMethod,
        DateTime saleDate
    )
    {
        CustomerId = customerId;
        FinancialAccountId = financialAccountId;
        TotalAmount = totalAmount;
        PaymentMethod = paymentMethod;
        SaleDate = saleDate;
    }

    public Sale()
    {
    }
    
    public Guid SallerId { get; private set; } = Guid.Empty;
    public Guid CustomerId { get; private set; } = Guid.Empty;
    public Guid FinancialAccountId { get; private set; } = Guid.Empty;
    public decimal TotalAmount { get; private set; }
    public string PaymentMethod { get; private set; } = string.Empty;
    public DateTime SaleDate { get; private set; }
    public ICollection<SaleItem> SaleItems { get; private set; } = [];
}