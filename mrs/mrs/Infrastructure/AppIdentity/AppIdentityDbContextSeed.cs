namespace mrs.Infrastructure.AppIdentity
{
    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;
    using System.Linq;

    /// <summary>
    /// DB context seed for account management data.
    /// </summary>
    public class AppIdentityDbContextSeed
    {
        /// <summary>
        /// Seeds the asynchronous.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <param name="roleManager">The role manager.</param>
        /// <returns></returns>
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<AppRole> roleManager)
        {
            
            var defaultRole1 = new AppRole { Name = "System Administrator" };
            var defaultRole2 = new AppRole { Name = "Culture Object Administrator" };
            var defaultRole3 = new AppRole { Name = "Fun Zone Administrator" };
            var defaultRole4 = new AppRole { Name = "Registered User" };
            var defaultRole5 = new AppRole { Name = "Unregistered User" };

            var defaultUser1 = new ApplicationUser { UserName = "demouser1@microsoft.com", Email = "demouser1@microsoft.com", EmailConfirmed = true, PhoneNumberConfirmed = true  };
            var defaultUser2 = new ApplicationUser { UserName = "demouser2@microsoft.com", Email = "demouser2@microsoft.com", EmailConfirmed = true, PhoneNumberConfirmed = true };
            var defaultUser3 = new ApplicationUser { UserName = "demouser3@microsoft.com", Email = "demouser3@microsoft.com", EmailConfirmed = true, PhoneNumberConfirmed = true };
            var defaultUser4 = new ApplicationUser { UserName = "demouser4@microsoft.com", Email = "demouser4@microsoft.com", EmailConfirmed = true, PhoneNumberConfirmed = true };

            await roleManager.CreateAsync(defaultRole1);
            await roleManager.CreateAsync(defaultRole2);
            await roleManager.CreateAsync(defaultRole3);
            await roleManager.CreateAsync(defaultRole4);
            await roleManager.CreateAsync(defaultRole5);

            await userManager.CreateAsync(defaultUser1, "Password1");
            await userManager.AddToRoleAsync(defaultUser1, defaultRole1.ToString());
            await userManager.CreateAsync(defaultUser2, "Password2");
            await userManager.AddToRoleAsync(defaultUser2, defaultRole2.ToString());
            await userManager.CreateAsync(defaultUser3, "Password3");
            await userManager.AddToRoleAsync(defaultUser3, defaultRole3.ToString());
            await userManager.CreateAsync(defaultUser4, "Password4");
            await userManager.AddToRoleAsync(defaultUser4, defaultRole4.ToString());

        }
    }
}
