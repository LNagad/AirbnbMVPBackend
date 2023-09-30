using Domain.Common;

namespace Domain.Entities
{
    public class Transaction : AuditableBaseEntity
    {
        public required double Amount { get; set; }
        public required int UserId { get; set; }
        public required int PropertyId { get; set; }
        public required int TransactionTypeId { get; set; }
        public required string Description { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
        public TransactionType? TransactionType { get; set; }
        public Property? Property { get; set; }
    }
}
