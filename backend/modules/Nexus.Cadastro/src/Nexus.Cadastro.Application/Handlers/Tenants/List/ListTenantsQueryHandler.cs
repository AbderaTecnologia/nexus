using System.Data.Entity;
using Nexus.Cadastro.Application.Models;
using Nexus.Cadastro.Infra.Persistence;

namespace Nexus.Cadastro.Application.Handlers.Tenants.List;

public sealed record ListTenantsQuery : IRequest<IResult>;

public sealed class ListTenantsQueryHandler(CadastroDbContext cadastroDbContext) : IRequestHandler<ListTenantsQuery, IResult>
{
    public async Task<IResult> Handle(ListTenantsQuery request, CancellationToken cancellationToken)
    {
        var tenants = await cadastroDbContext.Tenants
        .Select(
            c => new TenantViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                CpfCnpj = c.Identifier,
                Type = c.Identifier.Length > 11 ? "PJ" : "PF"
            }
        ).ToListAsync(cancellationToken);

        return Ok(tenants);
    }
}