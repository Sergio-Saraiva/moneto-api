using Moneto.Domain.Entities.Base;

namespace Moneto.Domain.Entities;

public class IncomeCategory : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public IList<Income> Incomes { get; set; }
}