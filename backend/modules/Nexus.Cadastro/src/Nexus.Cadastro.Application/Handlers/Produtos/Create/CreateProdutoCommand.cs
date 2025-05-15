using FluentValidation;
using Nexus.Cadastro.Application.Models;
using Nexus.Cadastro.Application.Models.Dtos;

namespace Nexus.Cadastro.Application.Handlers.Produtos.Create;

public sealed record CreateProdutoCommand(

    ProdutosDto Produtos,
     Guid Id, 
     string Nome,
     string Descricao,
     double Preco,
     int Estoque
);

public sealed class CreateProdutoCommandValidator : AbstractValidator<CreateProdutoCommand>
{
    public  CreateProdutoCommandValidator()
    {
        RuleFor(x => x.Produtos)
            .SetValidator(new ProdutosDtoValidation());
        
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(" ");
        
        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage(" ")
            .MaximumLength(150).WithMessage(" ");
        
        RuleFor(x => x.Descricao)
            .NotEmpty().WithMessage(" ");
        
        RuleFor(x => x.Preco)
            .GreaterThan(0).WithMessage(" ");
        
        RuleFor(x => x.Estoque)
            .GreaterThan(0).WithMessage(" ");
    }
}