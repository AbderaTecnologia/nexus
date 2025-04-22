using Nexus.Core.Domain.Entities.Base;

namespace Nexus.Cadastro.Domain.Entities;

public sealed class Address(AddressDetails details) : EntityCompanyBase
{
    public string Street { get; init; } = details.Street;
    public string Number { get; init; } = details.Number;
    public string Complement { get; init; } = details.Complement;
    public string Neighborhood { get; init; } = details.Neighborhood;
    public string City { get; init; } = details.City;
    public string State { get; init; } = details.State;
    public string Country { get; init; } = details.Country;
    public string ZipCode { get; init; } = details.ZipCode;
}

public record AddressDetails(
    string Street,
    string Number,
    string Complement,
    string Neighborhood,
    string City,
    string State,
    string Country,
    string ZipCode
);