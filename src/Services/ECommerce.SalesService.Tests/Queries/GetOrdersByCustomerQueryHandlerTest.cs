using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.SalesService.Domain.Application.Queries.GetOrdersByCustomer;
using ECommerce.SalesService.Domain.Core.Entities;
using ECommerce.SalesService.Domain.Core.Enums;
using ECommerce.SalesService.Domain.Core.Interfaces.Repositories;
using Moq;
using Xunit;

namespace ECommerce.SalesService.Tests.Queries;

public class GetOrdersByCustomerQueryHandlerTest
{
    [Fact]
    public async Task Handle_ShouldReturnMappedOrders_WhenOrdersExist()
    {
        // Arrange
        var mockRepo = new Mock<IOrderRepository>();
        var mockMapper = new Mock<IMapper>();
        var orders = new List<Order>
        {
            new Order 
            { 
                Id = 1, 
                CustomerName = "Customer 1", 
                CustomerEmail = "customer1@example.com",
                OrderDate = DateTime.UtcNow,
                Status = EOrderStatus.Pending,
                TotalAmount = 100,
                Items = new List<OrderItem>
                {
                    new OrderItem { Id = 1, ProductId = 1, ProductName = "Product 1", UnitPrice = 50, Quantity = 2, Subtotal = 100 }
                }
            }
        };
        var mapped = new List<GetOrdersByCustomerQueryResponse>
        {
            new GetOrdersByCustomerQueryResponse 
            { 
                Id = 1, 
                CustomerName = "Customer 1", 
                CustomerEmail = "customer1@example.com",
                TotalAmount = 100,
                Status = EOrderStatus.Pending	
            }
        };
        
        // Setup(r => r.GetOrdersByCustomerEmailAsync("customer1@example.com")).ReturnsAsync(orders);
        mockMapper.Setup(m => m.Map<IEnumerable<GetOrdersByCustomerQueryResponse>>(It.IsAny<IEnumerable<Order>>())).Returns(mapped);
        var handler = new GetOrdersByCustomerQueryHandler(mockMapper.Object, mockRepo.Object);

        // Act
        var result = await handler.Handle(new GetOrdersByCustomerQueryRequest { CustomerEmail = "customer1@example.com" }, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal("Customer 1", result.First().CustomerName);
    }

    [Fact]
    public async Task Handle_ShouldThrowException_WhenRepositoryThrows()
    {
        // Arrange
        var mockRepo = new Mock<IOrderRepository>();
        var mockMapper = new Mock<IMapper>();
        mockRepo.Setup(r => r.GetOrdersByCustomerEmailAsync(It.IsAny<string>())).ThrowsAsync(new Exception("DB error"));
        var handler = new GetOrdersByCustomerQueryHandler(mockMapper.Object, mockRepo.Object);

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => handler.Handle(new GetOrdersByCustomerQueryRequest { CustomerEmail = "test@example.com" }, CancellationToken.None));
    }
}
