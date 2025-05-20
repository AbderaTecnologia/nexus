using System.Data.Entity.ModelConfiguration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Nexus.Cadastro.Infra.Data.Configuration;

public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("Produto");
        
        builder.HasKey(x => x.Id);

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Preco)
            .IsRequired()
            .HasColumnType("decimal");
        
        builder.Property(p => p.Estoque)
            .IsRequired()
            .HasColumnType("inteiro");

        builder.Property(p => p.Descricao)
            .IsRequired()
            .HasMaxLength(800);
    }
}