using MediatR;
using Microsoft.AspNetCore.Http;

namespace Nexus.Folha.Application.Handlers.Funcionarios.GetFuncionariosHandler;

public sealed class GetFuncionariosCommand(int? id = null) : IRequest<IResult>
{
    private int? Id { get; } = id;

    public bool IsGetById => Id is not null;
}