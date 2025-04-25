using Microsoft.AspNetCore.Mvc;
using Nexus.Cadastro.Domain.Entities;
using Nexus.Cadastro.Infra.Persistence;
using Nexus.Core.Domain.Entities;

namespace Nexus.Cadastro.Application.Handlers.Clientes.Create;

public sealed class CreateClienteCommandHandler(CadastroDbContext cadastroDbContext) : IRequestHandler<CreateClienteCommand, IResult>
{
    public async Task<IResult> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateClienteCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            var problemDetails = new ValidationProblemDetails
            {
                Title = "Validation Failed",
                Status = StatusCodes.Status400BadRequest,
                Detail = "One or more validation errors occured!",
                Instance = "/clientes/create",
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
                request.Address.Street,
                request.Address.Number,
                request.Address.Complement,
                request.Address.Neighborhood,
                request.Address.City,
                request.Address.State,
                request.Address.Country,
                request.Address.ZipCode
            )
        };

        cadastroDbContext.Clientes.Add(cliente);
        await cadastroDbContext.SaveChangesAsync(cancellationToken);

        return Created($"/api/register/tenant/{cliente.ContabilidadeId}/customer/{cliente.Id}", cliente.Id);
    }
}