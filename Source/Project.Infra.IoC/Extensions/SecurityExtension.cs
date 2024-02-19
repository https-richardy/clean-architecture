#pragma warning disable CS8604, CS8618

using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Microsoft.IdentityModel.Tokens;
using Project.Infra.Contracts.Security;
using Project.Infra.Security;
using Project.Application.Contracts.Services;
using Project.Infra.Identity.Services;

namespace Project.Infra.IoC.Extensions;

public static class JwtExtension
{
    public static void AddSecurity(this IServiceCollection services, IConfiguration configuration)
    {
        var secretKey = Encoding.ASCII.GetBytes(configuration["Jwt:SecretKey"]);

        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<IAccountService, AccountService>();

        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(secretKey),  // warning disable: CS8604
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.FromMinutes(5)
            });

        services.AddAuthorization();
    }
}