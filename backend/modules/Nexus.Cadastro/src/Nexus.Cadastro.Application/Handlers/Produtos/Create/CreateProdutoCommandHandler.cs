using Nexus.Cadastro.Infra.Persistence;

namespace Nexus.Cadastro.Application.Handlers.Produtos.Create;

public sealed class CreateProdutoCommandHandler(CadastroDbContext cadastroDbContext) : IRequestHandler<CreateProdutoCommand, IResult>
{
    public async Task<IResult> Handler(CreateProdutoCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateProdutoCommandValidator();
    }
}