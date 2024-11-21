using Moneto.Domain.Entities;
using Moneto.Domain.Repositories.Base;

namespace Moneto.Domain.Repositories;

public interface IIncomesRepository : IBaseRepository<Income>
{
    Task<List<Income>> GetByUserIdAsync(Guid userId);
}