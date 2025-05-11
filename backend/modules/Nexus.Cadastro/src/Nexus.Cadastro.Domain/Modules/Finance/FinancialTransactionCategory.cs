using Nexus.Core.Domain.Entities.Base;

namespace Nexus.Cadastro.Domain.Modules.Finance;

public sealed class FinancialTransactionCategory : EntityCompanyBase
{
    public FinancialTransactionCategory(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public FinancialTransactionCategory()
    {
    }

    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public bool IsActive { get; private set; } = true;
}