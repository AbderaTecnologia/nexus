using Nexus.Auth.Domain.Entities;

namespace Nexus.Auth.Application.Handlers.Users.CreateUserHandler;

public class CreateUserCommand : IRequest<IResult>
{
    public required string Username { get; set; }
    public required string Password { get; set; }
    public Guid CompanyId { get; set; }
}

public class CreateUserCommandHandler(AuthDbContext context) : IRequestHandler<CreateUserCommand, IResult>
{
    private readonly AuthDbContext _context = context;

    public async Task<IResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Username = request.Username,
            Password = request.Password,
            CompanyId = request.CompanyId
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);

        return Created();
    }
}