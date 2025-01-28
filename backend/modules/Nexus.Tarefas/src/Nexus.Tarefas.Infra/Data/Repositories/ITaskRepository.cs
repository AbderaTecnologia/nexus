using Task = Nexus.Tarefas.Domain.Entities.Task;

namespace Nexus.Tarefas.Infra.Data.Repositories;

public interface ITaskRepository
{
    Task<bool?> Create(Task task);
    Task<IEnumerable<Task>> GetAll();
    Task<Task?> GetById(Guid id);
    Task<bool?> Delete(Guid id);

}