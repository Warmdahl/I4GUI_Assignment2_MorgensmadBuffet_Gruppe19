using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Buffet.Data
{
    public class DbHelper
    {

        public static void SeedData(ApplicationDbContext db, UserManager<IdentityUser> userManager, ILogger log)
        {
            SeedKitchen(userManager, log);
            SeedReception(userManager, log);
            SeedResturant(userManager, log);
        }

        public async static void SeedKitchen(UserManager<IdentityUser> userManager, ILogger log)
        {
            const string adminEmail = "Kitchenstaff@Staff";
            const string adminPassword = "Staff123!";

            if (userManager.FindByNameAsync(adminEmail).Result == null)
            {
                log.LogWarning("Seeding the admin user");
                var user = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail
                };
                IdentityResult result = userManager.CreateAsync
                    (user, adminPassword).Result;
                if (result.Succeeded)
                {
                    var adminClaim = new Claim("KitchenStaff", "Yes");
                    await userManager.AddClaimAsync(user, adminClaim);
                }
            }
        }

        public async static void SeedReception(UserManager<IdentityUser> userManager, ILogger log)
        {
            const string adminEmail = "Receptionstaff@Staff";
            const string adminPassword = "Staff123!";

            if (userManager.FindByNameAsync(adminEmail).Result == null)
            {
                log.LogWarning("Seeding the admin user");
                var user = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail
                };
                IdentityResult result = userManager.CreateAsync
                    (user, adminPassword).Result;
                if (result.Succeeded)
                {
                    var adminClaim = new Claim("ReceptionStaff", "Yes");
                    await userManager.AddClaimAsync(user, adminClaim);
                }
            }
        }

        public async static void SeedResturant(UserManager<IdentityUser> userManager, ILogger log)
        {
            const string adminEmail = "Resturantstaff@Staff";
            const string adminPassword = "Staff123!";

            if (userManager.FindByNameAsync(adminEmail).Result == null)
            {
                log.LogWarning("Seeding the admin user");
                var user = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail
                };
                IdentityResult result = userManager.CreateAsync
                    (user, adminPassword).Result;
                if (result.Succeeded)
                {
                    var adminClaim = new Claim("WaiterStaff", "Yes");
                    await userManager.AddClaimAsync(user, adminClaim);
                }
            }
        }
    }
}