using ECommerce.StockService.Domain.Application.Commands.Products;
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
    public async Task<IActionResult> CreateAsync([FromBody] CreateProductCommandRequest command)
    {
        return Ok(await Mediator.Send(command));
    }

    // // Placeholder para o método GetById
    // [HttpGet("{id}")]
    // public IActionResult GetById(int id)
    // {
    //     return Ok();
    // }
}