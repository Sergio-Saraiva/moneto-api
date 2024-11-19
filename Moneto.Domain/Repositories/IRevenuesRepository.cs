using Moneto.Domain.Entities;
using Moneto.Domain.Repositories.Base;

namespace Moneto.Domain.Repositories;

public interface IRevenuesRepository : IBaseRepository<Revenue>
{
    Task<List<Revenue>> GetByUserIdAsync(Guid userId);
}