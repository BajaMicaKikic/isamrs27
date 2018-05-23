using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using mrs.ApplicationCore.Interfaces.Repository;
using mrs.Interfaces;
using mrs.ViewModels.CultureObjectsHome;
using mrs.ViewModels.Reservation;

namespace mrs.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ICultureObjectHallRepository _movieViewObjectHallService;

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
        public ReservationController(IProjectionViewModelService movieViewModelService,
                                             ICultureObjectHallRepository cultureObjectHallRepository,
                                             ICultureObjectViewModelService cultureObjectViewModelService)
        {
            _movieViewModelService = movieViewModelService;
            _cultureObjectsViewModelService = cultureObjectViewModelService;
            _movieViewObjectHallService = cultureObjectHallRepository;

        }

        public async Task<ActionResult> Index()
        {
            var modelCOT = await _cultureObjectsViewModelService.GetAllTheatersForUnregisteredUsers();
            var modelCOC = await _cultureObjectsViewModelService.GetAllCinemasForUnregisteredUsers();
            
            //  var model = await _movieViewModelService.GetAllProjectionsForUnregisteredUsers(1);

            modelCOC.Items.AddRange(modelCOT.Items);
           // modelCOC.Items.Where(c=>c.)
            ReservationItemViewModel vm = new ReservationItemViewModel();
            IEnumerable<CinemaItemViewModel> ttt = modelCOC.Items;
           // IEnumerable<CinemaItemViewModel> ccc = modelCOC.Items;
            //vm.MoviesList = ttt;
            
            vm.MoviesList = new SelectList(ttt, "Id", "Name");
            //vm.TheaterList = new SelectList(ccc, "Id", "Name");
          //  var modelCOH = await _movieViewObjectHallService.GetCultObjHallByCulObjIdAsync();
            return View(vm);
        }

        public async Task<JsonResult> GetCultureObjectHall(long CultureObjectId) {

            var hallList = await _movieViewObjectHallService.GetCultObjHallByCulObjIdAsync(CultureObjectId);
            return Json(new SelectList(hallList, "CultureObjectHallId", "CultureObjectHallName"));
        }
       
        //[HttpGet]
        //public async Task<ActionResult> Reservate(SeatReservation sr)
        //{
        //    var model =  await _movieViewModelService.GetAllProjectionsForUnregisteredUsers(1);
        //    return View(model);
        //}

    }
}