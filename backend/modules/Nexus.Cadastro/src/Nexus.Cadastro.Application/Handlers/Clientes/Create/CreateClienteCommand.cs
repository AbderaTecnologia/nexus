namespace Nexus.Cadastro.Application.Handlers.Clientes.Create;

public sealed record CreateClienteCommand(
    string Nome,
    string Email,
    string CpfCnpj,
    string Endereco,
    string Telefone
) : IRequest<IResult>;