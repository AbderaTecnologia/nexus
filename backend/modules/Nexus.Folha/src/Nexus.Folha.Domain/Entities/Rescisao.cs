namespace Nexus.Folha.Domain.Entities;

public class Rescisao
{
    public int FuncionarioId { get; set; }
    
    public DateTime DataRecisao { get; set; }
    
    public string TipoDesligamento { get; set; }
    
    public string TipoAviso { get; set; }
    
    public string Apontamento { get; set; }
}