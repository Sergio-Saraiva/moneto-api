using AutoMapper;
using MediatR;
using Moneto.Application.ExpenseCategoriesBusiness.Requests.Commands;
using Moneto.Domain.Entities;
using Moneto.Domain.Repositories;
using Moneto.Domain.Services;
using Moneto.Shared.ExpenseCategories;
using OperationResult;

namespace Moneto.Application.ExpenseCategoriesBusiness.Handlers.Commands;


public class CreateExpenseCategoryCommandHandler : IRequestHandler<CreateExpenseCategoryCommand, Result<ExpenseCategoryViewModel>>
{
    private readonly IExpenseCategoriesRepository _expenseCategoriesRepository;
    private readonly IUsersRepository _usersRepository;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public CreateExpenseCategoryCommandHandler(IExpenseCategoriesRepository expenseCategoriesRepository, IMapper mapper, IUserService userService, IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
        _expenseCategoriesRepository = expenseCategoriesRepository;
        _mapper = mapper;
        _userService = userService;
    }

    public async Task<Result<ExpenseCategoryViewModel>> Handle(CreateExpenseCategoryCommand request, CancellationToken cancellationToken)
    {
        var userId  = _userService.GetUserId();
        if(string.IsNullOrEmpty(userId))
            return Result.Error<ExpenseCategoryViewModel>(new Exception("User not found"));

        var user = await _usersRepository.GetByIdAsync(new Guid(userId));
        if(user == null)
            return Result.Error<ExpenseCategoryViewModel>(new Exception("User not found"));

        var expenseCategory = _mapper.Map<ExpenseCategory>(request);
        var createdExpenseCategory = await _expenseCategoriesRepository.AddAsync(expenseCategory, user);
        return Result.Success(_mapper.Map<ExpenseCategoryViewModel>(createdExpenseCategory));
    }
}
