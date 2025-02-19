using MediatR;
using Nexus.Core.Api.Extensions;
using Nexus.Tarefas.Application.Handlers.Tasks.GetTasksHandler;
using static System.Net.HttpStatusCode;

namespace Nexus.Tarefas.Api.Endpoints;

public static class TaskEndpoints
{
    public static IEndpointRouteBuilder MapTaskEndpoints(this IEndpointRouteBuilder builder) =>
        builder.MapGroup("Tasks", "/api/tasks", group =>
        {
            group.MapGet("/", (IMediator mediator) => mediator.Send(new GetTasksCommand()))
                .WithDescription("Obter lista de tarefas")
                .ProducesResponse(OK)
                .ProducesResponse(NotFound);
        });
}