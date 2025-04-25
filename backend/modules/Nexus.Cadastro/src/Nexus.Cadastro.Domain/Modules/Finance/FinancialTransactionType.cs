using Nexus.Core.Domain.Entities.Base;

namespace Nexus.Cadastro.Domain.Modules.Finance;

public sealed class FinancialTransactionType : EntityCompanyBase
{
    public FinancialTransactionType(string name, string description, bool isDefault = false)
    {
        Name = name;
        Description = description;
        IsDefault = isDefault;
    }

    public FinancialTransactionType()
    {
    }

    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public bool IsActive { get; private set; } = true;

    public bool IsDefault { get; private set; }
}