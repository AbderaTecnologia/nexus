using Nexus.Cadastro.Infra.Persistence;
using Nexus.Core.Application.Models;

namespace Nexus.Cadastro.Application.Handlers.Products.Delete;

public sealed record DeleteProductCommand(Guid Id) : IRequest<IResult>
{
}

public class DeleteProductCommandHandler(
    CadastroDbContext cadastroDbContext,
    IHttpContextAccessor httpContextAccessor
) : IRequestHandler<DeleteProductCommand, IResult>
{
    public async Task<IResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var user = AuthenticatedUser.FromClaimsPrincipal(httpContextAccessor.HttpContext!.User);
        if (user.UserId == Guid.Empty)
        {
            return Unauthorized();
        }

        var product = await cadastroDbContext.Products.FindAsync([request.Id], cancellationToken: cancellationToken);
        if (product == null)
        {
            return NotFound();
        }

        product.Delete(user.UserId);
        cadastroDbContext.Products.Update(product);
        await cadastroDbContext.SaveChangesAsync(cancellationToken);

        return NoContent();
    }
}