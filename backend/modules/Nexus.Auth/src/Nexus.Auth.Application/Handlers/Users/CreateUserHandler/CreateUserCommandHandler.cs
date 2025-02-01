using MediatR;
using Nexus.Auth.Domain.Entities;
using Nexus.Auth.Infra.Persistence;

namespace Nexus.Auth.Application.Handlers.Users.CreateUserHandler;

public class CreateUserCommand : IRequest<User>
{
    public string Username { get; set; }
    public string Password { get; set; }
    public Guid CompanyId { get; set; }
}

public class CreateUserCommandHandler(AuthDbContext context) : IRequestHandler<CreateUserCommand, User>
{
    private readonly AuthDbContext _context = context;

    public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Username = request.Username,
            Password = request.Password,
            CompanyId = request.CompanyId
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);

        return user;
    }
}