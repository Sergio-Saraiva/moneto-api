using Moneto.Domain.Entities.Base;

namespace Moneto.Domain.Entities;

public class ExpenseOwner : BaseEntity {
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public List<Expense> Expenses { get; set; }
}