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
            Endereco = request.Endereco,
            Telefone = request.Telefone
        };

        cadastroDbContext.Clientes.Add(cliente);
        await cadastroDbContext.SaveChangesAsync(cancellationToken);

        return Created($"/api/cadastro/cliente/{cliente.Id}", cliente.Id);
    }
}