using ECommerce.SalesService.Domain.Core.Entities;
using ECommerce.SalesService.Domain.Core.Interfaces.Repositories;
using ECommerce.SalesService.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.SalesService.Infrastructure.Data.Repositories;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(SalesServiceDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Order>> GetOrdersByCustomerEmailAsync(string customerEmail)
    {
        return await DbSet
            .Include(o => o.Items)
            .Where(o => o.CustomerEmail == customerEmail)
            .OrderByDescending(o => o.OrderDate)
            .ToListAsync();
    }

    public async Task<Order?> GetOrderWithItemsAsync(int orderId)
    {
        return await DbSet
            .Include(o => o.Items)
            .FirstOrDefaultAsync(o => o.Id == orderId);
    }
}