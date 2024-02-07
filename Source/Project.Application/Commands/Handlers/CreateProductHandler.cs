using AutoMapper;
using FluentValidation;
using MediatR;
using Project.Domain.Contracts;
using Project.Domain.Entities;

namespace Project.Application.Commands.Handlers;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResponse>
{
    private readonly IRepository<Product> _productRepository;
    private readonly IValidator<CreateProductCommand> _validator;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(IRepository<Product> productRepository, IValidator<CreateProductCommand> validator, IMapper mapper)
    {
        _productRepository = productRepository;
        _validator = validator;
        _mapper = mapper;
    }

    # pragma warning disable CS8604
    public async Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var product = _mapper.Map<Product>(request);
        await _productRepository.SaveAsync(product);

        return new CreateProductResponse
        {
            ProductId = product.Id,
            Success = true,
            Message = "The product was created successfully."
        };
    }
}