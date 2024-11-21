using Moneto.Data.Context;
using Moneto.Domain.Entities;
using Moneto.Domain.Repositories;

namespace Moneto.Data.Repositories;

public class ExpenseOwnersRepository : BaseRepository<ExpenseOwner>, IExpenseOwnersRepository
{
    public ExpenseOwnersRepository(MonetoDbContext context) : base(context)
    {
    }

    public async Task<List<ExpenseOwner>> GetByUserIdAsync(Guid userId)
    {
        throw new NotImplementedException();
    }
}