using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Nexus.Auth.Application.Models;
using Nexus.Auth.Infra.Persistence;
using Nexus.Core.Application.Models.Jwt;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Nexus.Auth.Application.Handlers.Users.LoginHandler;

public class LoginCommand : IRequest<LoginResponse>
{
    public required string Username { get; set; }
    public required string Password { get; set; }
}

public class LoginCommandHandler(
    AuthDbContext context,
    IConfiguration configuration
) : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly AuthDbContext _context = context;
    private readonly IConfiguration _configuration = configuration;

    public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Username == request.Username && u.Password == request.Password, cancellationToken);

        if (user == null)
        {
            return new LoginResponse(Token: "", "Credencias de login inválidas");
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

        return new LoginResponse(tokenString);
    }
}