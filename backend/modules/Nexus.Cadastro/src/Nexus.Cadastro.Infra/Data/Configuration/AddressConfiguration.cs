using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Nexus.Cadastro.Infra.Data.Configuration;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder
            .Property(a => a.Street)
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(a => a.Number)
            .HasMaxLength(10)
            .IsRequired();

        builder
            .Property(a => a.Complement)
            .HasMaxLength(50);

        builder
            .Property(a => a.Neighborhood)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(a => a.City)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(a => a.State)
            .HasMaxLength(2)
            .IsRequired();

        builder
            .Property(a => a.Country)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(a => a.ZipCode)
            .HasMaxLength(8)
            .IsRequired();
    }
}