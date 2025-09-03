using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.SalesService.API.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/V{version:apiVersion}/[controller]")]
public abstract class BaseApiController : ControllerBase
{
    private IMediator? _mediator;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
}