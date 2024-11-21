using Moneto.Domain.Entities.Base;

namespace Moneto.Domain.Entities;

public class Income : BaseEntity
{
    public string Description { get; set; }
    public long Value { get; set; }
    public DateTime Date { get; set; }
    public Guid IncomeCategoryId { get; set; }
    public IncomeCategory Category { get; set; }
}