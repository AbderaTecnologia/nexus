namespace Nexus.Cadastro.Infra.Data.Connection;

public static class DatabaseConnectionExtensions
{
    public static IServiceCollection AddCadastroDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("CadastroPostgresConnection");

        services.AddScoped<AuditableEntityInterceptor>();

        services.AddDbContext<CadastroDbContext>((serviceProvider, options) =>
        {
            var interceptor = serviceProvider.GetRequiredService<AuditableEntityInterceptor>();
            options.UseNpgsql(connectionString)
                   .AddInterceptors(interceptor);
        });

        return services;
    }
}