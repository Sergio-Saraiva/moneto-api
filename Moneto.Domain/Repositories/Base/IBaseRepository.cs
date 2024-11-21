using Moneto.Domain.Entities;
using Moneto.Domain.Entities.Base;

namespace Moneto.Domain.Repositories.Base;
public interface IBaseRepository<T> where T : class, IBaseEntity
{
    Task<T?> GetByIdAsync(Guid id);
    Task<List<T>> ListByCreatedByIdAsync(Guid id);
    Task<List<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task<T> AddAsync(T entity, User createdBy);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
