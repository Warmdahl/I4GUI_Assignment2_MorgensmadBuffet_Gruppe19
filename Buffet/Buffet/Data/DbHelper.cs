using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Buffet.Data
{
    public class DbHelper
    {

        public static void SeedData(ApplicationDbContext db, UserManager<IdentityUser> userManager, ILogger log)
        {
            SeedKitchen(userManager, log);
        }

        public static void SeedData1(ApplicationDbContext db, UserManager<IdentityUser> userManager, ILogger log)
        {
            SeedReception(userManager, log);
        }

        public static void SeedData2(ApplicationDbContext db, UserManager<IdentityUser> userManager, ILogger log)
        {
            SeedWaiter(userManager, log);
        }

        public static void SeedKitchen(UserManager<IdentityUser> userManager, ILogger log)
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
                    userManager.AddClaimAsync(user, adminClaim);
                }
            }
        }

        public static void SeedReception(UserManager<IdentityUser> userManager, ILogger log)
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
                    userManager.AddClaimAsync(user, adminClaim);
                }
            }
        }

        public static void SeedWaiter(UserManager<IdentityUser> userManager, ILogger log)
        {
            const string adminEmail = "Waiterstaff@Staff";
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
                    userManager.AddClaimAsync(user, adminClaim);
                }
            }
        }
    }
}