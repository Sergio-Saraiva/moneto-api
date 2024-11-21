using MediatR;
using Moneto.Shared.Expenses;
using OperationResult;

namespace Moneto.Application.ExpensesBusiness.Requests.Commands;

public class CreateExpenseCommand : IRequest<Result<ExpenseViewModel>>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public long Value { get; set; }
    public bool IsPix { get; set; }
    public bool IsFromCard { get; set; }
    public bool IsDebit { get; set; }
    public bool IsCredit { get; set; }
    public Guid? CardId { get; set; }
    public Guid? BankAccountId { get; set; }
    public Guid ExpenseOwnerId { get; set; }
    public Guid ExpenseCategoryId { get; set; }
}