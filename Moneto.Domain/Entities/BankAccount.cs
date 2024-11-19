using Moneto.Domain.Entities.Base;

namespace Moneto.Domain.Entities
{
    public class BankAccount : BaseEntity
    {
        public Guid OwnerUserId { get; set; }
        public User OwnerUser { get; set; }
        public string Name { get; set; }
        public string Bank { get; set; }
        public List<Card> Cards { get; set; }
    }
}