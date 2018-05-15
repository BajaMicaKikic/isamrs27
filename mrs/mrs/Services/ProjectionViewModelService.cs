namespace mrs.Services
{
    using mrs.ApplicationCore.Entities;
    using mrs.ApplicationCore.Interfaces;
    using mrs.Interfaces;
    using mrs.ViewModels.CultureObjectsHome;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;
    /// <summary>
    /// Class that contains logic for Projection view Model Service.
    /// </summary>
    /// <seealso cref="mrs.Interfaces.IProjectionViewModelService" />
    public class ProjectionViewModelService:IProjectionViewModelService
    {
        /// <summary>
        /// The projection repository
        /// </summary>
        private readonly IAsyncRepository<Projection> _projectionRepository;
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectionViewModelService"/> class.
        /// </summary>
        /// <param name="movieRepository">The movie repository.</param>
        public ProjectionViewModelService(IAsyncRepository<Projection> movieRepository)
        {
            _projectionRepository = movieRepository;
        }
        /// <summary>
        /// Gets all movies for unregistered users.
        /// </summary>
        /// <returns></returns>
        public async Task<MoviesViewModel> GetAllProjectionsForUnregisteredUsers()
        {
            var movies = await _projectionRepository.ListAllAsync();
            var viewModel = CreateViewModelFromProjections(movies);
            return viewModel;
        }
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
