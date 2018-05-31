using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using mrs.ApplicationCore.Entities;
using mrs.ApplicationCore.Interfaces.Repository;
using mrs.Infrastructure.Data;
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
        private readonly ISeatRepository _seatRepository;
        /// <summary>
        /// The culture objects view model service
        /// </summary>
        private readonly ICultureObjectViewModelService _cultureObjectsViewModelService;

        private readonly IHallSegmentRepository _hallSegmentRepository;
        /// <summary>
        /// Initializes a new instance of the <see cref="CultureObjectsHomeController"/> class.
        /// </summary>
        /// <param name="movieViewModelService">The movie view model service.</param>
        /// <param name="cultureObjectsViewModelService">The culture objects view model service.</param>
        public ReservationController(IProjectionViewModelService movieViewModelService,
                                             ICultureObjectHallRepository cultureObjectHallRepository,
                                             ICultureObjectViewModelService cultureObjectViewModelService,
                                             IScreeningRepository screeningRepository,
                                             IProjectionRepository projectionRepository,
                                             IHallSegmentRepository hallSegmentRepository,
                                             ISeatRepository seatRepository)
        {
            _movieViewModelService = movieViewModelService;
            _cultureObjectsViewModelService = cultureObjectViewModelService;
            _movieViewObjectHallService = cultureObjectHallRepository;
            _screeningRepository = screeningRepository;
            _seatRepository = seatRepository;
            _projectionRepository = projectionRepository;
            _hallSegmentRepository = hallSegmentRepository;
        }

        public async Task<ActionResult> Index()
        {
            var modelCOT = await _cultureObjectsViewModelService.GetAllTheatersForUnregisteredUsers();
            var modelCOC = await _cultureObjectsViewModelService.GetAllCinemasForUnregisteredUsers();

            modelCOC.Items.AddRange(modelCOT.Items);

            ViewModels.Reservation.ReservationItemViewModel vm = new ViewModels.Reservation.ReservationItemViewModel();
            IEnumerable<CinemaItemViewModel> ttt = modelCOC.Items;

            vm.MoviesList = new SelectList(ttt, "Id", "Name");

            MrsContext mrs = new MrsContext();
            var getProjections = mrs.Projections.ToList();

            vm.ProjectionList = new SelectList(getProjections, "Id", "ProjectionName");

            return View(vm);
        }

        public async Task<JsonResult> GetCultureObjectHall(long CultureObjectId) { 
           var hallList = await _movieViewObjectHallService.GetCultObjHallByCulObjIdAsync(CultureObjectId);
            var ttt= Json(new SelectList(hallList, "Id", "HallName"));

            return ttt;
        }

        public async Task<JsonResult> GetSDT(long CultureObjectHallId, long ProjectionId)
        {
            var sdtList = await _screeningRepository.GetSDTByCOHIdAndProjectionIdAsync(CultureObjectHallId, ProjectionId);
            var sss = Json(new SelectList(sdtList, "Id", "ScreenStartDateTime"));
            return sss;
        }

        public async Task<JsonResult> GetHallSegment(long CultureObjectHallId)
        {
            var hallSegmentList = await _hallSegmentRepository.GetHallSegmentByCOHIdAsync(CultureObjectHallId);
            var hs = Json(new SelectList(hallSegmentList, "Id", "HallSegmentName"));
            return hs;
        }
        public async Task<JsonResult> GetSeats(long HallSegmentId)
        {
            var seatList = await _seatRepository.GetSeatByHallSegmentIdAsync(HallSegmentId);
            var sss = Json(new SelectList(seatList, "Id", "SeatNumber"));
            //ViewBag["SeatId"]=seatList.Get
            //HttpContext.Session.SetString();

            return sss;
        }
        [HttpPost]
        public ActionResult Reservate(ReservationItemViewModel reservationItemViewModel)
        {
            if (ModelState.IsValid) { 
                MrsContext mrs = new MrsContext();
                SeatReservation sr = new SeatReservation();
                sr.UserId = int.Parse(HttpContext.Session.GetString("Id"));
                sr.IsReserved = true;
                sr.IsPaid = false;
                sr.SeatId = reservationItemViewModel.SeatId;
                sr.IsActive = true;
                sr.ScreeningId = reservationItemViewModel.ScreeningId;
                mrs.SeatReservations.Add(sr);
                mrs.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        //public ActionResult PoseceniObjekti()
        //{
        //    return View();
        //}

        public ActionResult MojeRezervacije(ReservationItemViewModel reservationItemViewModel)
        {
            int idUser = int.Parse(HttpContext.Session.GetString("Id"));
            MrsContext mrs = new MrsContext();
            List<SeatReservation> seatReservations = mrs.SeatReservations.ToList().FindAll(i=>i.IsActive && i.UserId==idUser);
            //mrs.SeatReservations.Select()
            return View(seatReservations);
        }

        [HttpPost]
        public ActionResult Delete(long SeatReservationId)
        {
            if (ModelState.IsValid)
            {
                MrsContext mrs = new MrsContext();
                SeatReservation sr = mrs.SeatReservations.Where(i => i.Id == SeatReservationId).FirstOrDefault();
                mrs.SeatReservations.Remove(sr);
                mrs.SaveChanges();
            }
            return RedirectToAction("MojeRezervacije");
        }
    }
}