using Moneto.Domain.Entities;
using Moneto.Domain.Repositories.Base;

namespace Moneto.Domain.Repositories;

public interface IBankAccountsRepository : IBaseRepository<BankAccount>
{
    Task<List<BankAccount>> GetByUserIdAsync(Guid userId);
}