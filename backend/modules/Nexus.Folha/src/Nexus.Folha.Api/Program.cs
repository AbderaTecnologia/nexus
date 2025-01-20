using Nexus.Folha.Api;
using Nexus.Folha.Api.Extensions;
using Nexus.Folha.Application.Extensions;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddOpenApi("v1", "Nexus", ".NET 9 API with MediatR");

builder.Services.AddMediator();
builder.Services.AddOpenApi();

var app = builder.Build();
app.MapOpenApi();

if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapEndpoints();

await app.RunAsync();
