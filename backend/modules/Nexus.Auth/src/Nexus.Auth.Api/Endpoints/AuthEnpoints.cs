using MediatR;
using Nexus.Auth.Application.Handlers.Users.CreateUserHandler;
using Nexus.Auth.Application.Handlers.Users.LoginHandler;
using Nexus.Auth.Application.Handlers.Users.LogoutHandler;
using Nexus.Auth.Application.Models;
using Nexus.Core.Api.Extensions;
using static System.Net.HttpStatusCode;

namespace Nexus.Auth.Api.Endpoints;

public static class AuthEndpoints
{
    public static IEndpointRouteBuilder MapAuthEndpoints(this IEndpointRouteBuilder builder) =>
        builder.MapGroup("Auth", "/api/auth", group =>
        {
            group.MapPost("/login", (LoginRequest loginRequest, IMediator mediator) =>
                mediator.Send(new LoginCommand { Username = loginRequest.Username, Password = loginRequest.Password }))
                .WithDescription("Login de usuário")
                .ProducesResponse<LoginResponse>(OK)
                .ProducesResponse(BadRequest);

            group.MapPost("/register", (CreateUserCommand createUserCommand, IMediator mediator) =>
                mediator.Send(createUserCommand))
                .WithDescription("Criação de usuário")
                .ProducesResponse(Created)
                .ProducesResponse(BadRequest);

            group.MapPost("/logout", (LogoutCommand logoutCommand, IMediator mediator) =>
                mediator.Send(logoutCommand))
                .WithDescription("Logout de usuário")
                .ProducesResponse(OK)
                .ProducesResponse(BadRequest);

            group.MapGet("/test-auth", async (IMediator mediator) =>
            {
                // This is a placeholder for actual authentication testing logic
                return Results.Ok(new { Message = "Authentication successful" });
            })
            .RequireAuthorization()
            .WithDescription("Test authentication")
            .ProducesResponse(OK)
            .ProducesResponse(Unauthorized);
        });
}