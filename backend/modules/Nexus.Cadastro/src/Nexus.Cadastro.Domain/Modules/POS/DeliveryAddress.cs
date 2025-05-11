using Nexus.Core.Domain.Entities.Base;

namespace Nexus.Cadastro.Domain.Modules.POS;

public class DeliveryAddress : EntityBase
{
    public DeliveryAddress(
        Guid customerId,
        string street,
        string city,
        string state,
        string postalCode,
        string country
    )
    {
        CustomerId = customerId;
        Street = street;
        City = city;
        State = state;
        PostalCode = postalCode;
        Country = country;
    }

    public DeliveryAddress()
    {
    }

    public Guid CustomerId { get; private set; }
    public Customer Customer { get; private set; } = null!;
    public string Street { get; private set; } = string.Empty;
    public string City { get; private set; } = string.Empty;
    public string State { get; private set; } = string.Empty;
    public string PostalCode { get; private set; } = string.Empty;
    public string Country { get; private set; } = string.Empty;

    public void UpdateAddress(
        string street,
        string city,
        string state,
        string postalCode,
        string country
    )
    {
        Street = street;
        City = city;
        State = state;
        PostalCode = postalCode;
        Country = country;
    }
}