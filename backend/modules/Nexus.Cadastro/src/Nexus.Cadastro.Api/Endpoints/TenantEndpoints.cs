using MediatR;
using Nexus.Cadastro.Application.Handlers.Clientes.Create;
using Nexus.Cadastro.Application.Handlers.Clientes.List;
using Nexus.Cadastro.Application.Models;
using Nexus.Core.Api.Extensions;

namespace Nexus.Cadastro.Api.Endpoints;

public static class TenantEndpoints
{
    public static IEndpointRouteBuilder MapCadastroClientEndpoints(this IEndpointRouteBuilder builder) =>
        builder.MapGroup("Gerenciar tenants", "/api/register/tenants", group =>
        {
            group.RequireAuthorization();

            group.MapPost("/create", async (CreateClienteCommand createClienteCommand, IMediator mediator) =>
                await mediator.Send(createClienteCommand))
                .WithDescription("Criação de tenants")
                .ProducesResponse(Created)
                .ProducesResponse(BadRequest);

            group.MapGet("/", async (IMediator mediator) =>
                await mediator.Send(new ListClienteQuery()))
                .WithDescription("Consulta de tenants")
                .ProducesResponse<IEnumerable<ClienteViewModel>>(OK)
                .ProducesResponse(BadRequest);
        });
}