using System.Net;

namespace ECommerce.StockService.CrossCutting.Exceptions.Exceptions;

public class BadRequestException : BaseException
{
    public HttpStatusCode StatusCode { get; }

    public BadRequestException(string message)
        : base(message)
    {
        StatusCode = HttpStatusCode.BadRequest;
    }

    public BadRequestException(string message, HttpStatusCode statusCode)
        : base(message)
    {
        StatusCode = statusCode;
    }
}