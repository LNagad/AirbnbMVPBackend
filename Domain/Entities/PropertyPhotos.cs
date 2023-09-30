using Domain.Common;

namespace Domain.Entities
{
    public class PropertyPhotos : AuditableBaseEntity
    {
        public required int PropertyId { get; set; }
        public required string BathroomURLs { get; set; }
        public required string BedroomURLs { get; set; }
        
        // For the overall property exterior
        public string? ExteriorURLs { get; set; } 
        public string? PoolURLs { get; set; }
        public string? LivingRoomURLs { get; set; }
        public string? KitchenURLs { get; set; }
        public string? GardenURLs { get; set; }
        public Property? Property { get; set; }
    }
}
