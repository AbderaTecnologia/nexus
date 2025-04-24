using FluentValidation;
using Nexus.Cadastro.Application.Models.Dtos;

namespace Nexus.Cadastro.Application.Handlers.Tanants.Create;

public sealed record CreateTanantCommand(
    IEnumerable<ContactDto> Contacts,
    AddressDto Address,
    OverviewDto Overview,
    ProfileImageDto ProfileImage
) : IRequest<IResult>;

public sealed class CreateClienteCommandValidator : AbstractValidator<CreateTanantCommand>
{
    public CreateClienteCommandValidator()
    {
        RuleFor(x => x.Address)
            .SetValidator(new AddressDtoValidation());

        RuleForEach(x => x.Contacts)
            .SetValidator(new ContactDtoValidation());
    }
}
