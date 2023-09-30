using Domain.Common;

namespace Domain.Entities
{
    public class PropertyFeatures : AuditableBaseEntity
    {
        public required int PropertyId { get; set; }
        public required bool HasGarden { get; set; }
        public required bool HasPool { get; set; }
        public required bool HasGym { get; set; }
        public required bool HasAirConditioning { get; set; }
        public required bool HasBarbecueGrill { get; set; }
        public required bool HasBalcony { get; set; }

        public Property? Property { get; set; }
    }
}
