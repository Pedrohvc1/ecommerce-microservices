using AutoMapper;
using ECommerce.StockService.CrossCutting.Exceptions.Exceptions;
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

    /// <summary>
    /// Handle the CreateProduct command to add a new product to the repository and return the created product as a response DTO.
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest command, CancellationToken cancellationToken)
    {
        try
        {
            var product = _mapper.Map<Product>(command);
            await _productRepository.AddAsync(product);
            var result = _mapper.Map<CreateProductCommandResponse>(product);
            return new CreateProductCommandResponse(true, "Produto cadastrado com sucesso.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new BadRequestException($"Erro no cadastro do produto {command.Name}");
        }
    }
}