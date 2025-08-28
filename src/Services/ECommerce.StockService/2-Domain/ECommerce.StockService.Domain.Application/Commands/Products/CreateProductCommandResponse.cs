namespace ECommerce.StockService.Domain.Application.Commands.Products;

public class CreateProductCommandResponse
{
    // public int Id { get; set; }
    // public string Name { get; set; } = string.Empty;
    // public string? Description { get; set; } = string.Empty;
    // public decimal Price { get; set; }
    // public int StockQuantity { get; set; }

    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;

    public CreateProductCommandResponse() { }

    public CreateProductCommandResponse(bool success, string message)
    {
        Success = true;
        Message = "Product created successfully.";
    }
}