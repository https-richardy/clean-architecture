namespace Project.Domain.Entities;

public sealed class Product : Entity
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public string CoverImageUrl { get; set; } = string.Empty;


    public Product()
    {
        /* Empty constructor to support automatic mapping (e.g., Entity Framework). */
    }

    public Product(string title, decimal price, string description, int stockQuantity, string coverImageUrl)
    {
        Title = title;
        Price = price;
        Description = description;
        StockQuantity = stockQuantity;
        CoverImageUrl = coverImageUrl;
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