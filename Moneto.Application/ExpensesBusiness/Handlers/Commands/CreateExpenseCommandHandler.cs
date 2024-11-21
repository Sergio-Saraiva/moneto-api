using AutoMapper;
using MediatR;
using Moneto.Application.ExpensesBusiness.Requests.Commands;
using Moneto.Domain.Entities;
using Moneto.Domain.Repositories;
using Moneto.Domain.Services;
using Moneto.Shared.Expenses;
using OperationResult;

namespace Moneto.Application.ExpensesBusiness.Handlers.Commands;

public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, Result<ExpenseViewModel>>
{
    private readonly IMapper _mapper;
    private readonly IExpensesRepository _expensesRepository;
    private readonly IUserService _userService;
    private readonly IUsersRepository _usersRepository;

    public CreateExpenseCommandHandler(IMapper mapper, IExpensesRepository expensesRepository, IUserService userService, IUsersRepository usersRepository)
    {
        _mapper = mapper;
        _expensesRepository = expensesRepository;
        _userService = userService;
        _usersRepository = usersRepository;
    }

    public async Task<Result<ExpenseViewModel>> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
    {
        var userId = _userService.GetUserId();
        if(string.IsNullOrEmpty(userId)){
            return Result.Error<ExpenseViewModel>(new Exception("User not found"));
        }

        var user = await _usersRepository.GetByIdAsync(new Guid(userId));
        if(user == null){
            return Result.Error<ExpenseViewModel>(new Exception("User not found"));
        }

        if(Guid.Empty == request.ExpenseOwnerId) {
            request.ExpenseOwnerId = new Guid(userId);
        }

        var expense = _mapper.Map<Expense>(request);
        var result = await _expensesRepository.AddAsync(expense, user);
        return Result.Success(_mapper.Map<ExpenseViewModel>(result));
    }
}