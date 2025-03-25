using FluentValidation;

namespace Nexus.Cadastro.Application.Handlers.Clientes.Create
{
    
    public sealed record ContactDto(
        string Type,
        string Name,
        string Email,
        string Phone,
        string WhatsApp
    );

    public sealed class ContactDtoValidation : AbstractValidator<ContactDto>
    {
        public ContactDtoValidation()
        {
            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("Tipo é obrigatório.")
                .MaximumLength(30).WithMessage("O tipo deve conter no máximo 30 caracteres.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Nome obrigatório.")
                .MaximumLength(150).WithMessage("O nome deve ter no máximo 150 caracteres. ");
            
            RuleFor(x => x. Email)
                .NotEmpty().WithMessage("E-mail obrigatório.")
                .EmailAddress().WithMessage("O deve ser valido.");
            
            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Telefone obrigatório.")
                .MaximumLength(16).WithMessage("O telefone deve conter no máximo 16 caracteres.");
            
            RuleFor(x => x.WhatsApp)
                .NotEmpty().WithMessage("WhatsApp obrigatório.")
                .MaximumLength(16).WithMessage("WhatsApp deve conter no máximo 16 caracteres.");
        }
    }

}