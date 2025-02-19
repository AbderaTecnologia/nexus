namespace Nexus.Auth.Application.Handlers.Users.LoginHandler;

public class LoginCommand : IRequest<IResult>
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}

public class LoginCommandHandler(AuthDbContext context, IPasswordHasher<User> passwordHasher, IConfiguration configuration) : IRequestHandler<LoginCommand, IResult>
{
    private readonly AuthDbContext _context = context;
    private readonly IPasswordHasher<User> _passwordHasher = passwordHasher;
    private readonly IConfiguration _configuration = configuration;

    public async Task<IResult> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Username == request.Username, cancellationToken);

        if (user == null || string.IsNullOrEmpty(user.Password) || _passwordHasher.VerifyHashedPassword(user, user.Password, request.Password) == PasswordVerificationResult.Failed)
        {
            return BadRequest("Credenciais de login inválidas");
        }

        var jwtSettings = _configuration.GetSection("JwtSettings").Get<JwtSettings>();

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim("CompanyId", user.CompanyId.ToString())
        };

        if (string.IsNullOrEmpty(jwtSettings!.SecretKey))
        {
            throw new InvalidOperationException("SecretKey is not configured.");
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: jwtSettings.Issuer,
            audience: jwtSettings.Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(jwtSettings.ExpirationInMinutes),
            signingCredentials: creds);

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return Ok(new { Token = tokenString });
    }
}