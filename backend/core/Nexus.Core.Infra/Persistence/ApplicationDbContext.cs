namespace Nexus.Core.Infra.Persistence;

public abstract class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{

}