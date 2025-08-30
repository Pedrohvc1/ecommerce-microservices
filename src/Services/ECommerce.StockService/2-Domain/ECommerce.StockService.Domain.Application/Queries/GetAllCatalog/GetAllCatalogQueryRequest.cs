using MediatR;

namespace ECommerce.StockService.Domain.Application.Queries.GetAllCatalog;

public class GetAllCatalogQueryRequest : IRequest<IEnumerable<GetAllCatalogQueryResponse>>
{
}