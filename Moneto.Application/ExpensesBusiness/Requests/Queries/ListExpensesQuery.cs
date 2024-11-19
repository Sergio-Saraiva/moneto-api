using MediatR;
using Moneto.Shared.Expenses;
using OperationResult;

namespace Moneto.Application.ExpensesBusiness.Requests.Queries;

public class ListExpensesQuery : IRequest<Result<List<ExpenseViewModel>>>
{
}