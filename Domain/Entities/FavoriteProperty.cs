using Domain.Common;

namespace Domain.Entities
{
    public class FavoriteProperty : AuditableBaseEntity
    {
        public required int UserId { get; set; }
        public required int PropertyId { get; set; }
        public Property? Property { get; set; }
    }
}
