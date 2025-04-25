using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Cadastro.Domain.Modules.Finance;

namespace Nexus.Cadastro.Infra.Data.Configuration.Financial;

public class FinancialTransactionCategoryMapping : IEntityTypeConfiguration<FinancialTransactionCategory>
{
    public void Configure(EntityTypeBuilder<FinancialTransactionCategory> builder)
    {
        builder.ToTable("FinancialTransactionCategories");

        builder.HasKey(ftc => ftc.Id);

        builder.Property(ftc => ftc.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(ftc => ftc.Description)
            .HasMaxLength(250);
    }
}