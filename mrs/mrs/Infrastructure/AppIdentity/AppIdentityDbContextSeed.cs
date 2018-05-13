namespace mrs.Infrastructure.AppIdentity
{
    using Microsoft.AspNetCore.Identity;
    using System.Threading.Tasks;

    /// <summary>
    /// DB context seed for account management data.
    /// </summary>
    public class AppIdentityDbContextSeed
    {
        /// <summary>
        /// Seeds the asynchronous.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <returns></returns>
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<AppRole> roleManager)
        {
            var defaultRole1 = new AppRole { Name = "System Administrator" };
            var defaultRole2 = new AppRole { Name = "Culture Object Administrator" };
            var defaultRole3 = new AppRole { Name = "Fun Zone Administrator" };
            var defaultRole4 = new AppRole { Name = "Registered User" };
            var defaultRole5 = new AppRole { Name = "Unregistered User" };

            var defaultUser = new ApplicationUser { UserName = "demouser@microsoft.com", Email = "demouser@microsoft.com" };
            await userManager.CreateAsync(defaultUser, "Pass@word1");

            await roleManager.CreateAsync(defaultRole1);
            await roleManager.CreateAsync(defaultRole2);
            await roleManager.CreateAsync(defaultRole3);
            await roleManager.CreateAsync(defaultRole4);
            await roleManager.CreateAsync(defaultRole5);

            await userManager.AddToRoleAsync(defaultUser, defaultRole1.ToString());
        }
    }
}
