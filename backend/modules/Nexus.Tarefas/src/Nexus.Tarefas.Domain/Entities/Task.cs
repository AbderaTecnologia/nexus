namespace Nexus.Tarefas.Domain.Entities;

public class Task
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    
    public string Progress { get; set; }

    public Guid AssingneId { get; set; }
    public Member? Assinee { get; set; }
    
    public string Priority { get; set; }
    
    public DateTime DueDate { get; set; }
    
    public Boolean Checked { get; set; }
}