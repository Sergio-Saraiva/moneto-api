using Moneto.Domain.Entities.Base;

namespace Moneto.Domain.Entities;
public class User : BaseEntity {
    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string PasswordSalt { get; set; }
    public List<BankAccount> BankAccounts { get; set; }
    public List<Card> Cards { get; set; }
}