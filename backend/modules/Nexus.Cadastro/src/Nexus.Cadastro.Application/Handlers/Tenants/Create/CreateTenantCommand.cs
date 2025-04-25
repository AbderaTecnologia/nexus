using FluentValidation;
using Nexus.Cadastro.Application.Models.Dtos;

namespace Nexus.Cadastro.Application.Handlers.Tenants.Create;

public sealed record CreateTenantCommand(
    IEnumerable<ContactDto> Contacts,
    AddressDto Address,
    OverviewDto Overview,
    ProfileImageDto ProfileImage
) : IRequest<IResult>;

public sealed class CreateTenantCommandValidator : AbstractValidator<CreateTenantCommand>
{
    public CreateTenantCommandValidator()
    {
        RuleFor(x => x.Address)
            .SetValidator(new AddressDtoValidation());

        RuleForEach(x => x.Contacts)
            .SetValidator(new ContactDtoValidation());
    }
}
