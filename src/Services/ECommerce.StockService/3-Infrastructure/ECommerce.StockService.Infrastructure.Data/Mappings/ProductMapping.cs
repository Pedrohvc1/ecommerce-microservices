using ECommerce.StockService.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.StockService.Infrastructure.Data.Mappings;

public class ProductMapping : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .IsRequired()
            .HasColumnType("serial4")
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Name)
            .IsRequired()
            .HasColumnType("varchar(255)")
            .HasColumnName("nome")
            .HasMaxLength(255);

        builder.Property(p => p.Description)
            .HasColumnType("text")
            .HasColumnName("descricao")
            .IsRequired(false);

        builder.Property(p => p.Price)
            .IsRequired()
            .HasColumnType("numeric(10,2)")
            .HasColumnName("preco");

        builder.Property(p => p.StockQuantity)
            .IsRequired()
            .HasColumnType("int4")
            .HasColumnName("quantidade_estoque")
            .HasDefaultValue(0);

        builder.Property(p => p.CreatedAt)
            .HasColumnType("timestamp")
            .HasColumnName("criado_em")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(p => p.UpdatedAt)
            .HasColumnType("timestamp")
            .HasColumnName("atualizado_em")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.ToTable("produtos", schema: "public");
    }
}