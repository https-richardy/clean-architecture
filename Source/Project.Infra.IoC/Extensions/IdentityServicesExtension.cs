using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Project.Domain.Contracts.Entities;
using Project.Infra.Data;
using Project.Infra.Identity;

namespace Project.Infra.IoC.Extensions;

public static class IdentityServicesExtension
{
    public static void AddIdentityServices(this IServiceCollection services)
    {
        services.AddScoped<IUser, ApplicationUser>();

        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        services.AddScoped<UserManager<ApplicationUser>>();
    }
}