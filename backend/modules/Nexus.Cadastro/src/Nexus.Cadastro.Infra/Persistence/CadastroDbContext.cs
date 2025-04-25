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

    #region [Modules] - [Inventory]
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }

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

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CadastroDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(companyIdInterceptor);
    }
}