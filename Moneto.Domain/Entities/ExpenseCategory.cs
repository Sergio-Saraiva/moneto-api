using Moneto.Domain.Entities.Base;

namespace Moneto.Domain.Entities;

public class ExpenseCategory : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public IList<Expense> Expenses { get; set; }

}