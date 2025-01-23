namespace Nexus.Tarefas.Domain.Entities;

public class Comment
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }    
    
    public string Message { get; set; }
    
    public DateTime Date { get; set; }
}