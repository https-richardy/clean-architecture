using MediatR;
using Project.Domain.Entities;

namespace Project.Application.Queries;

public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
{
    public decimal? MinimumPrice { get; set; }
    public decimal? MaximumPrice { get; set; }
}