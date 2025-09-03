using ECommerce.SalesService.Domain.Application.Commands.CreateOrder;
using ECommerce.SalesService.Domain.Application.Queries.GetOrdersByCustomer;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.SalesService.API.Controllers.V1;

public class OrderController : BaseApiController
{
    /// <summary>
    /// Creates a new order.
    /// </summary>
    /// <param name="command">Command containing the necessary data to create the order.</param>
    /// <returns>
    /// Returns HTTP 201 (Created) status with the result of the order creation.
    /// </returns>
    [HttpPost]
    public async Task<IActionResult> CreateOrderAsync([FromBody] CreateOrderCommandRequest command)
    {
        var result = await Mediator.Send(command);
        return Created(string.Empty, result);
    }

    /// <summary>
    /// Retrieves orders by customer email.
    /// </summary>
    /// <param name="customerEmail">Customer email to filter orders.</param>
    /// <param name="request"></param>
    /// <returns>
    /// Returns HTTP 200 (OK) with the list of orders for the specified customer.
    /// </returns>
    [HttpGet("customer")]
    public async Task<IActionResult> GetOrdersByCustomerAsync([FromQuery] GetOrdersByCustomerQueryRequest request)
    {
        var result = await Mediator.Send(request);
        return Ok(result);
    }
}