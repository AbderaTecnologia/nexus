using FluentValidation;
using Nexus.Cadastro.Application.Models;

namespace Nexus.Cadastro.Application.Handlers.Produtos.Create;

public sealed record CreateProdutoCommand : IRequest<ProdutoViewModel>
{
    public Guid Id { get; init; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public double preco { get; set; }
    public int Estoque { get; set; }
}

public sealed class CreateProdutoCommandValidator : AbstractValidator<CreateProdutoCommand>
{
    public  CreateProdutoCommandValidator()
    {
        RuleFor(x => x.Id)
            .SetValidator();
    }
}