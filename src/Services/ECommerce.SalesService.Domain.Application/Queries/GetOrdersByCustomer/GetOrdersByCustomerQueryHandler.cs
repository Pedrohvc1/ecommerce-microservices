using AutoMapper;
using ECommerce.SalesService.Domain.Core.Interfaces.Repositories;
using MediatR;

namespace ECommerce.SalesService.Domain.Application.Queries.GetOrdersByCustomer;

public class GetOrdersByCustomerQueryHandler : IRequestHandler<GetOrdersByCustomerQueryRequest, IEnumerable<GetOrdersByCustomerQueryResponse>>
{
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;

    public GetOrdersByCustomerQueryHandler(IMapper mapper, IOrderRepository orderRepository)
    {
        _mapper = mapper;
        _orderRepository = orderRepository;
    }

    public async Task<IEnumerable<GetOrdersByCustomerQueryResponse>> Handle(GetOrdersByCustomerQueryRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var orders = await _orderRepository.GetOrdersByCustomerEmailAsync(request.CustomerEmail);
            return _mapper.Map<IEnumerable<GetOrdersByCustomerQueryResponse>>(orders);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception("Erro interno ao consultar os pedidos do cliente", e);
        }
    }
}