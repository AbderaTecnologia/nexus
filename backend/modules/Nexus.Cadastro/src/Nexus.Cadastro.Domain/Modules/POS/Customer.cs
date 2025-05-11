using Nexus.Core.Domain.Entities.Base;
using Nexus.Core.Domain.Entities.Interfaces;

namespace Nexus.Cadastro.Domain.Modules.POS;

public class Customer : EntityCompanyBase, IPerson
{
    public Customer(
        string name,
        string email,
        string phoneNumber,
        string? cpf = null,
        DateTime? dateOfBirth = null,
        string? cnpj = null,
        string? companyName = null
    )
    {
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
        CPF = cpf;
        DateOfBirth = dateOfBirth;
        CNPJ = cnpj;
        CompanyName = companyName;
    }

    public Customer()
    {
    }

    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string PhoneNumber { get; private set; } = string.Empty;

    // Pessoa Física
    public string? CPF { get; private set; }
    public DateTime? DateOfBirth { get; private set; }

    // Pessoa Jurídica
    public string? CNPJ { get; private set; }
    public string? CompanyName { get; private set; }

    public ICollection<Sale> Sales { get; private set; } = [];
    public ICollection<DeliveryAddress> DeliveryAddresses { get; private set; } = [];

    public void UpdateContactInfo(string email, string phoneNumber)
    {
        Email = email;
        PhoneNumber = phoneNumber;
    }

    public void Update(
        string name,
        string? cpf,
        DateTime? dateOfBirth,
        string? cnpj,
        string? companyName
    )
    {
        Name = name;
        CPF = cpf;
        DateOfBirth = dateOfBirth;
        CNPJ = cnpj;
        CompanyName = companyName;
    }

    public void AddDeliveryAddress(DeliveryAddress address)
    {
        DeliveryAddresses.Add(address);
    }

    public bool IsIndividual => !string.IsNullOrEmpty(CPF);
    public bool IsLegalEntity => !string.IsNullOrEmpty(CNPJ);
}