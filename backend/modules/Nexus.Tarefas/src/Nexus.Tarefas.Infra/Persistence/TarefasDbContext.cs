using Microsoft.EntityFrameworkCore;

namespace Nexus.Tarefas.Infra.Persistence;

public class TarefasDbContext(DbContextOptions<TarefasDbContext> options) : DbContext(options)
{
    
}