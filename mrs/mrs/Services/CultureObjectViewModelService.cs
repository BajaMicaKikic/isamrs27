namespace mrs.Services
{
    using mrs.ApplicationCore.Entities;
    using mrs.ApplicationCore.Interfaces;
    using mrs.ApplicationCore.Interfaces.Repository;
    using mrs.ApplicationCore.Specification;
    using mrs.Interfaces;
    using mrs.ViewModels.CultureObjectsHome;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    /// <summary>
    /// Class that contains logic for Culture Object View Service.
    /// </summary>
    /// <seealso cref="mrs.Interfaces.ICultureObjectViewModelService" />
    public class CultureObjectViewModelService : ICultureObjectViewModelService
    {
        /// <summary>
        /// The culture object repository
        /// </summary>
        private readonly ICultureObjectRepository _cultureObjectRepository;
        /// <summary>
        /// The screening repository
        /// </summary>
        private readonly IScreeningRepository _screeningRepository;
        /// <summary>
        /// The projection repository
        /// </summary>
        private readonly IAsyncRepository<Projection> _projectionRepository;
        /// <summary>
        /// The culture object hall repository
        /// </summary>
        private readonly IAsyncRepository<CultureObjectHall> _cultureObjectHallRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CultureObjectViewModelService"/> class.
        /// </summary>
        /// <param name="cultureObjectRepository">The culture object repository.</param>
        public CultureObjectViewModelService(ICultureObjectRepository cultureObjectRepository,
                                             IScreeningRepository screeningRepository,
                                             IAsyncRepository<Projection> projectionRepository,
                                             IAsyncRepository<CultureObjectHall> cultureObjectHallRepository)
        {
            _cultureObjectRepository = cultureObjectRepository;
            _screeningRepository = screeningRepository;
            _projectionRepository = projectionRepository;
            _cultureObjectHallRepository = cultureObjectHallRepository;
        }
        /// <summary>
        /// Gets all cinemas for unregistered users.
        /// </summary>
        /// <returns></returns>
        public async Task<CinemasViewModel> GetAllCinemasForUnregisteredUsers()
        {
            var objects = (await _cultureObjectRepository.ListAllAsync());
            var cultureObjects = objects.Where( i => i.ObjectDiscriminator == Object.Cinema).ToList();
            return CreateViewModelFromCultureObjects(cultureObjects);
        }
        /// <summary>
        /// Gets all theaters for unregistered users.
        /// </summary>
        /// <returns></returns>
        public async Task<CinemasViewModel> GetAllTheatersForUnregisteredUsers()
        {
            var cultureObjects = (await _cultureObjectRepository.ListAllAsync()).Where(i => i.ObjectDiscriminator == Object.Theater).ToList();
            return CreateViewModelFromCultureObjects(cultureObjects);
        }
        /// <summary>
        /// Gets all screenings for unregistered users.
        /// </summary>
        /// <param name="cultureObjectId">The culture object identifier.</param>
        /// <param name="projectionId">The projection identifier.</param>
        /// <returns></returns>
        public async Task<List<ScreeningViewModel>> GetAllScreeningsForUnregisteredUsers(long cultureObjectId, long projectionId)
        {
            var screenings = new List<Screening>();
            var screeningsViewModelList = new List<ScreeningViewModel>(); 
            var cultureObjectHalls = (_cultureObjectRepository.GetSingleBySpec(new CultureObjectSpecification(cultureObjectId))).CultureObjectHalls.ToList();
            var projectionTitle = (await _projectionRepository.GetByIdAsync(projectionId)).ProjectionName;            

            foreach (var hall in cultureObjectHalls)
            {
                screenings.AddRange((await _screeningRepository.ListAllAsync()).Where(s => s.CultureObjectHallId == hall.Id && s.ProjectionId == projectionId).ToList());
            }
            foreach (var screening in screenings)
            {
                var cultureObjectHall = (await _cultureObjectHallRepository.GetByIdAsync(screening.CultureObjectHallId));
                var reservedSeatsNo = _screeningRepository.GetSingleBySpec(new ScreeningSpecification(screening.Id)).SeatReservations.Count;
                screeningsViewModelList.Add(CreateScreeningViewModelFromScreening(screening, cultureObjectHall.HallName, projectionTitle, cultureObjectHall.SeatsNo - reservedSeatsNo));
            }
            return screeningsViewModelList;
        }
        /// <summary>
        /// Creates the view model from culture objects.
        /// </summary>
        /// <param name="cultureObjects">The culture objects.</param>
        /// <returns></returns>
        private CinemasViewModel CreateViewModelFromCultureObjects(List<CultureObject> cultureObjects)
        {
            var viewModel = new CinemasViewModel
            {
                Items = cultureObjects.Select(i =>
                {
                var cultureObjectSpec = new CultureObjectSpecification(i.Id);
                ICollection<Remark> remarks = (_cultureObjectRepository.GetSingleBySpec(cultureObjectSpec)).Remarks;
                    var itemModel = new CinemaItemViewModel
                    {
                        Id = i.Id,
                        Name = i.Name,
                        Address = i.Address,
                        PromoDescription = i.PromoDescription,
                        Remark = remarks.Count > 0 ? remarks.Average(r => (decimal)r.Grade) : 0
                    };
                    return itemModel;
                }).ToList()
            };

            return viewModel;
        }
        /// <summary>
        /// Creates the screening view model from screening.
        /// </summary>
        /// <param name="screening">The screening.</param>
        /// <param name="hallName">Name of the hall.</param>
        /// <param name="projectionTitle">The projection title.</param>
        /// <param name="noFreeSpaces">The no free spaces.</param>
        /// <returns></returns>
        private ScreeningViewModel CreateScreeningViewModelFromScreening(Screening screening, string hallName, string projectionTitle, int noFreeSpaces)
        {
            var viewModel = new ScreeningViewModel
            {
                ScreeningDateTime = screening.ScreenStartDateTime,
                ScreeningProjectionHall = hallName,
                ScreeningProjectionTitle = projectionTitle,
                FreeSpacesNumber = noFreeSpaces       
            };     
            return viewModel;
        }
    }
}
