using AutoMapper;
using MediatR;
using Moneto.Application.ExpenseCategoriesBusiness.Requests.Queries;
using Moneto.Domain.Repositories;
using Moneto.Domain.Services;
using Moneto.Shared.ExpenseCategories;
using OperationResult;

namespace Moneto.Application.ExpenseCategoriesBusiness.Handlers.Queries;

public class ListExpenseCategoriesQueryHandler : IRequestHandler<ListExpenseCategoriesQuery, Result<List<ExpenseCategoryViewModel>>>
{
    private readonly IExpenseCategoriesRepository _expenseCategoriesRepository;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;
    private readonly IUsersRepository _usersRepository;

    public ListExpenseCategoriesQueryHandler(IExpenseCategoriesRepository expenseCategoriesRepository, IMapper mapper, IUserService userService, IUsersRepository usersRepository)
    {
        _expenseCategoriesRepository = expenseCategoriesRepository;
        _mapper = mapper;
        _userService = userService;
        _usersRepository = usersRepository;
    }

    public async Task<Result<List<ExpenseCategoryViewModel>>> Handle(ListExpenseCategoriesQuery request, CancellationToken cancellationToken)
    {
        var userId = _userService.GetUserId();
        if(string.IsNullOrEmpty(userId))
            return Result.Error<List<ExpenseCategoryViewModel>>(new Exception("User not found"));

        var user = await _usersRepository.GetByIdAsync(new Guid(userId));
        if(user == null)
            return Result.Error<List<ExpenseCategoryViewModel>>(new Exception("User not found"));
        
        var expenseCategories = await _expenseCategoriesRepository.ListByCreatedByIdAsync(user.Id);
        return Result.Success(_mapper.Map<List<ExpenseCategoryViewModel>>(expenseCategories));
    }
}