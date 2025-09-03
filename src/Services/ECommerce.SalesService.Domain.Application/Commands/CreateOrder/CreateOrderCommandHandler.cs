using AutoMapper;
using ECommerce.SalesService.CrossCutting.Exceptions.Exceptions;
using ECommerce.SalesService.Domain.Core.Entities;
using ECommerce.SalesService.Domain.Core.Enums;
using ECommerce.SalesService.Domain.Core.Interfaces.Repositories;
using MediatR;

namespace ECommerce.SalesService.Domain.Application.Commands.CreateOrder;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest command, CancellationToken cancellationToken)
    {
        try
        {
            // Validar se o comando tem itens
            if (!command.Items.Any())
            {
                throw new BadRequestException("O pedido deve conter pelo menos um item");
            }

            // Criar a entidade Order
            var order = new Order
            {
                CustomerName = command.CustomerName,
                CustomerEmail = command.CustomerEmail,
                OrderDate = DateTime.Now,
                Status = EOrderStatus.Pending
            };

            // Criar os itens do pedido
            foreach (var item in command.Items)
            {
                var orderItem = new OrderItem
                {
                    ProductId = item.ProductId,
                    ProductName = item.ProductName,
                    UnitPrice = item.UnitPrice,
                    Quantity = item.Quantity,
                    Subtotal = item.UnitPrice * item.Quantity
                };
                order.Items.Add(orderItem);
            }

            // Calcular o total
            order.TotalAmount = order.Items.Sum(i => i.Subtotal);

            // Salvar no repositório
            await _orderRepository.AddAsync(order);

            return new CreateOrderCommandResponse(true, "Pedido criado com sucesso", order.Id, order.TotalAmount);
        }
        catch (BadRequestException)
        {
            throw;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new BadRequestException($"Erro ao criar o pedido para {command.CustomerName}");
        }
    }
}
