namespace Nexus.Core.Domain.Entities;

public abstract class Company
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
}

public class Contabilidade : Company
{
    public ICollection<Cliente> Clientes { get; set; } = [];
}

public class Cliente : Company
{
    public Guid ContabilidadeId { get; set; }
    public Contabilidade Contabilidade { get; set; } = null!;
    public string Identifier { get; init; } = string.Empty; // CPF or CNPJ
}