namespace Nexus.Auth.Application.Handlers.Users.LogoutHandler;

public class LogoutCommandHandler : IRequestHandler<LogoutCommand, IResult>
{
    public async Task<IResult> Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        // Adicione a lógica de logout aqui, como invalidar tokens ou limpar sessões
        return Ok();
    }
}