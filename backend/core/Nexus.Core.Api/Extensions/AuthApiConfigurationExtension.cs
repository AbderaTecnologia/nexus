using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nexus.Core.Application.Services;
using Refit;

namespace Nexus.Core.Api.Extensions;

public static class AuthApiConfigurationExtension
{
    public static IServiceCollection AddAuthApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRefitClient<IAuthApi>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(configuration["AuthApi:BaseUrl"]!));

        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}