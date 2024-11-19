using MediatR;
using Moneto.Application.AuthBusiness.Requests.Queries;
using Moneto.Application.Helpers;
using Moneto.Domain.Repositories;
using Moneto.Domain.Services;
using OperationResult;

namespace Moneto.Application.AuthBusiness.Handlers.Queries;

public class SignInQueryHandler : IRequestHandler<SignInQuery, Result>
{
    private readonly IUsersRepository _usersRepository;
    private readonly IUserService _userService;

    public SignInQueryHandler(IUsersRepository usersRepository, IUserService userService)
    {
        _usersRepository = usersRepository;
        _userService = userService;
    }

    public async Task<Result> Handle(SignInQuery request, CancellationToken cancellationToken)
    {
        var user = await _usersRepository.GetByEmailAsync(request.Email);
        if(user == null)
        {
            return Result.Error(new Exception("User not found"));
        }

        var passwordHash = Argon2Helper.HashPassword(request.Password, user.PasswordSalt);
        if(passwordHash != user.PasswordHash)
        {
            return Result.Error(new Exception("Invalid password"));
        }

        _userService.SignIn(user.Id.ToString());

        return Result.Success();
    }
}