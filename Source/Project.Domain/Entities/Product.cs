namespace Project.Domain.Entities;

public sealed class Product : Entity
{
    public string Title { get; set; } = string.Empty;
    public decimal Price { get; set; }

    public Product() {  }

    public Product(string title, decimal price)
    {
        Title = title;
        Price = price;
    }
}