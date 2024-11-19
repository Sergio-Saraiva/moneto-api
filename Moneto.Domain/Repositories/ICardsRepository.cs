using Moneto.Domain.Entities;
using Moneto.Domain.Repositories.Base;

namespace Moneto.Domain.Repositories;

public interface ICardsRepository : IBaseRepository<Card>
{
    Task<List<Card>> GetByUserIdAsync(Guid userId);
    Task<Card> GetByBankAccountAsync(string cardNumber);
}