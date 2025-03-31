using Microsoft.AspNetCore.Mvc;
using Nexus.Cadastro.Domain.Entities;
using Nexus.Cadastro.Infra.Persistence;

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

        var cliente = new Cliente
        {
            Name = request.Nome,
            Email = request.Email,
            Identifier = request.CpfCnpj,
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