using Microsoft.EntityFrameworkCore.Design;

namespace Nexus.Cadastro.Infra.Persistence;

public class CadastroDbContextFactory : IDesignTimeDbContextFactory<CadastroDbContext>
{
    public CadastroDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<CadastroDbContext>();
        optionsBuilder.UseNpgsql(configuration.GetConnectionString("CadastroPostgresConnection"));

        var interceptor = new AuditableEntityInterceptor();
        return new CadastroDbContext(optionsBuilder.Options, interceptor);
    }
}