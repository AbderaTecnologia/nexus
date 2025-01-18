using MediatR;
using Microsoft.AspNetCore.Http;
using Nexus.Folha.Infra.Repositories;

namespace Nexus.Folha.Application.Handlers.Funcionarios.GetFuncionariosHandler;

public class GetFuncionariosCommandHandler(IFuncionarioRepository repository)
    : IRequestHandler<GetFuncionariosCommand, IResult>
{
    public async Task<IResult> Handle(
        GetFuncionariosCommand request,
        CancellationToken cancellationToken
    ) => Results.Ok(await repository.Get());
}