using Moneto.Domain.Entities;
using Moneto.Domain.Repositories.Base;

namespace Moneto.Domain.Repositories;

public interface IIncomesCategoriesRepository : IBaseRepository<IncomeCategory>
{
    Task<List<IncomeCategory>> GetByUserIdAsync(Guid userId);
}