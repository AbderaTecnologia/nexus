using FluentValidation;
using Nexus.Cadastro.Application.Models.Dtos;

namespace Nexus.Cadastro.Application.Handlers.Products.Create;

public sealed record CreateProductCommand(
     Guid Id, 
     string Name,
     string Description,
     double Price,
     int Stock
);

public sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public  CreateProductCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage(" ");
        
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(" ")
            .MaximumLength(150).WithMessage(" ");
        
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage(" ");
        
        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage(" ");
        
        RuleFor(x => x.Stock)
            .GreaterThan(0).WithMessage(" ");
    }
}