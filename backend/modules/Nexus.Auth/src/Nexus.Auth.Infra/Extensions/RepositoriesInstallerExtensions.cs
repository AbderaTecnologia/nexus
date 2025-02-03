using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;

namespace Nexus.Auth.Infra.Extensions;

[ExcludeFromCodeCoverage]
public static class RepositoriesInstallerExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services) =>
        services;
}