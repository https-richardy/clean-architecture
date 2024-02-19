using MediatR;

namespace Project.Application.Queries;

public record AuthenticationQuery : IRequest<AuthenticationQueryResponse>
{
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}