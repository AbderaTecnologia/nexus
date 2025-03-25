namespace Nexus.Cadastro.Infra.Persistence;

public class CadastroDbContext(DbContextOptions<CadastroDbContext> options, AuditableEntityInterceptor companyIdInterceptor) : DbContext(options)
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

        modelBuilder.Entity<Company>()
            .HasQueryFilter(c => EF.Property<Guid>(c, "ContabilidadeId") == companyIdInterceptor.CompanyId);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CadastroDbContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(companyIdInterceptor);
    }
}