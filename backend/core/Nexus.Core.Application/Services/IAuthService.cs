namespace Nexus.Core.Application.Services;

public interface IAuthService
{
    Task<bool> CreateUserAsync(string userFullName, string username, string password, Guid companyId);
}