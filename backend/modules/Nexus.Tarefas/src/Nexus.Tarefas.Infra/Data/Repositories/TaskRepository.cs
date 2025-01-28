using System.Data;
using DapperExtensions;
using Microsoft.Extensions.Logging;
using Task = Nexus.Tarefas.Domain.Entities.Task;

namespace Nexus.Tarefas.Infra.Data.Repositories;

public sealed class TaskRepository(ILogger<TaskRepository> logger, IDbConnection connection) : ITaskRepository
{
    public async Task<bool?> Create(Task task)
    {
        try
        {
            await connection.InsertAsync(task);
            return true;
        }
        catch (Exception e)
        {
            logger.LogError(e,"");
            return null;
        }
    }

    public Task<IEnumerable<Task>> GetAll()
    {
        try
        {
            return connection.GetListAsync<Task>();

        }
        catch (Exception e)
        {
            logger.LogError(e,"");
            return null;
        }
    }

    
    public async Task<Task> GetById(Guid id)
    {
        try
        { 
            return await connection.GetAsync<Task>(id.ToString());
        }
        catch (Exception e)
        {
            logger.LogError(e,"");
            return null;
        }
    }


    public async Task<bool?> Delete(Guid id)
    {
        try
        {
            var task = new Task
            {
                Id = id
            };

        }
        catch (Exception e)
        {
            logger.LogError(e,"" );
            return null;
        }

        return null;
    }

}