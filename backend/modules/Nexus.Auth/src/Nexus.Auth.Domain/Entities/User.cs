namespace Nexus.Auth.Domain.Entities;

public class User
{
    public int Id { get; init; }
    public string Username { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
    public Guid CompanyId { get; init; }
}