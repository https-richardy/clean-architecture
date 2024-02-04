using Microsoft.EntityFrameworkCore;
using Project.Domain.Entities;

namespace Project.Infra.Data;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public AppDbContext(DbContextOptions options)
    : base(options) {  }
}