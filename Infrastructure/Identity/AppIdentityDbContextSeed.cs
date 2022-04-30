using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Manuel",
                    Email = "manuel@test.com",
                    UserName = "manuel@test.com",
                    Address = new Address
                    {
                        FirstName = "Manuel",
                        LastName = "Santos",
                        Street = "Rua da Boavista, 130",
                        City = "Paços de Ferreira",
                    }
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}