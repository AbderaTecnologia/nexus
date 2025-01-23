namespace Nexus.Tarefas.Domain.Entities;

public class Group
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }
    
    public IEnumerable<Task> Tasks { get; set; }
}