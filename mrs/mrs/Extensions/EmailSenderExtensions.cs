namespace mrs.Services
{
    using mrs.ApplicationCore.Interfaces;
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;
    /// <summary>
    /// Class that adds Sending Email Confirmation.
    /// </summary>
    public static class EmailSenderExtension
    {
        /// <summary>
        /// Sends the email confirmation asynchronous.
        /// </summary>
        /// <param name="emailSender">The email sender.</param>
        /// <param name="email">The email.</param>
        /// <param name="link">The link.</param>
        /// <returns></returns>
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "Confirm your email",
                $"Please confirm your account by clicking this link: <a href='{HtmlEncoder.Default.Encode(link)}'>link</a>");
        }
    }
}
