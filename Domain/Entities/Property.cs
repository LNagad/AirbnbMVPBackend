using Domain.Common;

namespace Domain.Entities
{
    public class Property : AuditableBaseEntity
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required int Rooms { get; set; }
        public required int UserId { get; set; }
        public required int Bathrooms { get; set; }
        public required float Size { get; set; }
        public required double Price { get; set; }
        public required string Address { get; set; }
        public required string Latitude { get; set; }
        public required string Longitude { get; set; }
        public required int PropertyTypeId { get; set; }
        public PropertyType? PropertyType { get; set; } // House, apartment, land, etc.
        public PropertyFeatures? PropertyFeatures { get; set; }
        public ICollection<PropertyPhotos>? Photos { get; set; }
        public ICollection<Transaction>? Transactions { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Review>? Reviews { get; set; }
    }
}
