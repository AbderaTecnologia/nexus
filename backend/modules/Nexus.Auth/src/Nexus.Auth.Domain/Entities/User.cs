namespace Nexus.Auth.Domain.Entities;

public class User(
    string username,
    Guid companyId
)
{
    public int Id { get; init; }
    public string Username { get; init; } = Guard.Against.NullOrEmpty(username, nameof(username));
    public string? Password { get; private set; }
    public Guid CompanyId { get; init; } = Guard.Against.Default(companyId, nameof(companyId));

    public void SetHashPassword(string passwordHasher)
    {
        Password = Guard.Against.NullOrEmpty(passwordHasher, nameof(passwordHasher));
    }
}