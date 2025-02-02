using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nexus.Tarefas.Infra.Persistence;

namespace Nexus.Tarefas.Infra.Data.Connection;

public static class DatabaseConnection
{
    public static IServiceCollection AddTarefasDatabase(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var connectionString = configuration.GetConnectionString("TarefasPostgresConnection");

        services.AddDbContext<TarefasDbContext>(options =>
            options.UseNpgsql(connectionString));

        return services;
    }
}