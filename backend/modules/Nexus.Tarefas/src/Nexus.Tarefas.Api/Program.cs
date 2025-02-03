using Nexus.Core.Api.Extensions;
using Nexus.Tarefas.Api.Mapping;
using Nexus.Tarefas.Application.Extensions;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediator();
builder.Services.AddOpenApi();
builder.Services.AddConfigureJsonSerializable();

var app = builder.Build();
app.MapOpenApi();

if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapEndpoints();

await app.RunAsync();