using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Project.Application.Commands;
using Project.Application.Commands.Handlers;
using Project.Application.Queries;
using Project.Domain.Entities;

namespace Project.Infra.IoC.Extensions;

public static class MediatorExtension
{
    public static void AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        services.AddTransient<IRequestHandler<CreateProductCommand, CreateProductResponse>, CreateProductCommandHandler>();
        services.AddTransient<IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>, GetAllProductsQueryHandler>();
    }
}