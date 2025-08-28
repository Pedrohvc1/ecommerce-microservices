using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.StockService.API.Controllers
{
    [ApiController]
    [Route("api/V{version:apiVersion}/[controller]")]
    public class BaseApiController : ControllerBase
    {
        private IMediator? _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>()!;
    }
}