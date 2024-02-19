using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Project.Application.Commands;
using Project.Application.Queries;
using Project.Application.Validation;

namespace Project.Infra.IoC.Extensions;

public static class ValidationExtension
{
    public static void AddValidation(this IServiceCollection services)
    {
        # region Product validators

        services.AddScoped<IValidator<CreateProductCommand>, CreateProductCommandValidator>();
        services.AddScoped<IValidator<GetAllProductsQuery>, GetAllProductsQueryValidator>();

        # endregion

        # region Account validators

        services.AddScoped<IValidator<CreateAccountCommand>, CreateAccountCommandValidator>();
        services.AddScoped<IValidator<AuthenticationQuery>, AuthenticationQueryValidator>();

        # endregion
    }
}