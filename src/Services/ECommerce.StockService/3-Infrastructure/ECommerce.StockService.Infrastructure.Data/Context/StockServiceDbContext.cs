using ECommerce.StockService.Domain.Core.Entities;
using Microsoft.EntityFrameworkCore;
using ECommerce.StockService.Infrastructure.Data.Mappings;

namespace ECommerce.StockService.Infrastructure.Data.Context;

public class StockServiceDbContext : DbContext
{
    public StockServiceDbContext(DbContextOptions<StockServiceDbContext> options)
        : base(options)
    {
    }

    #region Tables

    public DbSet<Product> Products { get; set; } = null!;

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductMapping());
        base.OnModelCreating(modelBuilder);
    }
}