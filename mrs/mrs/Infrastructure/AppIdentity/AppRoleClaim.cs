namespace mrs.Infrastructure.AppIdentity
{
    using Microsoft.AspNetCore.Identity;
    /// <summary>
    /// CLR Class for Role Claim.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Identity.IdentityRoleClaim{System.String}" />
    public class AppRoleClaim:IdentityRoleClaim<string>
    {
    }
}
