using Nexus.Core.Domain.Entities.Base;

namespace Nexus.Cadastro.Domain.Modules.Finance;

public sealed class FinancialTransaction : EntityCompanyBase
{
    public FinancialTransaction(Guid financialTransactionTypeId, decimal amount, DateTime date, string description)
    {
        FinancialTransactionTypeId = financialTransactionTypeId;
        Amount = amount;
        Date = date;
        Description = description;
    }

    public FinancialTransaction()
    {
    }

    public Guid FinancialTransactionTypeId { get; private set; } = Guid.Empty;
    public FinancialTransactionType FinancialTransactionType { get; private set; } = null!;
    public Guid? FinancialTransactionCategoryId { get; private set; } = null;
    public FinancialTransactionCategory? FinancialTransactionCategory { get; private set; } = null;
    public Guid? FinancialTransactionSubCategoryId { get; private set; } = null;
    public FinancialTransactionSubCategory? FinancialTransactionSubCategory { get; private set; } = null;
    public decimal Amount { get; private set; }
    public DateTime Date { get; private set; }
    public string Description { get; private set; } = string.Empty;
}