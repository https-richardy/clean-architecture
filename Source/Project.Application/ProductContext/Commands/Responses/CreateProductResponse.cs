namespace Project.Application.ProductContext.Commands.Responses;

public record CreateProductResponse
{
    public int ProductId { get; init; }
    public bool Success { get; init; }
    public string Message { get; init; } = string.Empty;
}