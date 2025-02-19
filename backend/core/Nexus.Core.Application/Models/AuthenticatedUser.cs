using System.Security.Claims;

namespace Nexus.Core.Application.Models;

public class AuthenticatedUser
{
    public Guid UserId { get; set; }
    public Guid CompanyId { get; set; }

    public static AuthenticatedUser FromClaimsPrincipal(ClaimsPrincipal principal)
    {
        return new AuthenticatedUser
        {
            UserId = Guid.Parse(principal.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? Guid.Empty.ToString()),
            CompanyId = Guid.Parse(principal.FindFirst("companyId")?.Value ?? Guid.Empty.ToString())
        };
    }
}