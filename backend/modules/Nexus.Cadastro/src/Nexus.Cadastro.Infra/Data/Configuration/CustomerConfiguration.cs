using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Nexus.Cadastro.Infra.Data.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<CompanyTenant>
    {
        public void Configure(EntityTypeBuilder<CompanyTenant> builder)
        {
            builder
                .HasOne(c => c.Contabilidade)
                .WithMany(c => c.Clientes)
                .HasForeignKey(c => c.AccountingId);

            builder
                .Property(c => c.Identifier)
                .HasMaxLength(14)
                .IsRequired();
        }
    }
}