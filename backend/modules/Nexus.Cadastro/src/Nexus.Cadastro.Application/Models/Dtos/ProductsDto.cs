using FluentValidation;

namespace Nexus.Cadastro.Application.Models.Dtos;

public sealed record ProductsDto(

     Guid Id,
     string Name,
     double Price,
     int Stock, 
     string Description 
    );

public sealed class ProductsDtoValidation : AbstractValidator<ProductsDto>
{
    public ProductsDtoValidation()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty).WithMessage(" ");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(" ")
            .MaximumLength(150).WithMessage(" ");

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(0).WithMessage(" ");
        
        RuleFor(x => x.Stock)
            .NotEmpty().WithMessage(" ");
        
        RuleFor(x => x.Description)
            .MaximumLength(150).WithMessage(" ");
    }
}
    
    


