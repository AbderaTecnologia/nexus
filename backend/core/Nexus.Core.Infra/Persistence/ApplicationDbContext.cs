namespace Nexus.Core.Infra.Persistence;

public abstract class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public const object Produtos = VALUE;
}