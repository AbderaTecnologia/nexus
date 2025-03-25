using System.Data.Entity.ModelConfiguration;

namespace Nexus.Cadastro.Infra.Data.Configuration
{
    public class AddressConfiguration : EntityTypeConfiguration<Address>
    {
        public AddressConfiguration()
        {
            ToTable("Addresses");

            HasKey(a => a.Id);

            Property(a => a.Street)
                .IsRequired()
                .HasMaxLength(200);

            Property(a => a.Number)
                .IsRequired()
                .HasMaxLength(50);

            Property(a => a.Complement)
                .HasMaxLength(100);

            Property(a => a.Neighborhood)
                .IsRequired()
                .HasMaxLength(100);

            Property(a => a.City)
                .IsRequired()
                .HasMaxLength(100);

            Property(a => a.State)
                .IsRequired()
                .HasMaxLength(50);

            Property(a => a.Country)
                .IsRequired()
                .HasMaxLength(100);

            Property(a => a.ZipCode)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}