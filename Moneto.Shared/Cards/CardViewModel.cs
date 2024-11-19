using Moneto.Shared.BankAccounts;
using Moneto.Shared.Users;

namespace Moneto.Shared.Cards;

public class CardViewModel 
{
    public string Name { get; set; }
    public UserViewModel OwnerUser { get; set; }
    public string Network { get; set; }
    public BankAccountViewModel BankAccount { get; set; }
    public bool IsVirtual { get; set; }
    public bool IsDebit { get; set; }
    public bool IsCredit { get; set; }
}