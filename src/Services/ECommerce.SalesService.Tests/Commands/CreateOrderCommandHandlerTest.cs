using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ECommerce.SalesService.CrossCutting.Exceptions.Exceptions;
using ECommerce.SalesService.Domain.Application.Commands.CreateOrder;
using ECommerce.SalesService.Domain.Core.Entities;
using ECommerce.SalesService.Domain.Core.Interfaces.Repositories;
using Moq;
using Xunit;

namespace ECommerce.SalesService.Tests.Commands;

public class CreateOrderCommandHandlerTest
{
    [Fact]
    public async Task Handle_ShouldReturnSuccessResponse_WhenOrderIsCreated()
    {
        // Arrange
        var mockRepo = new Mock<IOrderRepository>();
        var mockMapper = new Mock<IMapper>();
        var command = new CreateOrderCommandRequest 
        { 
            CustomerName = "Test Customer", 
            CustomerEmail = "test@example.com",
            Items = new List<OrderItemRequest>
            {
                new OrderItemRequest { ProductId = 1, ProductName = "Product 1", UnitPrice = 10, Quantity = 2 }
            }
        };

        mockRepo.Setup(r => r.AddAsync(It.IsAny<Order>())).Returns(Task.CompletedTask);
        var handler = new CreateOrderCommandHandler(mockRepo.Object, mockMapper.Object);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.True(result.Success);
        Assert.Equal("Pedido criado com sucesso", result.Message);
        Assert.Equal(20, result.TotalAmount);
    }

    [Fact]
    public async Task Handle_ShouldThrowBadRequestException_WhenNoItemsProvided()
    {
        // Arrange
        var mockRepo = new Mock<IOrderRepository>();
        var mockMapper = new Mock<IMapper>();
        var command = new CreateOrderCommandRequest 
        { 
            CustomerName = "Test Customer", 
            CustomerEmail = "test@example.com",
            Items = new List<OrderItemRequest>()
        };

        var handler = new CreateOrderCommandHandler(mockRepo.Object, mockMapper.Object);

        // Act & Assert
        await Assert.ThrowsAsync<BadRequestException>(() => handler.Handle(command, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_ShouldThrowBadRequestException_WhenRepositoryThrows()
    {
        // Arrange
        var mockRepo = new Mock<IOrderRepository>();
        var mockMapper = new Mock<IMapper>();
        var command = new CreateOrderCommandRequest 
        { 
            CustomerName = "Test Customer", 
            CustomerEmail = "test@example.com",
            Items = new List<OrderItemRequest>
            {
                new OrderItemRequest { ProductId = 1, ProductName = "Product 1", UnitPrice = 10, Quantity = 2 }
            }
        };

        mockRepo.Setup(r => r.AddAsync(It.IsAny<Order>())).ThrowsAsync(new Exception("DB error"));
        var handler = new CreateOrderCommandHandler(mockRepo.Object, mockMapper.Object);

        // Act & Assert
        await Assert.ThrowsAsync<BadRequestException>(() => handler.Handle(command, CancellationToken.None));
    }
}
