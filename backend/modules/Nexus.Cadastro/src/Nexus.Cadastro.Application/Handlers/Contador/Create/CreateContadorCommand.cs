namespace Nexus.Cadastro.Application.Handlers.Contador.Create;

public sealed record CreateContadorCommand(string Nome, string Email, string Username, string Password) : IRequest<IResult>;