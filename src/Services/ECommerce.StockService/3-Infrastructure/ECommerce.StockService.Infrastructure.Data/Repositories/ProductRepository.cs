using ECommerce.StockService.Domain.Core.Entities;
using ECommerce.StockService.Domain.Core.Interfaces.Repositories;
using ECommerce.StockService.Infrastructure.Data.Context;

namespace ECommerce.StockService.Infrastructure.Data.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(StockServiceDbContext context) : base(context)
    {
    }
    // Métodos específicos de Product podem ser adicionados aqui
}