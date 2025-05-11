using Nexus.Core.Domain.Entities.Base;

namespace Nexus.Cadastro.Domain.Modules.Finance;

public class FinancialAccount : EntityCompanyBase
{
    public FinancialAccount(string name, string description, string bank, string agency, string accountNumber, string accountType)
    {
        Name = name;
        Description = description;
        Bank = bank;
        Agency = agency;
        AccountNumber = accountNumber;
        AccountType = accountType;
    }

    public FinancialAccount()
    {
    }

    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public string Bank { get; private set; } = string.Empty;
    public string Agency { get; private set; } = string.Empty;
    public string AccountNumber { get; private set; } = string.Empty;
    public string AccountType { get; private set; } = string.Empty;
}