using Project.Application.Commands;
using Project.Application.Queries;

namespace Project.Application.Contracts.Services;

public interface IAccountService
{
    Task<CreateAccountResponse> CreateUserAsync(CreateAccountCommand request);
    Task<AuthenticationQueryResponse> AuthenticateAsync(AuthenticationQuery request);
}