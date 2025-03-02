using System.Data.Entity;
using Nexus.Cadastro.Application.Models;
using Nexus.Cadastro.Infra.Persistence;

namespace Nexus.Cadastro.Application.Handlers.Clientes.List;

public sealed record ListClienteQuery : IRequest<IResult>;

public class ListClienteQueryHandler(CadastroDbContext cadastroDbContext) : IRequestHandler<ListClienteQuery, IResult>
{
    public Task<IResult> Handle(ListClienteQuery request, CancellationToken cancellationToken)
    {
        var clientes = cadastroDbContext.Clientes
        .AsNoTracking()
        .Select(
            c => new ClienteViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                CpfCnpj = c.Identifier,
                Type = c.Identifier.Length > 11 ? "PJ" : "PF"
            }
        );

        return Task.FromResult(Ok(clientes));
    }
}