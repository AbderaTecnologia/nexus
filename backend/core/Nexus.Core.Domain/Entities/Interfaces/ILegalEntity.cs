namespace Nexus.Core.Domain.Entities.Interfaces;

public interface ILegalEntity
{
    string? CNPJ { get; }
    string? CompanyName { get; }
}