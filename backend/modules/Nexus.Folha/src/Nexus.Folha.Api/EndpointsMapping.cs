using Nexus.Folha.Api.Endpoints;

namespace Nexus.Folha.Api;

public static class EndpointsMapping
{
    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app) =>
        app
            .MapFolhaEndpoints();
}