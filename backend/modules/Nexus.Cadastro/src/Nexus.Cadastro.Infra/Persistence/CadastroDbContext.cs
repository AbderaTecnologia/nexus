using Nexus.Cadastro.Domain.Modules.Finance;
using Nexus.Cadastro.Infra.Data.Configuration;
using Nexus.Cadastro.Infra.Data.Configuration.Financial;

namespace Nexus.Cadastro.Infra.Persistence;

public class CadastroDbContext(DbContextOptions<CadastroDbContext> options, AuditableEntityInterceptor companyIdInterceptor) : DbContext(options)
{
    public DbSet<Company> Companies { get; set; }
    public DbSet<AccountingTenant> Contabilidades { get; set; }
    public DbSet<CompanyTenant> Clientes { get; set; }

    #region [Modules] - [Finance]
    public DbSet<FinancialAccount> FinancialAccounts { get; set; }
    public DbSet<FinancialTransaction> FinancialTransactions { get; set; }
    public DbSet<FinancialTransactionType> FinancialTransactionTypes { get; set; }
    public DbSet<FinancialTransactionCategory> FinancialTransactionCategories { get; set; }
    public DbSet<FinancialTransactionSubCategory> FinancialTransactionSubCategories { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>()
            .HasDiscriminator<string>("CompanyType")
            .HasValue<AccountingTenant>("Accounting")
            .HasValue<CompanyTenant>("CompanyTenant");

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

        modelBuilder.Entity<Company>()
            .HasOne(c => c.Address)
            .WithOne(a => a.Company)
            .HasForeignKey<Address>(a => a.CompanyId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Company>()
            .HasQueryFilter(c => EF.Property<Guid>(c, "ContabilidadeId") == companyIdInterceptor.CompanyId);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FinancialTransactionTypeConfiguration).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(companyIdInterceptor);
    }
}