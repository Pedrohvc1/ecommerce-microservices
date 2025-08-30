namespace ECommerce.StockService.Domain.Application.Commands.CreateProduct;

public class CreateProductCommandResponse
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;

    public CreateProductCommandResponse() { }

    public CreateProductCommandResponse(bool success, string message)
    {
        Success = success;
        Message = message;
    }
}