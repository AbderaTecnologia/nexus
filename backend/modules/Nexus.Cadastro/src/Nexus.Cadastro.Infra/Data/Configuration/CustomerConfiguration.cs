using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Nexus.Cadastro.Infra.Data.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<CompanyTenent>
    {
        public void Configure(EntityTypeBuilder<CompanyTenent> builder)
        {
            builder
                .HasOne(c => c.Contabilidade)
                .WithMany(c => c.Clientes)
                .HasForeignKey(c => c.ContabilidadeId);

            builder
                .Property(c => c.Identifier)
                .HasMaxLength(14)
                .IsRequired();
        }
    }
}