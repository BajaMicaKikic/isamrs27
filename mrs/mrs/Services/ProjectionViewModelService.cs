namespace mrs.Services
{
    using mrs.ApplicationCore.Entities;
    using mrs.ApplicationCore.Interfaces;
    using mrs.Interfaces;
    using mrs.ViewModels.CultureObjectsHome;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;
    using mrs.ApplicationCore.Interfaces.Repository;

    /// <summary>
    /// Class that contains logic for Projection view Model Service.
    /// </summary>
    /// <seealso cref="mrs.Interfaces.IProjectionViewModelService" />
    public class ProjectionViewModelService:IProjectionViewModelService
    {
        /// <summary>
        /// The projection repository
        /// </summary>
        private readonly IScreeningRepository _screeningRepository;
        private readonly ICultureObjectHallRepository _cultureObjectHallRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectionViewModelService"/> class.
        /// </summary>
        /// <param name="screeningRepository">The movie repository.</param>
        public ProjectionViewModelService(IScreeningRepository screeningRepository, ICultureObjectHallRepository cultureObjectRepository)
        {
            _screeningRepository = screeningRepository;
            _cultureObjectHallRepository = cultureObjectRepository;
        }
        /// <summary>
        /// Gets all movies for unregistered users.
        /// </summary>
        /// <returns></returns>
        public async Task<MoviesViewModel> GetAllProjectionsForUnregisteredUsers(long cultureObjectId)
        {
            var screenings = await _cultureObjectHallRepository.GetProjByCulObjIdAsync(cultureObjectId);
            var projections = new List<Projection>();
            foreach (var screening in screenings)
            {
                projections.Add(_screeningRepository.GetAllProjsByScreenId(screening.Id));
            }
            var viewModel = CreateViewModelFromProjections(projections.Distinct().ToList());
            return viewModel;
        }

        public Task<MoviesViewModel> GetAllProjectionsForUnregisteredUsers(int cultureObjectId)
        {
            throw new System.NotImplementedException();
        }

        //public Task<MoviesViewModel> GetAllProjectionsForUnregisteredUsers(int cultureObjectId)
        //{
        //    throw new System.NotImplementedException();
        //}

        /// <summary>
        /// Creates the view model from projections.
        /// </summary>
        /// <param name="projections">The projections.</param>
        /// <returns></returns>
        private MoviesViewModel CreateViewModelFromProjections(List<Projection> projections)
        {
            var viewModel = new MoviesViewModel
            {
                Items = projections.Where(i => i.ProjectionType == ProjectionType.Movie).Select(i =>
                {
                    var itemModel = new MovieItemViewModel
                    {
                        Id = i.Id,
                        MovieName = i.ProjectionName,
                        MovieShortDescription = i.ShortDescirption
                    };
                    return itemModel;
                }
            ).ToList()
            };

            return viewModel;
        }
    }
}
