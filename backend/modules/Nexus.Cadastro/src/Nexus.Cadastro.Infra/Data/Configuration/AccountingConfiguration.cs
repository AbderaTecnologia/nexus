using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Nexus.Cadastro.Infra.Data.Configuration
{
    public class AccountingConfiguration : IEntityTypeConfiguration<Contabilidade>
    {
        public void Configure(EntityTypeBuilder<Contabilidade> builder)
        {
            builder
                .HasMany(c => c.Clientes)
                .WithOne(c => c.Contabilidade)
                .HasForeignKey(c => c.ContabilidadeId);
        }
    }
}