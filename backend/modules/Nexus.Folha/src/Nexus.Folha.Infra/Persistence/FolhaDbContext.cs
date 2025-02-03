using Microsoft.EntityFrameworkCore;

namespace Nexus.Folha.Infra.Persistence;

public class FolhaDbContext(DbContextOptions<FolhaDbContext> options) : DbContext(options)
{

    // Defina seus DbSets aqui
    // public DbSet<YourEntity> YourEntities { get; set; }
}