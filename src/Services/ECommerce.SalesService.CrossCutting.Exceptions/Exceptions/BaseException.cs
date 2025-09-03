namespace ECommerce.SalesService.CrossCutting.Exceptions.Exceptions;

public abstract class BaseException : Exception
{
    protected BaseException(string message) : base(message)
    {
    }

    protected BaseException(string message, Exception innerException) : base(message, innerException)
    {
    }
}