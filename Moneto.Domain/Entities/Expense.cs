using Moneto.Domain.Entities.Base;

namespace Moneto.Domain.Entities;

public class Expense : BaseEntity
{
    public Guid ExpenseOwnerId { get; set; }
    public ExpenseOwner ExpenseOwner { get; set; }
    public string Description { get; set; }
    public long Value { get; set; }
    public DateTime Date { get; set; }
    public bool IsPix { get; set; }
    public bool IsFromCard { get; set; }
    public bool IsDebit { get; set; }
    public bool IsCredit { get; set; }
    public Guid? CardId { get; set; }
    public Card? Card { get; set; }
    public Guid? BankAccountId { get; set; }
    public BankAccount? BankAccount { get; set; }
    public Guid ExpenseCategoryId { get; set; }
    public ExpenseCategory Category { get; set; }
}