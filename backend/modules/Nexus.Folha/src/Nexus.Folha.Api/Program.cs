using APIWeaver;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Nexus.Core.Api.Extensions;
using Nexus.Core.Infra.Interceptors;
using Nexus.Folha.Api;
using Nexus.Folha.Application.Extensions;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddAuthorization();

builder.Services.AddSingleton<AuditableEntityInterceptor>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddMediator(builder.Configuration);
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
