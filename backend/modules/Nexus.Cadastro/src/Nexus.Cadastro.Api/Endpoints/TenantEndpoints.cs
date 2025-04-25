using MediatR;
using Nexus.Cadastro.Application.Handlers.Tenants.List;
using Nexus.Cadastro.Application.Handlers.Tenants.Create;
using Nexus.Cadastro.Application.Models;
using Nexus.Core.Api.Extensions;

namespace Nexus.Cadastro.Api.Endpoints;

public static class TenantEndpoints
{
    public static IEndpointRouteBuilder MapCadastroClientEndpoints(this IEndpointRouteBuilder builder) =>
        builder.MapGroup("Gerenciar tenants", "/api/register/tenants", group =>
        {
            group.RequireAuthorization();

            group.MapPost("/create", async (CreateTenantCommand createTenantCommand, IMediator mediator) =>
                await mediator.Send(createTenantCommand))
                .WithDescription("Criação de tenants")
                .ProducesResponse(Created)
                .ProducesResponse(BadRequest);

            group.MapGet("/", async (IMediator mediator) =>
                await mediator.Send(new ListTenantsQuery()))
                .WithDescription("Consulta de tenants")
                .ProducesResponse<IEnumerable<TenantViewModel>>(OK)
                .ProducesResponse(BadRequest);
        });
}