namespace ECommerce.SalesService.Domain.Application.Commands.CreateOrder;

public class CreateOrderCommandResponse
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public int OrderId { get; set; }
    public decimal TotalAmount { get; set; }

    public CreateOrderCommandResponse() { }

    public CreateOrderCommandResponse(bool success, string message, int orderId = 0, decimal totalAmount = 0)
    {
        Success = success;
        Message = message;
        OrderId = orderId;
        TotalAmount = totalAmount;
    }
}