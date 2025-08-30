using AutoMapper;
using ECommerce.StockService.Domain.Core.Interfaces.Repositories;
using MediatR;

namespace ECommerce.StockService.Domain.Application.Queries.GetAllCatalog;

public class
    GetAllCatalogQueryHandler : IRequestHandler<GetAllCatalogQueryRequest, IEnumerable<GetAllCatalogQueryResponse>>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public GetAllCatalogQueryHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    /// <summary>
    /// Handle the GetAllCatalog query to retrieve all products from the repository and map them to the response DTO.
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IEnumerable<GetAllCatalogQueryResponse>> Handle(GetAllCatalogQueryRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var products = await _productRepository.GetAllAsync();
            var sortedProducts = products.OrderBy(x => x.Name);
            return _mapper.Map<IEnumerable<GetAllCatalogQueryResponse>>(sortedProducts);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}