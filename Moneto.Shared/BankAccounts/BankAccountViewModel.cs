using Moneto.Shared.Users;

namespace Moneto.Shared.BankAccounts;

public class BankAccountViewModel 
{
    public UserViewModel OwnerUser { get; set; }
    public string Name { get; set; }
    public string Bank { get; set; }
}