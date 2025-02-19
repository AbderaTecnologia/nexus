using System.Text.Json.Serialization;
using Nexus.Auth.Application.Handlers.Users.CreateUserHandler;
using Nexus.Auth.Application.Models;
using Nexus.Auth.Domain.Entities;
using Nexus.Core.Application.Models;

namespace Nexus.Auth.Application.Extensions;

public static class JsonConfigureExtension
{
    public static IServiceCollection AddAuthConfigureJsonSerializable(this IServiceCollection services)
    {
        services.ConfigureHttpJsonOptions(o => { o.SerializerOptions.TypeInfoResolverChain.Insert(0, AuthJsonContext.Default); });

        return services;
    }
}

[JsonSerializable(typeof(LoginResponse))]
[JsonSerializable(typeof(LoginRequest))]
[JsonSerializable(typeof(CreateUserCommand))]
[JsonSerializable(typeof(User))]
[JsonSerializable(typeof(ResponseBase<object>))]
[JsonSerializable(typeof(ResponseBase<LoginResponse>))]
public partial class AuthJsonContext : JsonSerializerContext;