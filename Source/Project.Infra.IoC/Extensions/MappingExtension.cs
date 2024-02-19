using Microsoft.Extensions.DependencyInjection;
using Nelibur.ObjectMapper;
using Project.Application.Commands;
using Project.Application.ProductContext.Commands;
using Project.Domain.Entities;
using Project.Infra.Identity;

namespace Project.Infra.IoC;

public static class MappingExtension
{
    public static void AddMapping(this IServiceCollection services)
    {
        # region Product Mappings

        TinyMapper.Bind<CreateProductCommand, Product>(config =>
        {
            config.Bind(source => source.Name, target => target.Title);
            config.Bind(source => source.Price, target => target.Price);
        });

        # endregion

        # region Account Mappings

        TinyMapper.Bind<CreateAccountCommand, ApplicationUser>(config =>
        {
            config.Bind(source => source.UserName, target => target.UserName);
            config.Bind(source => source.Email, target => target.Email);
        });

        # endregion
    }
}