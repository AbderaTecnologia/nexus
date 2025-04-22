using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Nexus.Cadastro.Infra.Data.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder
            .HasOne(c => c.Contabilidade)
            .WithMany(c => c.Clientes)
            .HasForeignKey(c => c.ContabilidadeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .Property(c => c.Identifier)
            .HasMaxLength(14)
            .IsRequired();
    }
}