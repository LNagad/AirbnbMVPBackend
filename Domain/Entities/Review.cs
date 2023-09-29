using Domain.Common;

namespace Domain.Entities
{
    public class Review : AuditableBaseEntity
    {
        public required string Content { get; set; }
        public required int Rating { get; set; }
        public required int UserId { get; set; }
        public required int PropertyId { get; set; }
        public Property? Property { get; set; }
    }
}
