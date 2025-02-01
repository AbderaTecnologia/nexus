using MediatR;
using Nexus.Auth.Application.Handlers.Users.CreateUserHandler;
using Nexus.Auth.Application.Handlers.Users.LoginHandler;
using Nexus.Auth.Domain.Entities;
using Nexus.Auth.Models;
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
                .ProducesResponse(Unauthorized);

            group.MapPost("/register", (CreateUserCommand createUserCommand, IMediator mediator) =>
                mediator.Send(createUserCommand))
                .WithDescription("Criação de usuário")
                .ProducesResponse<User>(OK)
                .ProducesResponse(BadRequest);
        });
}