using AutoMapper;
using ECommerce.SalesService.Domain.Application.Commands.CreateOrder;
using ECommerce.SalesService.Domain.Application.Queries.GetOrdersByCustomer;
using ECommerce.SalesService.Domain.Core.Entities;

namespace ECommerce.SalesService.Domain.Application.Mapper;

public class ProfileAutomapper : Profile
{
    public ProfileAutomapper()
    {
        // Mapeamento para Commands
        CreateMap<CreateOrderCommandRequest, Order>();
        CreateMap<OrderItemRequest, OrderItem>();
        CreateMap<Order, CreateOrderCommandResponse>();

        // Mapeamento para Queries
        CreateMap<Order, GetOrdersByCustomerQueryResponse>();
        CreateMap<OrderItem, OrderItemResponse>();
    }
}