using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Cadastro.Domain.Modules.Finance;

namespace Nexus.Cadastro.Infra.Data.Configuration.Financial;

public class FinancialTransactionTypeConfiguration : IEntityTypeConfiguration<FinancialTransactionType>
{
    public void Configure(EntityTypeBuilder<FinancialTransactionType> builder)
    {
        builder.ToTable("FinancialTransactionTypes");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(x => x.IsActive)
            .IsRequired();

        builder.Property(x => x.IsDefault)
            .IsRequired();

        builder.HasIndex(ft => new { ft.IsDefault, ft.CompanyId })
            .HasDatabaseName("IX_FinancialTransactionType_Default_Company")
            .IsUnique(false);
    }
}