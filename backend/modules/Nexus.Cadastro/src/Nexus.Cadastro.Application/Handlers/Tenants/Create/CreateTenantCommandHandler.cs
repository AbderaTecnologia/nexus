using Microsoft.AspNetCore.Mvc;
using Nexus.Cadastro.Domain.Entities;
using Nexus.Cadastro.Infra.Persistence;
using Nexus.Core.Domain.Entities;

namespace Nexus.Cadastro.Application.Handlers.Tenants.Create;

public sealed class CreateTenantCommandHandler(CadastroDbContext cadastroDbContext) : IRequestHandler<CreateTenantCommand, IResult>
{
    public async Task<IResult> Handle(CreateTenantCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateTenantCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            var problemDetails = new ValidationProblemDetails
            {
                Title = "Validation Failed",
                Status = StatusCodes.Status400BadRequest,
                Detail = "One or more validation errors occured!",
                Instance = "/tenants/create",
                Errors = validationResult.ToDictionary()
            };
            return BadRequest(problemDetails);
        }

        var tenant = new CompanyTenant
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

        cadastroDbContext.Tenants.Add(tenant);
        await cadastroDbContext.SaveChangesAsync(cancellationToken);

        return Created($"/api/cadastro/tenant/{tenant.Id}", tenant.Id);
    }
}