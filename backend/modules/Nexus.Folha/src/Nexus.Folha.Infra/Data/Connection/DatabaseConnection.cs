using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Nexus.Folha.Infra.Persistence;

namespace Nexus.Folha.Infra.Data.Connection;

public static class DatabaseConnection
{
    public static IServiceCollection AddFolhaDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("FolhaPostgresConnection");

        services.AddDbContext<FolhaDbContext>(options =>
            options.UseNpgsql(connectionString));

        return services;
    }
}