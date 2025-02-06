using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Nexus.Core.Domain.Entities;
using Nexus.Core.Infra.Interceptors;

namespace Nexus.Cadastro.Infra.Persistence;

public class CadastroDbContext(DbContextOptions<CadastroDbContext> options, CompanyIdInterceptor companyIdInterceptor) : DbContext(options)
{
    public DbSet<Company> Companies { get; set; }
    public DbSet<Contabilidade> Contabilidades { get; set; }
    public DbSet<Cliente> Clientes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>()
            .HasDiscriminator<string>("CompanyType")
            .HasValue<Contabilidade>("Contabilidade")
            .HasValue<Cliente>("Cliente");

        modelBuilder.Entity<Company>()
            .Property(c => c.Id)
            .HasValueGenerator<GuidValueGenerator>();

        modelBuilder.Entity<Company>()
            .Property(c => c.Name)
            .HasMaxLength(100)
            .IsRequired();

        modelBuilder.Entity<Company>()
            .Property(c => c.Email)
            .HasMaxLength(100)
            .IsRequired();

        modelBuilder.Entity<Contabilidade>()
            .HasMany(c => c.Clientes)
            .WithOne(c => c.Contabilidade)
            .HasForeignKey(c => c.ContabilidadeId);

        modelBuilder.Entity<Cliente>()
            .HasOne(c => c.Contabilidade)
            .WithMany(c => c.Clientes)
            .HasForeignKey(c => c.ContabilidadeId);

        modelBuilder.Entity<Cliente>()
            .Property(c => c.Identifier)
            .HasMaxLength(14)
            .IsRequired();

        modelBuilder.Entity<Cliente>()
            .HasQueryFilter(c => EF.Property<Guid>(c, "ContabilidadeId") == companyIdInterceptor.CompanyId);
    }
}