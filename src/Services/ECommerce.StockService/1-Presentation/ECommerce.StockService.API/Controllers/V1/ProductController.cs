using ECommerce.StockService.Domain.Application.Commands.CreateProduct;
using ECommerce.StockService.Domain.Application.Queries.GetAllCatalog;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.StockService.API.Controllers.V1;

public class ProductController : BaseApiController
{
    /// <summary>
    /// Creates a new product.
    /// </summary>
    /// <param name="command">Command containing the necessary data to create the product.</param>
    /// <returns>
    /// Returns HTTP 200 (OK) status with the result of the product creation.
    /// </returns>
    [HttpPost]
    public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductCommandRequest command)
    {
        var result = await Mediator.Send(command);
        return Created(string.Empty, result);
    }

    /// <summary>
    /// Retrieves all products in the catalog.
    /// </summary>
    /// <returns>
    /// Returns HTTP 200 (OK) status with a list of all products in the catalog.
    /// </returns>
    [HttpGet]
    public async Task<IActionResult> GetAllCatalogAsync()
    {
        var result = await Mediator.Send(new GetAllCatalogQueryRequest());
        return Ok(result);
    }
}