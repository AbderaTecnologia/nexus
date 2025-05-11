using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Cadastro.Domain.Modules.Inventory;

namespace Nexus.Cadastro.Infra.Persistence.Mapping;

public class StockMapping : IEntityTypeConfiguration<Stock>
{
    public void Configure(EntityTypeBuilder<Stock> builder)
    {
        builder.ToTable("Stocks");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Quantity)
            .IsRequired();

        builder.HasOne(s => s.Product)
            .WithMany(p => p.Stocks)
            .HasForeignKey(s => s.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(s => s.Warehouse)
            .WithMany(l => l.Stocks)
            .HasForeignKey(s => s.WarehouseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}