using Moneto.Domain.Entities.Base;

namespace Moneto.Domain.Entities;

public class Card : BaseEntity {
    public string Name { get; set; }
    public string Network { get; set; }
    public bool IsVirtual { get; set; }
    public bool IsDebit { get; set; }
    public bool IsCredit { get; set; }
    public long Limit { get; set; }
    public Guid BankAccountId { get; set; }
    public BankAccount BankAccount { get; set; }
    public List<Expense> Expenses { get; set; }
    public User OwnerUser { get; set; }
    public Guid OwnerUserId { get; set; }
}