using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Domain.Entities;
using Project.Infra.Identity;

namespace Project.Infra.Data;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<Product> Products { get; set; }

    public AppDbContext(DbContextOptions options)
    : base(options) {  }
}