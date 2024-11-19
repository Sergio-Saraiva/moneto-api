using Moneto.Domain.Entities;
using Moneto.Domain.Repositories.Base;

namespace Moneto.Domain.Repositories;
public interface IUsersRepository : IBaseRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
}