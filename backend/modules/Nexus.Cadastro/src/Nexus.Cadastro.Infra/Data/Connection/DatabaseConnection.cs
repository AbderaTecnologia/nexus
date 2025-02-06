using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Nexus.Cadastro.Infra.Persistence;

namespace Nexus.Cadastro.Infra.Data.Connection
{
    public static class DatabaseConnectionExtensions
    {
        public static IServiceCollection AddCadastroDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("CadastroPostgresConnection");

            services.AddDbContext<CadastroDbContext>(options =>
                options.UseNpgsql(connectionString));

            return services;
        }
    }
}