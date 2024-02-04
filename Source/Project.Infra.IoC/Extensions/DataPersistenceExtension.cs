using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Project.Domain.Contracts;
using Project.Domain.Entities;
using Project.Infra.Data;
using Project.Infra.Data.Repositories;

namespace Project.Infra.IoC.Extensions;

public static class DataPersistenceExtension
{
    public static void AddDataPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default");

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlite(connectionString);
        });

        services.AddScoped<IRepository<Product>, ProductRepository>();
    }
}