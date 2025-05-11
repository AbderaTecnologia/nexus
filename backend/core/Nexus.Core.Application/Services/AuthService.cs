using Refit;

namespace Nexus.Core.Application.Services;

public class AuthService(IAuthApi authApi) : IAuthService
{
    private readonly IAuthApi _authApi = authApi;

    public async Task<bool> CreateUserAsync(string userFullName, string username, string password, Guid companyId)
    {
        var createUserRequest = new CreateUserRequest
        {
            FullName = userFullName,
            Username = username,
            Password = password,
            CompanyId = companyId
        };

        var response = await _authApi.CreateUser(createUserRequest);

        return response.IsSuccessStatusCode;
    }
}

public interface IAuthApi
{
    [Post("/api/auth/register")]
    Task<ApiResponse<Guid>> CreateUser([Body] CreateUserRequest request);
}

public class CreateUserRequest
{
    public required string FullName { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public Guid CompanyId { get; set; }
}