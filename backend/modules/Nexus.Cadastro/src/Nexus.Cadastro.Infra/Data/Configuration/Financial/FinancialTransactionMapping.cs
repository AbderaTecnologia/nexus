using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Nexus.Cadastro.Infra.Data.Configuration.Financial;

public class FinancialTransactionMapping : IEntityTypeConfiguration<FinancialTransaction>
{
    public void Configure(EntityTypeBuilder<FinancialTransaction> builder)
    {
        builder.ToTable("FinancialTransactions");

        builder.HasKey(ft => ft.Id);

        builder.HasOne(ft => ft.FinancialTransactionType)
            .WithMany()
            .HasForeignKey(ft => ft.FinancialTransactionTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ft => ft.FinancialTransactionCategory)
            .WithMany()
            .HasForeignKey(ft => ft.FinancialTransactionCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(ft => ft.FinancialTransactionSubCategory)
            .WithMany()
            .HasForeignKey(ft => ft.FinancialTransactionSubCategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(ft => ft.Amount)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

        builder.Property(ft => ft.Date)
            .IsRequired();

        builder.Property(ft => ft.Description)
            .HasMaxLength(500);
    }
}