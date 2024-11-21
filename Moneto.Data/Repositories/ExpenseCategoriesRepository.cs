using Moneto.Data.Context;
using Moneto.Domain.Entities;
using Moneto.Domain.Repositories;

namespace Moneto.Data.Repositories;

public class ExpenseCategoriesRepository : BaseRepository<ExpenseCategory>, IExpenseCategoriesRepository
{
    public ExpenseCategoriesRepository(MonetoDbContext context) : base(context)
    {
    }

    public async Task AddDefaultCategoriesAsync(Guid userId)
    {
        _dbSet.Add(new ExpenseCategory
        {
            Name = "No category",
            CreatedBy = userId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            Description = "Default category",
            IsDeleted = false
        });

        _dbSet.Add(new ExpenseCategory
        {
            Name = "Food",
            CreatedBy = userId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            Description = "Food expenses",
            IsDeleted = false
        });

        _dbSet.Add(new ExpenseCategory
        {
            Name = "Transport",
            CreatedBy = userId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            Description = "Transport expenses",
            IsDeleted = false
        });

        _dbSet.Add(new ExpenseCategory
        {
            Name = "Health",
            CreatedBy = userId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            Description = "Health expenses",
            IsDeleted = false
        });

        _dbSet.Add(new ExpenseCategory
        {
            Name = "Education",
            CreatedBy = userId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            Description = "Education expenses",
            IsDeleted = false
        });

        _dbSet.Add(new ExpenseCategory
        {
            Name = "Entertainment",
            CreatedBy = userId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            Description = "Entertainment expenses",
            IsDeleted = false
        });

        _dbSet.Add(new ExpenseCategory
        {
            Name = "Others",
            CreatedBy = userId,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow,
            Description = "Other expenses",
            IsDeleted = false
        });

        await SaveChanges();
    }

    public Task<ExpenseCategory> GetByBankAccountAsync(string cardNumber)
    {
        throw new NotImplementedException();
    }

    public Task<List<ExpenseCategory>> GetByUserIdAsync(Guid userId)
    {
        throw new NotImplementedException();
    }
}