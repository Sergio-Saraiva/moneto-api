using Moneto.Domain.Entities.Base;

namespace Moneto.Domain.Entities;

public class RevenueCategory : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public IList<Revenue> Revenues { get; set; }
}