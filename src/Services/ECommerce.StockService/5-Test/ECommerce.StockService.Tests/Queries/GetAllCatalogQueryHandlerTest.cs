using AutoMapper;
using ECommerce.StockService.Domain.Application.Queries.GetAllCatalog;
using ECommerce.StockService.Domain.Core.Entities;
using ECommerce.StockService.Domain.Core.Interfaces.Repositories;
using Moq;

namespace ECommerce.StockService.Tests.Queries;

public class GetAllCatalogQueryHandlerTest
{
    [Fact]
    public async Task Handle_ShouldReturnMappedProducts_WhenProductsExist()
    {
        // Arrange
        var mockRepo = new Mock<IProductRepository>();
        var mockMapper = new Mock<IMapper>();
        var products = new List<Product>
        {
            new Product { Id = 1, Name = "A", Price = 10, StockQuantity = 5 },
            new Product { Id = 2, Name = "B", Price = 20, StockQuantity = 10 }
        };
        var mapped = new List<GetAllCatalogQueryResponse>
        {
            new GetAllCatalogQueryResponse { Id = 1, Name = "A", Price = 10, StockQuantity = 5 },
            new GetAllCatalogQueryResponse { Id = 2, Name = "B", Price = 20, StockQuantity = 10 }
        };
        mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(products);
        mockMapper.Setup(m => m.Map<IEnumerable<GetAllCatalogQueryResponse>>(It.IsAny<IEnumerable<Product>>())).Returns(mapped);
        var handler = new GetAllCatalogQueryHandler(mockMapper.Object, mockRepo.Object);

        // Act
        var result = await handler.Handle(new GetAllCatalogQueryRequest(), CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count());
        Assert.Equal("A", result.First().Name);
    }

    [Fact]
    public async Task Handle_ShouldThrowException_WhenRepositoryThrows()
    {
        // Arrange
        var mockRepo = new Mock<IProductRepository>();
        var mockMapper = new Mock<IMapper>();
        mockRepo.Setup(r => r.GetAllAsync()).ThrowsAsync(new Exception("DB error"));
        var handler = new GetAllCatalogQueryHandler(mockMapper.Object, mockRepo.Object);

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => handler.Handle(new GetAllCatalogQueryRequest(), CancellationToken.None));
    }
}