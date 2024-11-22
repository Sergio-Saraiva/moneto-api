using MediatR;
using Moneto.Shared.ExpenseCategories;
using OperationResult;

namespace Moneto.Application.ExpenseCategoriesBusiness.Requests.Queries;

public class ListExpenseCategoriesQuery : IRequest<Result<List<ExpenseCategoryViewModel>>>
{
}
