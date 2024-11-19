using Moneto.Domain.Entities;
using Moneto.Domain.Repositories.Base;

namespace Moneto.Domain.Repositories;

public interface IExpenseOwnersRepository : IBaseRepository<ExpenseOwner>
{
    Task<List<ExpenseOwner>> GetByUserIdAsync(Guid userId);
}