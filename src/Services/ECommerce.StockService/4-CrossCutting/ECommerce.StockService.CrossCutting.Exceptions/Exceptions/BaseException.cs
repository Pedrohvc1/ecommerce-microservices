using System.Globalization;

namespace ECommerce.StockService.CrossCutting.Exceptions.Exceptions;

public class BaseException : Exception
{
    public BaseException() : base() { }

    public BaseException(string message) : base(message) { }

    public BaseException(string message, params object[] args)
        : base(string.Format(CultureInfo.InvariantCulture, message, args))
    {
    }

    public BaseException(string message, Exception innerException) : base(message, innerException)
    {
    }
}