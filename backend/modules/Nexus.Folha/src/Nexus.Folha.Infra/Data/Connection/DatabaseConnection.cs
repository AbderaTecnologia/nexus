using System.Data;
using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;

namespace Nexus.Folha.Infra.Data.Connection;

public static class DatabaseConnections
{
    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        var connection = new SqliteConnection("Data Source=:memory:");

        return services
            .AddSingleton<IDbConnection>(_ => connection)
            .SeedData(connection);
    }

    private static IServiceCollection SeedData(this IServiceCollection services, IDbConnection connection)
    {
        connection.Open();

        var script = File.ReadAllText("script.sql");

        var commands = script.Split(";").Where(command => !string.IsNullOrEmpty(command));

        foreach (var command in commands)
            connection.Execute(command);
        
        return services;
    }
}