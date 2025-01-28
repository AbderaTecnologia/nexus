using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Nexus.Tarefas.Infra.Data.Connection;
using Nexus.Tarefas.Infra.Extensions;

namespace Nexus.Tarefas.Application.Extensions;

public static class HandlersInstallerExtensions
{
    public static IServiceCollection AddMediator(this IServiceCollection services) =>
        services
            .AddMediatR(configuration => configuration
                .RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                .AddOpenBehaviors())
            .AddHandlersDependencies();

    private static IServiceCollection AddHandlersDependencies(this IServiceCollection services) =>
        services
            .AddRepositories()
            .AddDatabase()
            .AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

    private static void AddOpenBehaviors(this MediatRServiceConfiguration configuration)
    {
        var types = Assembly.GetExecutingAssembly().GetTypes().Where(type => type.GetInterfaces()
            .Any(intf => intf.IsGenericType && intf.GetGenericTypeDefinition() == typeof(IPipelineBehavior<,>)));

        foreach (var behaviorType in types)
            configuration.AddOpenBehavior(behaviorType, ServiceLifetime.Scoped);
    }
}