using MediatR;
using Project.Application.ProductContext.Commands.Responses;

namespace Project.Application.ProductContext.Commands;

public record CreateProductCommand : IRequest<CreateProductResponse>
{
    public string Name { get; init; } = string.Empty;
    public decimal Price { get; init; }
    public string Description { get; init; } = string.Empty;
    public int StockQuantity { get; init; }
    public string CoverImageUrl { get; init; } = string.Empty;
}