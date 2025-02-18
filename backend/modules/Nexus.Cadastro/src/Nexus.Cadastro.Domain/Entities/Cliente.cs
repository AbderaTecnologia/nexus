using Nexus.Core.Domain.Entities;

namespace Nexus.Cadastro.Domain.Entities;

public class Cliente : Company
{
    public Guid ContabilidadeId { get; set; }
    public Contabilidade Contabilidade { get; set; } = null!;
    public string Identifier { get; init; } = string.Empty; // CPF or CNPJ
}