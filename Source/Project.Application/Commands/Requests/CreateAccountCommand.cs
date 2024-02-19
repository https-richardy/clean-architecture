using MediatR;

namespace Project.Application.Commands;

public record CreateAccountCommand : IRequest<CreateAccountResponse>
{
    public string UserName { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}