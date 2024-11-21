using Moneto.Shared.Cards;
using Moneto.Shared.ExpenseOwners;

namespace Moneto.Shared.Expenses;

public class ExpenseViewModel {
    public Guid Id { get; set; }
    public ExpenseOwnerViewModel ExpenseOwner { get; set; }
    public string Description { get; set; }
    public bool IsFromCard { get; set; }
    public CardViewModel Card { get; set; }
    public long Value { get; set; }
}