using Nexus.Cadastro.Domain.Entities;
using Nexus.Cadastro.Infra.Persistence;

namespace Nexus.Cadastro.Application.Handlers.Clientes.Create;


public sealed class CreateClienteCommandHandler(CadastroDbContext cadastroDbContext) : IRequestHandler<CreateClienteCommand, IResult>
{
    public async Task<IResult> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = new Cliente
        {
            Name = request.Nome,
            Email = request.Email,
            Identifier = request.CpfCnpj
        };

        cadastroDbContext.Clientes.Add(cliente);
        await cadastroDbContext.SaveChangesAsync(cancellationToken);

        return Created($"/api/cadastro/cliente/{cliente.Id}", cliente.Id);
    }
}