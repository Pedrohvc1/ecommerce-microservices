using AutoMapper;
using ECommerce.StockService.Domain.Application.Commands.CreateProduct;
using ECommerce.StockService.Domain.Application.Queries.GetAllCatalog;
using ECommerce.StockService.Domain.Core.Entities;

namespace ECommerce.StockService.Domain.Application.Mapper;

public class ProfileAutomapper : Profile
{
    public ProfileAutomapper()
    {
        CreateMap<CreateProductCommandRequest, Product>();
        CreateMap<Product, CreateProductCommandResponse>();
        CreateMap<Product, GetAllCatalogQueryResponse>();
    }
}