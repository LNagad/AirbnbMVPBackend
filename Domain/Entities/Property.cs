using Domain.Common;

namespace Domain.Entities
{
    public class Property : AuditableBaseEntity
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required int Rooms { get; set; }
        public required int Bathrooms { get; set; }
        public required float Size { get; set; }
        public required double Price { get; set; }
        public required string Latitude { get; set; }
        public required string Longitude { get; set; }
        public required string Address { get; set; }
        public required int PropertyId { get; set; }
        public PropertyType? Type { get; set; } // House, apartment, land, etc.
        public PropertyPhotos? Photos { get; set; }
        public PropertyFeatures? Features { get; set; }
        
    }
}
