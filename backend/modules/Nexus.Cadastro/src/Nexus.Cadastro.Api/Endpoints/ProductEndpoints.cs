using MediatR;
using Nexus.Cadastro.Application.Handlers.Products.Create;
using Nexus.Cadastro.Application.Handlers.Products.Delete;
using Nexus.Cadastro.Application.Handlers.Products.List;
using Nexus.Cadastro.Application.Handlers.Products.Update;
using Nexus.Core.Api.Extensions;

namespace Nexus.Cadastro.Api.Endpoints;

public static class ProductEndpoints
{
    public static IEndpointRouteBuilder MapProductEndpoints(this IEndpointRouteBuilder builder) =>
        builder.MapGroup("Produtos", "/api/register/products", group =>
        {
            group.RequireAuthorization();

            group.MapPost("/", async (CreateProductCommand command, IMediator mediator) =>
                await mediator.Send(command))
                .WithDescription("Criação de produto")
                .Produces<Guid>(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest);

            group.MapGet("/", async (IMediator mediator) =>
                await mediator.Send(new ListProductsQuery()))
                .WithDescription("Listagem de produtos")
                .ProducesResponse<IEnumerable<ProductViewModel>>(OK)
                .Produces(StatusCodes.Status404NotFound);

            group.MapPut("/{id:guid}", async (Guid id, UpdateProductCommand command, IMediator mediator) =>
                await mediator.Send(command with { Id = id }))
                .WithDescription("Atualização de produto")
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status400BadRequest);

            group.MapDelete("/{id:guid}", async (Guid id, IMediator mediator) =>
                await mediator.Send(new DeleteProductCommand(id)))
                .WithDescription("Exclusão de produto")
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status404NotFound);
        });
}