using Microsoft.Extensions.DependencyInjection;
using Nelibur.ObjectMapper;
using Project.Application.Commands;
using Project.Domain.Entities;

namespace Project.Infra.IoC.Extensions;

public static class TinyMappingExtension
{
    public static void AddTinyMapping(this IServiceCollection services)
    {
        TinyMapper.Bind<CreateProductCommand, Product>();
    }
}