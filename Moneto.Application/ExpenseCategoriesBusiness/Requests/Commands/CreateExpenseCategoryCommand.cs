using MediatR;
using Moneto.Shared.ExpenseCategories;
using OperationResult;

namespace Moneto.Application.ExpenseCategoriesBusiness.Requests.Commands;

public class CreateExpenseCategoryCommand : IRequest<Result<ExpenseCategoryViewModel>>
{
    public string Name { get; set; }
    public string Description { get; set; }
}