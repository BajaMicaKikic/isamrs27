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
            var defaultRole = new AppRole { Name = "Administrator", NormalizedName = "admin" }; 
            var defaultUser = new ApplicationUser { UserName = "demouser@microsoft.com", Email = "demouser@microsoft.com" };
            await userManager.CreateAsync(defaultUser, "Pass@word1");
            await roleManager.CreateAsync(defaultRole);
            await userManager.AddToRoleAsync(defaultUser, "Admin");
        }
    }
}
