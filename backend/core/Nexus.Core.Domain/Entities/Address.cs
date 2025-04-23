using Nexus.Core.Domain.Entities.Base;

namespace Nexus.Core.Domain.Entities;

public sealed class Address(
    string street,
    string number,
    string complement,
    string neighborhood,
    string city,
    string state,
    string country,
    string zipcode
) : EntityCompanyBase
{
    public string Street { get; init; } = street;
    public string Number { get; init; } = number;
    public string Complement { get; init; } = complement;
    public string Neighborhood { get; init; } = neighborhood;
    public string City { get; init; } = city;
    public string State { get; init; } = state;
    public string Country { get; init; } = country;
    public string ZipCode { get; init; } = zipcode;
}