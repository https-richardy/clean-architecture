using FluentValidation;
using Project.Application.ProductContext.Commands;

namespace Project.Application.ProductContext.Validation;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>, IValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("The product name cannot be empty.")
            .MaximumLength(100).WithMessage("The product name must not exceed 100 characters.");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("The product price must be greater than 0.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("The product description cannot be empty.")
            .MinimumLength(60).WithMessage("The product description must be at least 60 characters.")
            .MaximumLength(1000).WithMessage("The product description must not exceed 1000 characters.");

        RuleFor(x => x.StockQuantity)
            .GreaterThanOrEqualTo(0).WithMessage("The stock quantity must be greater than or equal to 0.");

        RuleFor(x => x.CoverImageUrl)
            .NotEmpty().WithMessage("The product image URL cannot be empty.")
            .Must(ValidUrl).WithMessage("The product image URL is not valid.");
    }

    # pragma warning disable CS8600
    private bool ValidUrl(string url)
    {
        Uri uriResult;
        return Uri.TryCreate(url, UriKind.Absolute, out uriResult)
            && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    }
}