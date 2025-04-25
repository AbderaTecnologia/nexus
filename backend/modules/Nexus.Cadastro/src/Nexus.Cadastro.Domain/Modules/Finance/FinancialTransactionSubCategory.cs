using Nexus.Core.Domain.Entities.Base;

namespace Nexus.Cadastro.Domain.Modules.Finance;

public sealed class FinancialTransactionSubCategory : EntityCompanyBase
{
    public FinancialTransactionSubCategory(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public FinancialTransactionSubCategory()
    {
    }

    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public bool IsActive { get; private set; } = true;
    public Guid FinancialTransactionCategoryId { get; private set; } = Guid.Empty;
    public FinancialTransactionCategory FinancialTransactionCategory { get; private set; } = null!;
}