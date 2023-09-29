using Domain.Common;

namespace Domain.Entities
{
    public class TransactionType : AuditableBaseEntity
    {
        public required string Name { get; set; }
        public ICollection<Transaction>? Transactions { get; set; }
    }
}
