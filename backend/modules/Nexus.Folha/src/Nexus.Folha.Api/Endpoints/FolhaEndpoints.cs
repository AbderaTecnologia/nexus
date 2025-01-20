using MediatR;
using Nexus.Folha.Api.Extensions;
using Nexus.Folha.Application.Handlers.Funcionarios.GetFuncionariosHandler;
using Nexus.Folha.Domain.Entities;
using static System.Net.HttpStatusCode;

namespace Nexus.Folha.Api.Endpoints;

public static class FolhaEndpoints
{
    public static IEndpointRouteBuilder MapFolhaEndpoints(this IEndpointRouteBuilder builder) =>

        builder.MapGroup("Folha", "/api/folha", group =>
        {
            group.MapGet("/", (IMediator mediator) => mediator.Send(new GetFuncionariosCommand()))
            .WithDescription("Obter lista de funcinonário")
            .ProducesResponse<IEnumerable<Funcionario>>(OK)
            .ProducesResponse(NotFound);
        });
}