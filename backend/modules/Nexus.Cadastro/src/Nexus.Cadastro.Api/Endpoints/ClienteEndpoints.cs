using MediatR;
using Nexus.Cadastro.Application.Handlers.Clientes.Create;
using Nexus.Cadastro.Application.Handlers.Clientes.List;
using Nexus.Cadastro.Application.Models;
using Nexus.Core.Api.Extensions;

namespace Nexus.Cadastro.Api.Endpoints;

public static class ClienteEndpoints
{
    public static IEndpointRouteBuilder MapCadastroClientEndpoints(this IEndpointRouteBuilder builder) =>
        builder.MapGroup("Cadastro Cliente", "/api/cadastro", group =>
        {
            group.RequireAuthorization();

            group.MapPost("/cliente", async (CreateClienteCommand createClienteCommand, IMediator mediator) =>
                await mediator.Send(createClienteCommand))
                .WithDescription("Criação de cliente")
                .ProducesResponse(Created)
                .ProducesResponse(BadRequest);

            group.MapGet("/cliente/list", async (IMediator mediator) =>
                await mediator.Send(new ListClienteQuery()))
                .WithDescription("Consulta de clientes")
                .ProducesResponse<IEnumerable<ClienteViewModel>>(OK)
                .ProducesResponse(BadRequest);
        });
}