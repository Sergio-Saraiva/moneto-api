using Microsoft.EntityFrameworkCore;
using Moneto.Data.Context;
using Moneto.Domain.Entities.Base;
using Moneto.Domain.Repositories.Base;

namespace Moneto.Data.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseEntity
{
    private readonly MonetoDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public BaseRepository(MonetoDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<T> AddAsync(T entity)
    {
        var guid = Guid.NewGuid();
        entity.Id = guid;
        entity.CreatedAt = DateTime.UtcNow;
        entity.UpdatedAt = DateTime.UtcNow;
        entity.IsDeleted = false;
        entity.CreatedBy = guid;
        _dbSet.Add(entity);
        await SaveChanges();
        return entity;
    }

    public Task DeleteAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<List<T>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<T> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    private async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<List<T>> ListByCreatedByIdAsync(Guid id)
    {
        return await _dbSet.Where(x => x.CreatedBy == id && !x.IsDeleted).ToListAsync();
    }
}