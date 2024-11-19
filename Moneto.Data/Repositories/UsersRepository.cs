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

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Email == email);
    }
}