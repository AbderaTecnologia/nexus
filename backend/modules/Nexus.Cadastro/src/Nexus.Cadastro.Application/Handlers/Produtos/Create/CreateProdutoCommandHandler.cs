using Microsoft.AspNetCore.Mvc;
using Nexus.Cadastro.Domain.Entities;
using Nexus.Cadastro.Infra.Persistence;
using Nexus.Core.Domain.Entities;

namespace Nexus.Cadastro.Application.Handlers.Produtos.Create;

public sealed class CreateProdutoCommandHandler
{
    private readonly CadastroDbContext _context;
    public CreateProdutoCommandHandler(CadastroDbContext context)
    {
        _context = context;
    }
    public async Task<IResult> Handler(CreateProdutoCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateProdutoCommandValidator();
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

        var produto = new Produto
        {
            Id = request.Id,
            Nome = request.Nome,
            Preco = request.Preco,
            Estoque = request.Estoque,
            Descricao = request.Descricao
        };

        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync(cancellationToken);

        return Created($"/api/cadastro/produto/{produto.Id}", produto.Id);
    }
}

