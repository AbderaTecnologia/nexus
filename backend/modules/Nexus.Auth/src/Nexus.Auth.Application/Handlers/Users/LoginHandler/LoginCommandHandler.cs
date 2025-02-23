namespace Nexus.Auth.Application.Handlers.Users.LoginHandler;

public class LoginCommand : IRequest<IResult>
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}

public class LoginCommandHandler(AuthDbContext context, IPasswordHasher<User> passwordHasher, IConfiguration configuration) : IRequestHandler<LoginCommand, IResult>
{
    public async Task<IResult> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await context.Users
            .FirstOrDefaultAsync(u => u.Username == request.Username, cancellationToken);

        if (user == null || string.IsNullOrEmpty(user.Password) || passwordHasher.VerifyHashedPassword(user, user.Password, request.Password) == PasswordVerificationResult.Failed)
        {
            return BadRequest("Credenciais de login inválidas");
        }

        var jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>();

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
        var tokenHandler = new JwtSecurityTokenHandler();

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(jwtSettings.ExpirationInMinutes),
            SigningCredentials = creds,
            Issuer = jwtSettings.Issuer,
            Audience = jwtSettings.Audience
        };
            
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return Ok(new { Token = tokenString, User = new { UserId = user.Id, UserName = user.FullName, Email = user.Username } });
    }
}