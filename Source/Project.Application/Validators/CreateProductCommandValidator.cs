using FluentValidation;
using Project.Application.Commands;

namespace Project.Application.Validation;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>, IValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("The product name cannot be empty.")
            .MaximumLength(100).WithMessage("The product name must not exceed 100 characters.");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("The product price must be greater than 0.");
    }
}