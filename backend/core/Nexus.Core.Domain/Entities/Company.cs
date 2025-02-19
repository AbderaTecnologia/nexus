namespace Nexus.Core.Domain.Entities;

public abstract class Company
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
}