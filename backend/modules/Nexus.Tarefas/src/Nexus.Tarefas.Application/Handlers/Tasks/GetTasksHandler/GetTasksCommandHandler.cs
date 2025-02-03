using MediatR;
using Microsoft.AspNetCore.Http;

namespace Nexus.Tarefas.Application.Handlers.Tasks.GetTasksHandler;

public class GetTasksCommandHandler : IRequestHandler<GetTasksCommand, IResult>
{
    public async Task<IResult> Handle(
        GetTasksCommand request,
        CancellationToken cancellationToken
    ) => Results.Ok(Task.FromResult(new Domain.Entities.Task()));
}