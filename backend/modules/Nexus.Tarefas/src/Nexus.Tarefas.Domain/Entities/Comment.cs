namespace Nexus.Tarefas.Domain.Entities;

public class Comment
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }    
    
    public string Massage { get; set; }
    
    public DateTime Date { get; set; }
}