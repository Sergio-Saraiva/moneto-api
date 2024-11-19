using Moneto.Domain.Entities;
using Moneto.Domain.Repositories.Base;

namespace Moneto.Domain.Repositories;

public interface IRevenuesCategoriesRepository : IBaseRepository<RevenueCategory>
{
    Task<List<RevenueCategory>> GetByUserIdAsync(Guid userId);
}