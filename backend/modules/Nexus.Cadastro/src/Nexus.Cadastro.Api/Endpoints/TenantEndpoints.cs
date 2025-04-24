using MediatR;
using Nexus.Cadastro.Application.Handlers.Tanants.List;
using Nexus.Cadastro.Application.Handlers.Tanants.Create;
using Nexus.Cadastro.Application.Models;
using Nexus.Core.Api.Extensions;

namespace Nexus.Cadastro.Api.Endpoints;

public static class TenantEndpoints
{
    public static IEndpointRouteBuilder MapCadastroClientEndpoints(this IEndpointRouteBuilder builder) =>
        builder.MapGroup("Gerenciar tenants", "/api/register/tenants", group =>
        {
            group.RequireAuthorization();

            group.MapPost("/create", async (CreateTanantCommand createClienteCommand, IMediator mediator) =>
                await mediator.Send(createClienteCommand))
                .WithDescription("Criação de tenants")
                .ProducesResponse(Created)
                .ProducesResponse(BadRequest);

            group.MapGet("/", async (IMediator mediator) =>
                await mediator.Send(new ListTanantsQuery()))
                .WithDescription("Consulta de tenants")
                .ProducesResponse<IEnumerable<TanantViewModel>>(OK)
                .ProducesResponse(BadRequest);
        });
}