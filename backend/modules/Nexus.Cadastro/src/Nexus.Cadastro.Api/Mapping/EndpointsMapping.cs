using Nexus.Cadastro.Api.Endpoints;

namespace Nexus.Cadastro.Api.Mapping;

public static class EndpointsMapping
{
    public static IEndpointRouteBuilder MapEndpoints(this IEndpointRouteBuilder app) =>
        app
            .MapCadastroClientEndpoints();
}