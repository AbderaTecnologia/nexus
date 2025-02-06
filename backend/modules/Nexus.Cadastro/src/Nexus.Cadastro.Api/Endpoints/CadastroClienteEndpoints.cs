using Nexus.Core.Api.Extensions;

namespace Nexus.Cadastro.Api.Endpoints;

public static class CadastroClienteEndpoints
{
    public static IEndpointRouteBuilder MapCadastroClientEndpoints(this IEndpointRouteBuilder builder) =>
        builder.MapGroup("Cadastro Cliente", "/api/cadastro-cliente", group =>
        {

        });
}