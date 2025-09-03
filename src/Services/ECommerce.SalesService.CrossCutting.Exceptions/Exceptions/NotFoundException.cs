using System.Net;

namespace ECommerce.SalesService.CrossCutting.Exceptions.Exceptions;

public class NotFoundException : BaseException
{
    public HttpStatusCode StatusCode { get; }

    public NotFoundException(string message) : base(message)
    {
        StatusCode = HttpStatusCode.NotFound;
    }

    public NotFoundException(string message, HttpStatusCode statusCode) : base(message)
    {
        StatusCode = statusCode;
    }
}