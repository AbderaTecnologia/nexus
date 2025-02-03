using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Nexus.Auth.Infra.Persistence;

namespace Nexus.Auth.Infra.Data.Connection;

public static class DatabaseConnection
{
    public static IServiceCollection AddAuthDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("AuthPostgresConnection");

        services.AddDbContext<AuthDbContext>(options =>
            options.UseNpgsql(connectionString));

        return services;
    }
}