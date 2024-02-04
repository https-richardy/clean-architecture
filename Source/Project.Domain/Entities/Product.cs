namespace Project.Domain.Entities;

public sealed class Product : Entity
{
    public string Title { get; private set; } = string.Empty;
    public decimal Price { get; private set; }

    private Product(string title, decimal price)
    {
        Title = title;
        Price = price;
    }
}