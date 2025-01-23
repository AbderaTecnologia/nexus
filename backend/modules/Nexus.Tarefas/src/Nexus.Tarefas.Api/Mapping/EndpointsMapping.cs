using Nexus.Tarefas.Api.Endpoints;

namespace Nexus.Tarefas.Api.Mapping;

public static class EndpointsMapping
{
    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app) =>
        app
            .MapTaskEndpoints();
}