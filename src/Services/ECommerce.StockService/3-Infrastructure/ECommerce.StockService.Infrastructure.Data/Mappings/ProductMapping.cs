using ECommerce.StockService.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.StockService.Infrastructure.Data.Mappings;

public class ProductMapping : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
        builder.Property(p => p.Description).HasColumnType("").HasMaxLength(500);
        builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)").HasColumnName("Price");
        builder.Property(p => p.StockQuantity).IsRequired().HasColumnType("").HasColumnName("StockQuantity");
        builder.Property(p => p.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");
        builder.Property(p => p.UpdatedAt).IsRequired().HasDefaultValueSql("GETDATE()");
        builder.Property(p => p.IsActive).IsRequired().HasDefaultValue(true);

        builder.ToTable("Products");
    }
}