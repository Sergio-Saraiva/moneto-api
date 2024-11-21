using Moneto.Domain.Entities;
using Moneto.Domain.Repositories.Base;

namespace Moneto.Domain.Repositories;

public interface IExpenseCategoriesRepository : IBaseRepository<ExpenseCategory>
{
    Task<List<ExpenseCategory>> GetByUserIdAsync(Guid userId);
    Task<ExpenseCategory> GetByBankAccountAsync(string cardNumber);
    Task AddDefaultCategoriesAsync(Guid userId);
}