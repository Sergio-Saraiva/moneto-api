using MediatR;
using Moneto.Application.Helpers;
using Moneto.Application.UsersBusiness.Requests.Commands;
using Moneto.Domain.Entities;
using Moneto.Domain.Repositories;
using Moneto.Shared.Users;
using OperationResult;

namespace Moneto.Application.UsersBusiness.Handlers.Commands;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<UserViewModel>>
{
    private readonly IUsersRepository _userRepository;
    private readonly IExpenseCategoriesRepository _expenseCategoriesRepository;
    private readonly IExpenseOwnersRepository _expenseOwnersRepository;

    public CreateUserCommandHandler(IUsersRepository userRepository, IExpenseCategoriesRepository expenseCategoriesRepository, IExpenseOwnersRepository expenseOwnersRepository)
    {
        _userRepository = userRepository;
        _expenseOwnersRepository = expenseOwnersRepository;
        _expenseCategoriesRepository = expenseCategoriesRepository;
    }

    public async Task<Result<UserViewModel>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email);
        if(user != null)
        {
            return Result.Error<UserViewModel>(new Exception("User already exists"));
        }

        var salt = Guid.NewGuid().ToString();
        var password = Argon2Helper.HashPassword(request.Password, salt);

        var newUser = new User
        {
            Name = request.Name,
            Email = request.Email,
            PasswordHash = password,
            PasswordSalt = salt
        };

        var createdUser =  await _userRepository.AddAsync(newUser);
        await _expenseCategoriesRepository.AddDefaultCategoriesAsync(newUser.Id);
        await _expenseOwnersRepository.AddAsync(new ExpenseOwner {
            Email = createdUser.Email,
            Name = createdUser.Name,
        }, createdUser);
        
        return Result.Success(new UserViewModel
        {
            Name = newUser.Name,
            Email = newUser.Email
        });
    }
}