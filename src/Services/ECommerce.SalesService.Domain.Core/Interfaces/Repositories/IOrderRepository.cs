using ECommerce.SalesService.Domain.Core.Entities;

namespace ECommerce.SalesService.Domain.Core.Interfaces.Repositories;

public interface IOrderRepository : IBaseRepository<Order>
{
    Task<IEnumerable<Order>> GetOrdersByCustomerEmailAsync(string customerEmail);
    Task<Order?> GetOrderWithItemsAsync(int orderId);
}