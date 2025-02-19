namespace Nexus.Auth.Application.Extensions;

[ExcludeFromCodeCoverage]
public static class HandlersInstallerExtensions
{
    public static IServiceCollection AddMediator(this IServiceCollection services) =>
        services
            .AddMediatR(configuration => configuration
                .RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                .AddOpenBehaviors())
            .AddHandlersDependencies()
            .AddPasswordHasher();

    private static IServiceCollection AddHandlersDependencies(this IServiceCollection services) =>
        services
            .AddRepositories()
            .AddAuthDatabase(services.BuildServiceProvider().GetRequiredService<IConfiguration>())
            .AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

    private static void AddOpenBehaviors(this MediatRServiceConfiguration configuration)
    {
        var types = Assembly.GetExecutingAssembly().GetTypes().Where(type => type.GetInterfaces()
            .Any(intf => intf.IsGenericType && intf.GetGenericTypeDefinition() == typeof(IPipelineBehavior<,>)));

        foreach (var behaviorType in types)
            configuration.AddOpenBehavior(behaviorType, ServiceLifetime.Scoped);
    }
    
    private static IServiceCollection AddPasswordHasher(this IServiceCollection services) =>
        services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
}