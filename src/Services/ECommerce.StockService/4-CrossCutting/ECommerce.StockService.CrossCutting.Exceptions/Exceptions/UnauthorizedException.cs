using System.Net;

namespace ECommerce.StockService.CrossCutting.Exceptions.Exceptions;

public class UnauthorizedException : BaseException
{
    public HttpStatusCode StatusCode { get; }

    public UnauthorizedException(string message)
        : base(message)
    {
        StatusCode = HttpStatusCode.Unauthorized;
    }

    public UnauthorizedException(string message, HttpStatusCode statusCode)
        : base(message)
    {
        StatusCode = statusCode;
    }
}