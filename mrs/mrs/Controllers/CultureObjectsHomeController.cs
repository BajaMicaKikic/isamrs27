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
        /// <summary>
        /// The movie view model service
        /// </summary>
        private readonly IProjectionViewModelService _movieViewModelService;
        /// <summary>
        /// The culture objects view model service
        /// </summary>
        private readonly ICultureObjectViewModelService _cultureObjectsViewModelService;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="CultureObjectsHomeController"/> class.
        /// </summary>
        /// <param name="movieViewModelService">The movie view model service.</param>
        /// <param name="cultureObjectsViewModelService">The culture objects view model service.</param>
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
        /// <summary>
        /// Movies the projections asynchronous.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> MovieProjectionsAsync()
        {
            ViewData["Title"] = "Movie Projections";
            var model = await GetMoviesViewModelAsync();
            
            return View("MovieProjections",model);
        }
        /// <summary>
        /// Cinemases the asynchronous.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> CinemasAsync()
        {
            ViewData["Title"] = "All Cinemas";
            ViewData["object"] = "CINEMAS";

            var model = await GetCinemasViewModelAsync();

            return View("CultureObjects", model);
        }
        /// <summary>
        /// Theaterses the asynchronous.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> TheatersAsync()
        {
            ViewData["Title"] = "All Theaters";
            ViewData["object"] = "THEATERS";

            var model = await GetTheatersViewModelAsync();

            return View("CultureObjects", model);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Projections(long Id)
        {
            ViewData["Title"] = "All Theaters";
            ViewData["object"] = "THEATERS";

            var model = await GetTheatersViewModelAsync();

            return View("Projections", model);
        }



        /// <summary>
        /// Gets the movies view model asynchronous.
        /// </summary>
        /// <returns></returns>
        private async Task<MoviesViewModel> GetMoviesViewModelAsync()
        {
            return await _movieViewModelService.GetAllProjectionsForUnregisteredUsers();
        }
        /// <summary>
        /// Gets the cinemas view model asynchronous.
        /// </summary>
        /// <returns></returns>
        private async Task<CinemasViewModel> GetCinemasViewModelAsync()
        {
            return await _cultureObjectsViewModelService.GetAllCinemasForUnregisteredUsers();
        }
        /// <summary>
        /// Gets the theaters view model asynchronous.
        /// </summary>
        /// <returns></returns>
        private async Task<CinemasViewModel> GetTheatersViewModelAsync()
        {
            return await _cultureObjectsViewModelService.GetAllTheatersForUnregisteredUsers();
        }
    }
}