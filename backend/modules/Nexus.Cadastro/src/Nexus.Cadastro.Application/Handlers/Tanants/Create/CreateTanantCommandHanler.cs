using Microsoft.AspNetCore.Mvc;
using Nexus.Cadastro.Domain.Entities;
using Nexus.Cadastro.Infra.Persistence;
using Nexus.Core.Domain.Entities;

namespace Nexus.Cadastro.Application.Handlers.Tanants.Create;

public sealed class CreateTanantCommandHandler(CadastroDbContext cadastroDbContext) : IRequestHandler<CreateTanantCommand, IResult>
{
    public async Task<IResult> Handle(CreateTanantCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateTanantCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            var problemDetails = new ValidationProblemDetails
            {
                Title = "Validation Failed",
                Status = StatusCodes.Status400BadRequest,
                Detail = "One or more validation errors occured!",
                Instance = "/tanants/create",
                Errors = validationResult.ToDictionary()
            };
            return BadRequest(problemDetails);
        }

        var cliente = new CompanyTenant
        {
            Name = request.Overview.Name,
            Email = request.Overview.Email,
            Identifier = request.Overview.Identifier,
            AvatarUrl = request.Overview.AvatarUrl,
            Address = new Address(
                street: request.Address.Street,
                number: request.Address.Number,
                complement: request.Address.Complement,
                neighborhood: request.Address.Neighborhood,
                city: request.Address.City,
                state: request.Address.State,
                country: request.Address.Country,
                zipcode: request.Address.ZipCode
            )
        };

        cadastroDbContext.Clientes.Add(cliente);
        await cadastroDbContext.SaveChangesAsync(cancellationToken);

        return Created($"/api/cadastro/cliente/{cliente.Id}", cliente.Id);
    }
}