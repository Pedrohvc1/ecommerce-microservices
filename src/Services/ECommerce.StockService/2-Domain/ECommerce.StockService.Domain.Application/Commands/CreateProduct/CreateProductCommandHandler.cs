using AutoMapper;
using ECommerce.StockService.Domain.Core.Entities;
using ECommerce.StockService.Domain.Core.Interfaces.Repositories;
using MediatR;

namespace ECommerce.StockService.Domain.Application.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest command,
        CancellationToken cancellationToken)
    {
        try
        {
            var product = _mapper.Map<Product>(command);
            await _productRepository.AddAsync(product);
            return _mapper.Map<CreateProductCommandResponse>(product);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception($"Erro no cadastro do produto {command.Name}");
        }
    }
}