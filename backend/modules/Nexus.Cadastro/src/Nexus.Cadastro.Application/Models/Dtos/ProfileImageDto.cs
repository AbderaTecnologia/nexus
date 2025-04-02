using FluentValidation;

namespace Nexus.Cadastro.Application.Models.Dtos;

public sealed record ProfileImageDto(
    string Src
    );

public sealed class ProfileImageDtoValidator : AbstractValidator<ProfileImageDto>
{
    public ProfileImageDtoValidator()
    {
        RuleFor(x => x.Src)
            .NotEmpty().WithMessage("Src é obrigatório")
            .MaximumLength(1).WithMessage("O campo deve conter o máximo um src");
    }
}




