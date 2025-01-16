using MediatR;
using Nexus.Folha.Domain.Entities;

namespace Nexus.Folha.Api.Endpoints;

public static class FolhaEndpoints
{
    public static IEndpointRouteBuilder MapFolhaEndpoints(this IEndpointRouteBuilder builder) =>

        builder.MapGroup("Folha", "/api/folha", group =>
        {
            group.MapGet("/", (IMediator mediator) => mediator.Send(new GetFolhaCommand()))
            .WithDescription("Obter lista de funcinonário")
            .ProducesResponse<IEnumerable<Funcionario>>(OK)
            .ProducesResponse(NotFound);
        });
}