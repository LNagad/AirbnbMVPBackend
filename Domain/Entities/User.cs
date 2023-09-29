using Domain.Common;

namespace Domain.Entities
{
    public class User : AuditableBaseEntity
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string ProfilePicture { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }

        public ICollection<Property>? Properties { get; set; }
        public ICollection<FavoriteProperty>? FavoriteProperties { get; set;}
    }
}
