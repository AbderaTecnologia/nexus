using FluentValidation;

namespace Nexus.Cadastro.Application.Models.Dtos;

public sealed record ProdutosDto(

     Guid Id,
     string Nome,
     double Preco,
     int Estoque, 
     string Descricao 
    );

public sealed class ProdutosDtoValidation : AbstractValidator<ProdutosDto>
{
    public ProdutosDtoValidation()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty).WithMessage(" ");

        RuleFor(x => x.Nome)
            .NotEmpty().WithMessage(" ")
            .MaximumLength(150).WithMessage(" ");

        RuleFor(x => x.Preco)
            .GreaterThanOrEqualTo(0).WithMessage(" ");
        
        RuleFor(x => x.Estoque)
            .NotEmpty().WithMessage(" ");
        
        RuleFor(x => x.Descricao)
            .MaximumLength(150).WithMessage(" ");
    }
}
    
    


