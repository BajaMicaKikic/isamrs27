namespace mrs.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    /// <summary>
    /// Class that represents Culture Objects Logic.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class CultureObjectsHomeController : Controller
    {
        /// <summary>
        /// Landings the page.
        /// </summary>
        /// <returns></returns>
        public IActionResult LandingPage()
        {
            ViewData["Title"] = "Visit Us";
            return View();
        }
    }
}