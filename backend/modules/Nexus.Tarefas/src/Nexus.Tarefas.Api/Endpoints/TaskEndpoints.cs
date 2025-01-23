using MediatR;

namespace Nexus.Tarefas.Api.Endpoints;

public static class TaskEndpoints
{
    public static IEndpointRouteBuilder MapTaskEndpoints(this IEndpointRouteBuilder builder)
    {
        builder.MapGroup("Tasks", "/api/tasks", group =>
        {
            group.MapGet("/", (IMediator mediator) => mediator.Send())
        });
    }
}