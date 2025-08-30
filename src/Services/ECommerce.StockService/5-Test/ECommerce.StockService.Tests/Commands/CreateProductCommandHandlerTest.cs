using AutoMapper;
using ECommerce.StockService.CrossCutting.Exceptions.Exceptions;
using ECommerce.StockService.Domain.Application.Commands.CreateProduct;
using ECommerce.StockService.Domain.Core.Entities;
using ECommerce.StockService.Domain.Core.Interfaces.Repositories;
using Moq;

namespace ECommerce.StockService.Tests.Commands;

public class CreateProductCommandHandlerTest
{
    [Fact]
    public async Task Handle_ShouldReturnSuccessResponse_WhenProductIsCreated()
    {
        // Arrange
        var mockRepo = new Mock<IProductRepository>();
        var mockMapper = new Mock<IMapper>();
        var command = new CreateProductCommandRequest { Name = "Test", Price = 10, StockQuantity = 5 };
        var product = new Product { Name = "Test", Price = 10, StockQuantity = 5 };
        var response = new CreateProductCommandResponse(true, "Product created successfully.");

        mockMapper.Setup(m => m.Map<Product>(command)).Returns(product);
        mockRepo.Setup(r => r.AddAsync(product)).Returns(Task.CompletedTask);
        mockMapper.Setup(m => m.Map<CreateProductCommandResponse>(product)).Returns(response);

        var handler = new CreateProductCommandHandler(mockRepo.Object, mockMapper.Object);

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.True(result.Success);
        Assert.Equal("Product created successfully.", result.Message);
    }

    [Fact]
    public async Task Handle_ShouldThrowBadRequestException_WhenRepositoryThrows()
    {
        // Arrange
        var mockRepo = new Mock<IProductRepository>();
        var mockMapper = new Mock<IMapper>();
        var command = new CreateProductCommandRequest { Name = "Test", Price = 10, StockQuantity = 5 };
        var product = new Product { Name = "Test", Price = 10, StockQuantity = 5 };

        mockMapper.Setup(m => m.Map<Product>(command)).Returns(product);
        mockRepo.Setup(r => r.AddAsync(product)).ThrowsAsync(new Exception("DB error"));

        var handler = new CreateProductCommandHandler(mockRepo.Object, mockMapper.Object);

        // Act & Assert
        await Assert.ThrowsAsync<BadRequestException>(() => handler.Handle(command, CancellationToken.None));
    }
}

