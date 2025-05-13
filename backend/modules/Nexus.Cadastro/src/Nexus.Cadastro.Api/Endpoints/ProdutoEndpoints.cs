using MediatR;
using Nexus.Cadastro.Application.Handlers.Produtos.Create;
using Nexus.Cadastro.Application.Handlers.Produtos.List;
using Nexus.Cadastro.Application.Models;
using Nexus.Core.Api.Extensions;

namespace Nexus.Cadastro.Api.Endpoints;

public static class ProdutoEndpoints
{
    public static  IEndpointRouteBuilder MapProdutoEndpoints(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup("api/produtos");
            group.RequireAuthorization();

            group.MapPost("/create", async (CreateProdutoCommand createProdutoCommand, IMediator mediator) =>
                    await mediator.Send(createProdutoCommand))
                .WithDescription("Criar novo Produto")
                .ProducesResponse(Created)
                .ProducesResponse(BadRequest);

            group.MapGet("/", async (IMediator mediator) =>
                    await mediator.Send(new ListProdutoQuery()))
                .WithDescription("")
                .ProducesResponse<IEnumerable<ProdutoViewModel>>(OK)
                .ProducesResponse(BadRequest);

            return builder;
        }
}