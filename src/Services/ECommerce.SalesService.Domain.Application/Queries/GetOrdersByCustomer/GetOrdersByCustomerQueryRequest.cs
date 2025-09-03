using MediatR;

namespace ECommerce.SalesService.Domain.Application.Queries.GetOrdersByCustomer;

public class GetOrdersByCustomerQueryRequest : IRequest<IEnumerable<GetOrdersByCustomerQueryResponse>>
{
    public string CustomerEmail { get; set; } = string.Empty;
}