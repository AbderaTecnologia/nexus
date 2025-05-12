using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Moq;
using Nexus.Core.Infra.Persistence;

namespace Nexus.Cadastro.Application.Produtos.Queries;

public class ProdutosQueryHandlerTests
{
    private readonly Mock<ApplicationDbContext> _mockContext;
    private readonly ProdutosQueryHandler _handler;

    public ProdutosQueryHandlerTests()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase("TestDb")
            .Options;

        var context = new ApplicationDbContext(options);
        Seed(context);
        
        _mockContext = new Mock<ApplicationDbContext>(options);
        _mockContext.Setup(c => ApplicationDbContext.Produtos).Returns(context.Produtos);

    }
}