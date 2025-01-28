using System.Data;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;

namespace Nexus.Tarefas.Infra.Data.Connection;

public static class DatabaseConnection
{
    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        var connection = new SqliteConnection("Data Source=:memory:");

        return services
            .AddSingleton<IDbConnection>(_ => connection);
    }
}