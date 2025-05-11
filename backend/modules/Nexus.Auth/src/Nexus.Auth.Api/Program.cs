using APIWeaver;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Nexus.Auth.Api.Mapping;
using Nexus.Auth.Application.Extensions;
using Nexus.Core.Api.Extensions;
using Nexus.Core.Infra.Interceptors;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();
builder.Services.AddJwtAuthentication(builder.Configuration);

builder.Services.AddSingleton<AuditableEntityInterceptor>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddMediator();
builder.Services.AddOpenApi(options =>
{
    options.AddSecurityScheme(JwtBearerDefaults.AuthenticationScheme, scheme =>
    {
        scheme.In = ParameterLocation.Header;
        scheme.Type = SecuritySchemeType.Http;
        scheme.Scheme = JwtBearerDefaults.AuthenticationScheme;
        scheme.BearerFormat = "JWT";
    });
    options.AddAuthResponse();
});

builder.Services.AddAuthConfigureJsonSerializable();

var app = builder.Build();
app.MapOpenApi();

if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapEndpoints();

await app.RunAsync();