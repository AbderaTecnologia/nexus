using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using Nexus.Folha.Infra.Repositories;

namespace Nexus.Folha.Infra.Extensions;

[ExcludeFromCodeCoverage]
public static class RepositoriesInstallerExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services) =>
        services
            .AddScoped<IFuncionarioRepository, FuncionarioRepository>();
}