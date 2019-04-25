namespace mrs.Infrastructure.AppIdentity
{
    using Microsoft.AspNetCore.Identity;
    /// <summary>
    /// CLR class for Identity User Token
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Identity.IdentityUserToken{System.String}" />
    public class AppUserToken:IdentityUserToken<string>
    {
    }
}
