using Microsoft.EntityFrameworkCore;
using Nexus.Core.Domain.Entities;
using Nexus.Core.Infra.Interceptors;

namespace Nexus.Cadastro.Infra.Data;

public class CadastroDbContext(DbContextOptions<CadastroDbContext> options, CompanyIdInterceptor companyIdInterceptor) : DbContext(options)
{
    public DbSet<Company> Companies { get; set; }
}