using Moneto.Domain.Entities;
using Moneto.Domain.Repositories.Base;

namespace Moneto.Domain.Repositories;

public interface IExpensesRepository : IBaseRepository<Expense>
{
    Task<List<Expense>> GetByUserIdAsync(Guid userId);
    Task<List<Expense>> GetByCategoryIdAsync(Guid categoryId);
    Task<List<Expense>> GetByExpenseOwnerId(Guid expenseOwnerId);

}