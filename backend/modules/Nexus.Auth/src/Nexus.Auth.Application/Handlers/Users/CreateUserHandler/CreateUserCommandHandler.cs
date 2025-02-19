namespace Nexus.Auth.Application.Handlers.Users.CreateUserHandler;

public class CreateUserCommand : IRequest<IResult>
{
    public required string Username { get; set; }
    public required string Password { get; set; }
    public Guid CompanyId { get; set; }
}

public class CreateUserCommandHandler(AuthDbContext context, IPasswordHasher<User> passwordHasher) : IRequestHandler<CreateUserCommand, IResult>
{
    private readonly AuthDbContext _context = context;
    private readonly IPasswordHasher<User> _passwordHasher = passwordHasher;

    public async Task<IResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User(
            username: request.Username,
            companyId: request.CompanyId
        );

        user.SetHashPassword(_passwordHasher.HashPassword(user, request.Password));

        _context.Users.Add(user);
        await _context.SaveChangesAsync(cancellationToken);

        return Created($"/api/users/{user.Id}", user.Id);
    }
}