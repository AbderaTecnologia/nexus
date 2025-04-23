using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Nexus.Cadastro.Infra.Data.Configuration
{
    public class AccountingConfiguration : IEntityTypeConfiguration<AccountingTenant>
    {
        public void Configure(EntityTypeBuilder<AccountingTenant> builder)
        {
            builder
                .HasMany(c => c.Clientes)
                .WithOne(c => c.Contabilidade)
                .HasForeignKey(c => c.ContabilidadeId);
        }
    }
}