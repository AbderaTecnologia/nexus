namespace Nexus.Cadastro.Application.Handlers.Contadores.Create;

public sealed record CreateContadorCommand(string CompanyName, string Email, string UserFullName, string Username, string Password) : IRequest<IResult>;