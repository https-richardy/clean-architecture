namespace Project.Application.Commands;

public class CreateProductResponse
{
    public int ProductId { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
}