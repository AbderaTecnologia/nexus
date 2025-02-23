namespace Nexus.Cadastro.Application.Models;

public sealed class ClienteViewModel
{
    public Guid Id { get; init; }
    public string Type { get; init; } = string.Empty;
    public string CpfCnpj { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Phone { get; init; } = string.Empty;
}