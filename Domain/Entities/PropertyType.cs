using Domain.Common;

namespace Domain.Entities
{
    public class PropertyType : AuditableBaseEntity
    {
        public required string Name { get; set; }

        public ICollection<Property>? Properties { get; set; }
    }
}
