using Moneto.Data.Context;
using Moneto.Domain.Entities;
using Moneto.Domain.Repositories;

namespace Moneto.Data.Repositories;

public class ExpensesRepository : BaseRepository<Expense>, IExpensesRepository
{
    public ExpensesRepository(MonetoDbContext context) : base(context)
    {
    }

    public Task<List<Expense>> GetByCategoryIdAsync(Guid categoryId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Expense>> GetByExpenseOwnerId(Guid expenseOwnerId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Expense>> GetByUserIdAsync(Guid userId)
    {
        throw new NotImplementedException();
    }
}