using Nexus.Cadastro.Domain.Entities;
using Nexus.Cadastro.Infra.Persistence;
using Nexus.Core.Application.Services;

namespace Nexus.Cadastro.Application.Handlers.Contadores.Create;

public class CreateContadorCommandHandler(CadastroDbContext _context, IAuthService authService) : IRequestHandler<CreateContadorCommand, IResult>
{
    public async Task<IResult> Handle(CreateContadorCommand request, CancellationToken cancellationToken)
    {
        var contabilidade = new Contabilidade
        {
            Name = request.CompanyName,
            Email = request.Email,
        };

        _context.Contabilidades.Add(contabilidade);
        await _context.SaveChangesAsync(cancellationToken);

        //Cria o usuário administrador chamando o serviço de autenticação
        var success = await authService.CreateUserAsync(request.UserFullName, request.Username, request.Password, contabilidade.Id);

        if (!success)
        {
            return BadRequest("Erro ao criar usuário administrador");
        }

        return Created($"/api/cadastro/contador/{contabilidade.Id}", contabilidade.Id);
    }
}