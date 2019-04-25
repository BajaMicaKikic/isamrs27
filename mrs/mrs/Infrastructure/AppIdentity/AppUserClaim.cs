namespace mrs.Infrastructure.AppIdentity
{
    using Microsoft.AspNetCore.Identity;
    /// <summary>
    /// CLR Class for User Claim
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Identity.IdentityUserClaim{System.String}" />
    public class AppUserClaim:IdentityUserClaim<string>
    {
    }
}
