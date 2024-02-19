namespace Project.Domain.Contracts.Entities;

public interface IUser
{
    public string Id { get; }
    public string? UserName { get; }
    public string? Email { get; }
    public string? PasswordHash { get; }
}