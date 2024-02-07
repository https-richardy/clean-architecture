using Microsoft.Extensions.DependencyInjection;
using Project.Application.Mapping;

namespace Project.Infra.IoC;

public static class MappingExtension
{
    public static void AddMapping(this IServiceCollection services)
    {
        services.AddAutoMapper(cfg =>
        {
            cfg.AddProfile<CreateProductProfile>();
        });
    }
}