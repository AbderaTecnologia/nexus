using Nexus.Cadastro.Domain.Entities;

namespace Nexus.Cadastro.Application.Handlers.Clientes.Create;

public sealed record CreateClienteCommand(
    string Nome,
    string Email,
    string CpfCnpj,
    Endereco Endereco,
    string Telefone
) : IRequest<IResult>;