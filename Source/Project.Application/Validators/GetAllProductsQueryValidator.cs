using FluentValidation;
using Project.Application.Queries;

namespace Project.Application.Validation;

public class GetAllProductsQueryValidator : AbstractValidator<GetAllProductsQuery>, IValidator<GetAllProductsQuery>
{
    public GetAllProductsQueryValidator()
    {
        RuleFor(query => query.MinimumPrice)
            .GreaterThanOrEqualTo(0).WithMessage("The minimum price must be greater than or equal to zero.");

        RuleFor(query => query.MaximumPrice)
            .GreaterThanOrEqualTo(0).WithMessage("The maximum price must be greater than or equal to zero.")
            .When(query => query.MaximumPrice.HasValue);

        RuleFor(query => query.MaximumPrice)
            .GreaterThan(query => query.MinimumPrice)
            .WithMessage("The maximum price must be greater than the minimum price.")
            .When(query => query.MinimumPrice.HasValue && query.MaximumPrice.HasValue);
    }
}