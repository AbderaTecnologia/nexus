using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nexus.Cadastro.Infra.Persistence;

namespace Nexus.Cadastro.Application.Handlers.Produtos.Create;

public sealed class CreateProdutoCommandHandler(CadastroDbContext cadastroDbContext) : IRequestHandler<CreateProdutoCommand, IResult>
{
    public async Task Handler(CreateProdutoCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateProdutoCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            var problemDetails = new ValidationProblemDetails
            {
                
            }
        }
    }
}