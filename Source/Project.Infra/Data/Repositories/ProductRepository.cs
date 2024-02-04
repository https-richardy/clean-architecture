using Project.Domain.Contracts;
using Project.Domain.Entities;

namespace Project.Infra.Data.Repositories;

public class ProductRepository : Repository<Product>, IRepository<Product>
{
    public ProductRepository(AppDbContext dbContext)
    : base(dbContext) {  }
}