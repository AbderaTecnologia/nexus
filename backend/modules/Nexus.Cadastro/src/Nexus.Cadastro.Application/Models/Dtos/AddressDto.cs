using FluentValidation;

namespace Nexus.Cadastro.Application.Models.Dtos
{
    public sealed record AddressDto(
        string Street,
        string Number,
        string Complement,
        string Neighborhood,
        string City,
        string State,
        string Country,
        string ZipCode
    );

    public sealed class AddressDtoValidation : AbstractValidator<AddressDto>
    {
        public AddressDtoValidation()
        {
            RuleFor(x => x.Street)
                .NotEmpty().WithMessage("A rua é obrigatória.")
                .MaximumLength(100).WithMessage("A rua deve ter no máximo 100 caracteres.");

            RuleFor(x => x.Number)
                .NotEmpty().WithMessage("O número é obrigatório.")
                .MaximumLength(10).WithMessage("O número deve ter no máximo 10 caracteres.");

            RuleFor(x => x.Complement)
                .MaximumLength(50).WithMessage("O complemento deve ter no máximo 50 caracteres.");

            RuleFor(x => x.Neighborhood)
                .NotEmpty().WithMessage("O bairro é obrigatório.")
                .MaximumLength(50).WithMessage("O bairro deve ter no máximo 50 caracteres.");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("A cidade é obrigatória.")
                .MaximumLength(50).WithMessage("A cidade deve ter no máximo 50 caracteres.");

            RuleFor(x => x.State)
                .NotEmpty().WithMessage("O estado é obrigatório.")
                .MaximumLength(2).WithMessage("O estado deve ter no máximo 2 caracteres.");

            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("O país é obrigatório.")
                .MaximumLength(50).WithMessage("O país deve ter no máximo 50 caracteres.");

            RuleFor(x => x.ZipCode)
                .NotEmpty().WithMessage("O CEP é obrigatório.")
                .MaximumLength(8).WithMessage("O CEP deve ter no máximo 8 caracteres.");
        }
    }
}