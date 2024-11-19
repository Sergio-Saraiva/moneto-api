
using AutoMapper;
using MediatR;
using Moneto.Application.ExpensesBusiness.Requests.Queries;
using Moneto.Domain.Repositories;
using Moneto.Domain.Services;
using Moneto.Shared.Expenses;
using OperationResult;

namespace Moneto.Application.ExpensesBusiness.Handlers.Queries;

public class ListExpensesQueryHanlder : IRequestHandler<ListExpensesQuery, Result<List<ExpenseViewModel>>>
{
    private readonly IExpensesRepository _expenseRepository;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public ListExpensesQueryHanlder(IExpensesRepository expenseRepository, IUserService userService, IMapper mapper)
    {
        _expenseRepository = expenseRepository;
        _userService = userService;
        _mapper = mapper;
    }

    public async Task<Result<List<ExpenseViewModel>>> Handle(ListExpensesQuery request, CancellationToken cancellationToken)
    {
        var userId = _userService.GetUserId();
        if(string.IsNullOrEmpty(userId))
        {
            return Result.Error<List<ExpenseViewModel>>(new Exception("User not found"));
        }

        var expenses = await _expenseRepository.ListByCreatedByIdAsync(new Guid(userId));
        return Result.Success(_mapper.Map<List<ExpenseViewModel>>(expenses));
    }
}