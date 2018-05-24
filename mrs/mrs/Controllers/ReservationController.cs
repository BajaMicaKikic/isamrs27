using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using mrs.ApplicationCore.Entities;
using mrs.ApplicationCore.Interfaces.Repository;
using mrs.Infrastructure.Data.Repository;
using mrs.Interfaces;
using mrs.ViewModels.CultureObjectsHome;
using mrs.ViewModels.Reservation;

namespace mrs.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ICultureObjectHallRepository _movieViewObjectHallService;

        private readonly IProjectionViewModelService _movieViewModelService;

        private readonly IScreeningRepository _screeningRepository;
        private readonly IProjectionRepository _projectionRepository;
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
                                             ICultureObjectViewModelService cultureObjectViewModelService,
                                             IScreeningRepository screeningRepository,
                                             IProjectionRepository projectionRepository)
        {
            _movieViewModelService = movieViewModelService;
            _cultureObjectsViewModelService = cultureObjectViewModelService;
            _movieViewObjectHallService = cultureObjectHallRepository;
            _screeningRepository = screeningRepository;
            _projectionRepository = projectionRepository;
        }

        public async Task<ActionResult> Index()
        {
            var modelCOT = await _cultureObjectsViewModelService.GetAllTheatersForUnregisteredUsers();
            var modelCOC = await _cultureObjectsViewModelService.GetAllCinemasForUnregisteredUsers();

            modelCOC.Items.AddRange(modelCOT.Items);
           // modelCOC.Items.Where(c=>c.)
            ReservationItemViewModel vm = new ReservationItemViewModel();
            IEnumerable<CinemaItemViewModel> ttt = modelCOC.Items;
          
            
            vm.MoviesList = new SelectList(ttt, "Id", "Name");
            //vm.CultureObjectId
            //vm.TheaterList = new SelectList(ccc, "Id", "Name");

            return View(vm);
        }

        public async Task<JsonResult> GetCultureObjectHall(long CultureObjectId) { 
           var hallList = await _movieViewObjectHallService.GetCultObjHallByCulObjIdAsync(CultureObjectId);
            var ttt= Json(new SelectList(hallList, "Id", "HallName"));

            return ttt;
        }

        public async Task<JsonResult> GetScreening(long CultureObjectHallId)
        {
            var screeningList = await _screeningRepository.GetScreeningByCulObjHallIdAsync(CultureObjectHallId);
            var scr = Json(new SelectList(screeningList, "Id", "ScreenStartDateTime"));

            return scr;
        }

        
        //public JsonResult GetProjection(long ProjectionId) { }

        //[HttpGet]
        //public async Task<ActionResult> Reservate(SeatReservation sr)
        //{
        //    var model =  await _movieViewModelService.GetAllProjectionsForUnregisteredUsers(1);
        //    return View(model);
        //}

    }
}