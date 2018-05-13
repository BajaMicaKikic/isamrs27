namespace mrs.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class CultureObjectsHomeController : Controller
    {
        public IActionResult LandingPage()
        {
            ViewData["Title"] = "Visit Us";
            return View();
        }
    }
}