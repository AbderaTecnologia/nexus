using APIWeaver;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Nexus.Cadastro.Api.Extensions;
using Nexus.Cadastro.Api.Mapping;
using Nexus.Cadastro.Application.Extensions;
using Nexus.Core.Api.Extensions;
using Nexus.Core.Infra.Interceptors;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddAuthorization();

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

builder.Services.AddAuthApi(builder.Configuration);
builder.Services.AddCadastroConfigureJsonSerializable();

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