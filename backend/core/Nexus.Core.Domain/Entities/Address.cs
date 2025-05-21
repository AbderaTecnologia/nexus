using Nexus.Core.Domain.Entities.Base;

namespace Nexus.Core.Domain.Entities;

public sealed class Address : EntityCompanyBase
{
    public Address()
    {
        
    }

    public Address(string street,
        string number,
        string complement,
        string neighborhood,
        string city,
        string state,
        string country,
        string zipcode)
    {
        Street = street;
        Number = number;
        Complement = complement;
        Neighborhood = neighborhood;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipcode;
    }

    public string Street { get; init; }
    public string Number { get; init; }
    public string Complement { get; init; }
    public string Neighborhood { get; init; }
    public string City { get; init; }
    public string State { get; init; }
    public string Country { get; init; }
    public string ZipCode { get; init; }
}