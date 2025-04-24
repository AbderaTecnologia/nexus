using System.Data.Entity;
using Nexus.Cadastro.Application.Models;
using Nexus.Cadastro.Infra.Persistence;

namespace Nexus.Cadastro.Application.Handlers.Tanants.List;

public sealed record ListTanantsQuery : IRequest<IResult>;

public class ListTanantsQueryHandler(CadastroDbContext cadastroDbContext) : IRequestHandler<ListTanantsQuery, IResult>
{
    public Task<IResult> Handle(ListTanantsQuery request, CancellationToken cancellationToken)
    {
        var clientes = cadastroDbContext.Clientes
        .AsNoTracking()
        .Select(
            c => new TanantViewModel
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