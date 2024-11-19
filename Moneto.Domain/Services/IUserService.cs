namespace Moneto.Domain.Services;

public interface IUserService
{
    string? GetUserId();
    void SignIn(string userId);
    void SignOut();
}