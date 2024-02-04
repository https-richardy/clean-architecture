using FluentValidation;
using MediatR;
using Nelibur.ObjectMapper;
using Project.Domain.Contracts;
using Project.Domain.Entities;

namespace Project.Application.Commands.Handlers;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductResponse>
{
    private readonly IRepository<Product> _productRepository;
    private readonly IValidator<CreateProductCommand> _validator;

    public CreateProductCommandHandler(IRepository<Product> productRepository, IValidator<CreateProductCommand> validator)
    {
        _productRepository = productRepository;
        _validator = validator;
    }

    public async Task<CreateProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var product = TinyMapper.Map<Product>(request);
        await _productRepository.SaveAsync(product);

        return new CreateProductResponse
        {
            ProductId = product.Id,
            Success = true,
            Message = "The product was created successfully."
        };
    }
}