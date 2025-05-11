using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nexus.Cadastro.Domain.Modules.POS;

namespace Nexus.Cadastro.Infra.Persistence.Mapping;

public class DeliveryAddressMapping : IEntityTypeConfiguration<DeliveryAddress>
{
    public void Configure(EntityTypeBuilder<DeliveryAddress> builder)
    {
        builder.ToTable("DeliveryAddresses");

        builder.HasKey(da => da.Id);

        builder.Property(da => da.Street)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(da => da.City)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(da => da.State)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(da => da.PostalCode)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(da => da.Country)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasOne(da => da.Customer)
            .WithMany(c => c.DeliveryAddresses)
            .HasForeignKey(da => da.CustomerId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}