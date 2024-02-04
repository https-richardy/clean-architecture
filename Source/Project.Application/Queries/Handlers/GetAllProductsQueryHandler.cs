using FluentValidation;
using MediatR;
using Project.Domain.Contracts;
using Project.Domain.Entities;

namespace Project.Application.Queries;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
{
    private readonly IRepository<Product> _productRepository;
    private readonly IValidator<GetAllProductsQuery> _validator;

    public GetAllProductsQueryHandler(IRepository<Product> productRepository, IValidator<GetAllProductsQuery> validator)
    {
        _productRepository = productRepository;
        _validator = validator;

    }

    public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        IQueryable<Product> query = (IQueryable<Product>)_productRepository.GetAllAsync();

        if (request.MinimumPrice.HasValue)
            query.Where(product => product.Price >= request.MinimumPrice);

        if (request.MaximumPrice.HasValue)
            query.Where(product => product.Price <= request.MaximumPrice);

        var products = query.ToList();
        return products;
    }
}