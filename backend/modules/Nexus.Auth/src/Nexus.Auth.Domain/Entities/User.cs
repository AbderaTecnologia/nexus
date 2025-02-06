namespace Nexus.Auth.Domain.Entities;

public sealed class User
{
    public int Id { get; init; }
    public required string Username { get; init; }
    public required string Password { get; init; }
    public required Guid CompanyId { get; init; }
}