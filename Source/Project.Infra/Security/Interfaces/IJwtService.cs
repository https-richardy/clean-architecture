using Project.Infra.Identity;

namespace Project.Infra.Contracts.Security;

public interface IJwtService
{
    Task<string> GenerateTokenAsync(ApplicationUser user);
}