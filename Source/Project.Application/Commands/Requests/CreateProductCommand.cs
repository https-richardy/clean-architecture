using MediatR;

namespace Project.Application.Commands;

public class CreateProductCommand : IRequest<CreateProductResponse>
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}