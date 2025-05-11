using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Cadastro.Domain.Modules.Finance;

namespace Nexus.Cadastro.Infra.Data.Configuration.Financial;

public class FinancialTransactionSubCategoryMapping : IEntityTypeConfiguration<FinancialTransactionSubCategory>
{
    public void Configure(EntityTypeBuilder<FinancialTransactionSubCategory> builder)
    {
        builder.ToTable("FinancialTransactionSubCategories");

        builder.HasKey(ftsc => ftsc.Id);

        builder.HasOne(ftsc => ftsc.FinancialTransactionCategory)
            .WithMany()
            .HasForeignKey(ftsc => ftsc.FinancialTransactionCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(ftsc => ftsc.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(ftsc => ftsc.Description)
            .HasMaxLength(250);

        builder.Property(ftsc => ftsc.IsActive)
            .IsRequired();
    }
}