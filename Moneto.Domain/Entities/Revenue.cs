using Moneto.Domain.Entities.Base;

namespace Moneto.Domain.Entities;

public class Revenue : BaseEntity
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public long Value { get; set; }
    public DateTime Date { get; set; }
    public Guid RevenueCategoryId { get; set; }
    public RevenueCategory Category { get; set; }
}