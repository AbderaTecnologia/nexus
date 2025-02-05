using Microsoft.EntityFrameworkCore;
using Nexus.Folha.Domain.Entities;

namespace Nexus.Folha.Infra.Persistence;

public class FolhaDbContext(DbContextOptions<FolhaDbContext> options) : DbContext(options)
{
    public DbSet<Funcionario> Funcionarios { get; set; }
}