using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Cadastro.Domain.Modules.Inventory;

namespace Nexus.Cadastro.Infra.Persistence.Mapping;

public class WarehouseMapping : IEntityTypeConfiguration<Warehouse>
{
    public void Configure(EntityTypeBuilder<Warehouse> builder)
    {
        builder.ToTable("Warehouses");

        builder.HasKey(w => w.Id);

        builder.Property(w => w.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(w => w.Address)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasMany(w => w.Stocks)
            .WithOne(s => s.Warehouse)
            .HasForeignKey(s => s.WarehouseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}