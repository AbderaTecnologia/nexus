using Nexus.Folha.Application.Common.Interfaces;
using Nexus.Folha.Domain.Entities;

namespace Nexus.Folha.Infra;

public class FolhaDbContext(DbContextOptions<ApplicationDbContext> options) : ApplicationDbContext(options), IFolhaDbContext
{
    public DbSet<Funcionario> Funcionarios => Set<Funcionario>();

    public DbSet<Rescisao> Rescisao => Set<Rescisao>();
}