using MediatR;
using Nexus.Cadastro.Application.Handlers.Contadores.Create;
using Nexus.Core.Api.Extensions;

namespace Nexus.Cadastro.Api.Endpoints;

public static class ContadorEndpoints
{
    public static IEndpointRouteBuilder MapContadorEndpoints(this IEndpointRouteBuilder builder) =>
        builder.MapGroup("Contador","/api/contador", group =>
        {
            group.MapPost("/", async (CreateContadorCommand command, IMediator mediator) => await mediator.Send(command))
                .WithDescription("Cria um contador")
                .Produces<Guid>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest);
        });
}