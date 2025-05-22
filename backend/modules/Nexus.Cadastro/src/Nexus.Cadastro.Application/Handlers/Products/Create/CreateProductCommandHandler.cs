using Microsoft.AspNetCore.Mvc;
using Nexus.Cadastro.Domain.Entities;
using Nexus.Cadastro.Infra.Persistence;

namespace Nexus.Cadastro.Application.Handlers.Products.Create;

public sealed class CreateProductCommandHandler
{
    private readonly CadastroDbContext _context;
    public CreateProductCommandHandler(CadastroDbContext context)
    {
        _context = context;
    }
    public async Task<IResult> Handler(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateProductCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors
                .GroupBy(x => x.ErrorMessage)
                .ToDictionary(g => g
                        .Key, g => g.Select(e => e
                        .ErrorMessage).ToArray()
                );

            var problemDetails = new ValidationProblemDetails
            {
                Title = " Falha na validação",
                Status = StatusCodes.Status400BadRequest,
                Detail = "um ou mais erros ocorreram na validação dos dados!",
                Instance = "/produtos/create",
            };

            return BadRequest(problemDetails);
        }

        var product = new Product
        {
            Id = request.Id,
            Name = request.Name,
            Price = request.Price,
            Stock = request.Stock,
            Description = request.Description
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync(cancellationToken);

        return Created($"/api/cadastro/produto/{product.Id}", product.Id);
    }
}

