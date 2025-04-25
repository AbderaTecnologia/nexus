namespace Nexus.Core.Domain.Entities.Interfaces;

public interface IIndividual
{
    string? CPF { get; }
    DateTime? DateOfBirth { get; }
}