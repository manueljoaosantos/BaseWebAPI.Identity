using Microsoft.AspNetCore.Identity;

namespace Core.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public Address Address { get; set; }
/*
        public AppUser(string displayName, Address address)
        {
            this.DisplayName = displayName;
            this.Address = address;
        }      
        
        public AppUser()
        {
            this.DisplayName = String.Empty;
            this.Address = new Address();
        }    */
    }
}