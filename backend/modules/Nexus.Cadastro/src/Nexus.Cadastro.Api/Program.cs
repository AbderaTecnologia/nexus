using System.Text;
using APIWeaver;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using Nexus.Cadastro.Api.Extensions;
using Nexus.Cadastro.Api.Mapping;
using Nexus.Cadastro.Application.Extensions;
using Nexus.Core.Api.Extensions;
using Nexus.Core.Infra.Interceptors;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"]!))
        };
    });

builder.Services.AddAuthorization();

// Configuração de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder
            .WithOrigins("http://localhost:5013")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .WithExposedHeaders(HeaderNames.ContentDisposition);
    });
});

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

app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();

app.MapEndpoints();

await app.RunAsync();