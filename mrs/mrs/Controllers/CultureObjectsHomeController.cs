namespace mrs.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using mrs.Interfaces;
    using mrs.ViewModels.CultureObjectsHome;
    using System.Threading.Tasks;

    /// <summary>
    /// Class that represents Culture Objects Logic.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class CultureObjectsHomeController : Controller
    {

        private readonly IProjectionViewModelService _movieViewModelService;
        private readonly ICultureObjectViewModelService _cultureObjectsViewModelService;

        public CultureObjectsHomeController( IProjectionViewModelService movieViewModelService,
                                             ICultureObjectViewModelService cultureObjectsViewModelService)
        {
            _movieViewModelService = movieViewModelService;
            _cultureObjectsViewModelService = cultureObjectsViewModelService;

        }
        /// <summary>
        /// Landings the page.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult LandingPage()
        {
            ViewData["Title"] = "Visit Us";
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> MovieProjectionsAsync()
        {
            ViewData["Title"] = "Movie Projections";
            var model = await GetMoviesViewModelAsync();
            
            return View("MovieProjections",model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> CinemasAsync()
        {
            ViewData["Title"] = "All Cinemas";
            ViewData["object"] = "CINEMAS";

            var model = await GetCinemasViewModelAsync();

            return View("Cinemas", model);
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> TheatersAsync()
        {
            ViewData["Title"] = "All Theaters";
            ViewData["object"] = "THEATERS";

            var model = await GetTheatersViewModelAsync();

            return View("Cinemas", model);
        }
        private async Task<MoviesViewModel> GetMoviesViewModelAsync()
        {
            return await _movieViewModelService.GetAllMoviesForUnregisteredUsers();
        }
        private async Task<CinemasViewModel> GetCinemasViewModelAsync()
        {
            return await _cultureObjectsViewModelService.GetAllCinemasForUnregisteredUsers();
        }
        private async Task<CinemasViewModel> GetTheatersViewModelAsync()
        {
            return await _cultureObjectsViewModelService.GetAllTheatersForUnregisteredUsers();
        }
    }
}