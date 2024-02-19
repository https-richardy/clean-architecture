using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

using Project.Application.Commands;
using Project.Application.Commands.Handlers;
using Project.Application.ProductContext.Commands;
using Project.Application.ProductContext.Commands.Handlers;
using Project.Application.ProductContext.Commands.Responses;
using Project.Application.ProductContext.Queries;
using Project.Application.ProductContext.Queries.Handlers;
using Project.Application.Queries;
using Project.Application.Queries.Handlers;
using Project.Domain.Entities;

namespace Project.Infra.IoC.Extensions;

public static class MediatorExtension
{
    public static void AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        # region Product Mediators

        services.AddTransient<IRequestHandler<CreateProductCommand, CreateProductResponse>, CreateProductCommandHandler>();
        services.AddTransient<IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>, GetAllProductsQueryHandler>();

        # endregion


        # region Account Mediators

        services.AddTransient<IRequestHandler<CreateAccountCommand, CreateAccountResponse>, CreateAccountCommandHandler>();
        services.AddTransient<IRequestHandler<AuthenticationQuery, AuthenticationQueryResponse>, AuthenticationQueryHandler>();

        # endregion
    }
}