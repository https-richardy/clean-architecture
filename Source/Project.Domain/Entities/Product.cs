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

    public void SetDiscount(decimal discountPercentage)
    {
        decimal discountAmount = (discountPercentage * Price) / 100;
        Price -= discountAmount;
    }

    public void IncreasePrice(decimal amount)
    {
        Price += amount;
    }

    public void DecreasePrice(decimal amount)
    {
        Price -= amount;
    }
}