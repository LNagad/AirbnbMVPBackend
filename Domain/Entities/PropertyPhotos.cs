using Domain.Common;

namespace Domain.Entities
{
    public class PropertyPhotos : AuditableBaseEntity
    {
        public required int PropertyId { get; set; }
        public required ICollection<string> BathroomURLs { get; set; }
        public required ICollection<string> BedroomURLs { get; set; }
        
        // For the overall property exterior
        public ICollection<string>? ExteriorURLs { get; set; } 
        public ICollection<string>? PoolURLs { get; set; }
        public ICollection<string>? LivingRoomURLs { get; set; }
        public ICollection<string>? KitchenURLs { get; set; }
        public ICollection<string>? GardenURLs { get; set; }
    }
}
