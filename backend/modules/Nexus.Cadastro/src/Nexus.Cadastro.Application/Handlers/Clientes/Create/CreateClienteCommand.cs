using FluentValidation;
using Nexus.Cadastro.Application.Models.Dtos;

namespace Nexus.Cadastro.Application.Handlers.Clientes.Create;

public sealed record CreateClienteCommand(
    string Name,
    string Email,
    string Identifier,
    IEnumerable<ContactDto> Contacts,
    AddressDto Address,
    OverviewDto Overview,
    ProfileImageDto ProfileImage
) : IRequest<IResult>;

public sealed class CreateClienteCommandValidator : AbstractValidator<CreateClienteCommand>
{
    public CreateClienteCommandValidator()
    {
        RuleFor(x => x.Address)
            .SetValidator(new AddressDtoValidation());

        RuleForEach(x => x.Contacts)
            .SetValidator(new ContactDtoValidation());
    }
}
