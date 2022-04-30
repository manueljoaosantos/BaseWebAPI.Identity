using System.ComponentModel.DataAnnotations;

namespace Core.Entities.Identity
{
    public class Address : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; } 

        [Required]
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public Address(){
            FirstName = String.Empty;
            LastName = String.Empty;
            Street = String.Empty;
            City = String.Empty;
            ZipCode = String.Empty;
            AppUserId = String.Empty;
            AppUser = new AppUser();
        }
    }
}