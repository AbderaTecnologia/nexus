using Nexus.Core.Domain.Entities.Base;

namespace Nexus.Cadastro.Domain.Entities;

public sealed class Produto : EntitySoftDeletedBase
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public double Preco { get; set; }
    public int Estoque { get; set; }
    public string Descricao { get; set; }
    
}