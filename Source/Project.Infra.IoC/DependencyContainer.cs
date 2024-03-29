using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Infra.IoC.Extensions;

namespace Project.Infra.IoC;

public static class DependencyContainer
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDataPersistence(configuration);
        services.AddMapping();
        services.AddMediator();

        services.AddValidation();

        /* Security 'n Identity */
        services.AddIdentityServices();
        services.AddSecurity(configuration);
    }
}