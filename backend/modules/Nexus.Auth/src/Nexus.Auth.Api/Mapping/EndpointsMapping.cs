using Nexus.Auth.Api.Endpoints;

namespace Nexus.Auth.Api.Mapping;

public static class EndpointsMapping
{
    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app) =>
        app
            .MapAuthEndpoints();
}