namespace Project.Application.Commands;

public record CreateAccountResponse
{
    public bool Success { get; init; }
    public string Message { get; init; } = string.Empty;
    public object? Errors { get; init; }
}