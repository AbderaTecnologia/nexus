using MediatR;
using Nexus.Cadastro.Application.Handlers.Products.Create;
using Nexus.Cadastro.Application.Handlers.Products.List;
using Nexus.Cadastro.Application.Models;
using Nexus.Core.Api.Extensions;

namespace Nexus.Cadastro.Api.Endpoints;

public static class ProductEndpoints
{
    public static  IEndpointRouteBuilder MapProductEndpoints(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup("api/produtos");
            group.RequireAuthorization();

            group.MapPost("/create", async (CreateProductCommand createProductCommand, IMediator mediator) =>
                    await mediator.Send(createProductCommand))
                .WithDescription("Criar Produto")
                .ProducesResponse(Created)
                .ProducesResponse(BadRequest);

            group.MapGet("/", async (IMediator mediator) =>
                    await mediator.Send(new ListProductsQuery()))
                .WithDescription("Listar Produtos")
                .ProducesResponse<IEnumerable<ProductViewModel>>(OK)
                .ProducesResponse(BadRequest);

            return builder;
        }
}