using Nexus.Core.Domain.Entities.Base;

namespace Nexus.Cadastro.Domain.Entities
{
    public sealed class Address : EntityCompanyBase
    {
        public Address(
            string street,
            string number,
            string complement,
            string neighborhood,
            string city,
            string state,
            string country,
            string zipcode
        )
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
        
        public string Street { get; init; } = string.Empty;
        public string Number { get; init; } = string.Empty;
        public string Complement { get; init; } = string.Empty;
        public string Neighborhood { get; init; } = string.Empty;
        public string City { get; init; } = string.Empty;
        public string State { get; init; } = string.Empty;
        public string Country { get; init; } = string.Empty;
        public string ZipCode { get; init; } = string.Empty;
    }
}