using Microsoft.EntityFrameworkCore;
using Moneto.Data.Context;
using Moneto.Domain.Entities;
using Moneto.Domain.Repositories;

namespace Moneto.Data.Repositories;

public class UsersRepository : BaseRepository<User>, IUsersRepository
{
    public UsersRepository(MonetoDbContext context) : base(context)
    {
    }

    public new async Task<User> AddAsync(User entity)
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

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Email == email);
    }
}