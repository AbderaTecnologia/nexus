namespace Nexus.Core.Domain.Entities.Interfaces;

public interface IPerson : IIndividual, ILegalEntity
{
    string Name { get; }
    string Email { get; }
    string PhoneNumber { get; }
}