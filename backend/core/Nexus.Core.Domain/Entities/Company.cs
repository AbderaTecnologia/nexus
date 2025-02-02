using Nexus.Core.Domain.Enum;

namespace Nexus.Core.Domain.Entities;

public sealed class Company
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public CompanyType Type { get; init; }
}