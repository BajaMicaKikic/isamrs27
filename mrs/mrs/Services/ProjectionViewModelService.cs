namespace mrs.Services
{
    using mrs.ApplicationCore.Entities;
    using mrs.ApplicationCore.Interfaces;
    using mrs.Interfaces;
    using mrs.ViewModels.CultureObjectsHome;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Linq;

    public class ProjectionViewModelService:IProjectionViewModelService
    {
        private readonly IAsyncRepository<Projection> _movieRepository;

        public ProjectionViewModelService(IAsyncRepository<Projection> movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<MoviesViewModel> GetAllMoviesForUnregisteredUsers()
        {
            var movies = await _movieRepository.ListAllAsync();
            var viewModel = await CreateViewModelFromMovies(movies);
            return viewModel;
        }

        private async Task<MoviesViewModel> CreateViewModelFromMovies(List<Projection> movies)
        {
            var viewModel = new MoviesViewModel();
            viewModel.Items = movies.Where(i => i.ProjectionType == ProjectionType.Movie).Select(i =>
            {
                var itemModel = new MovieItemViewModel
                {
                    Id = i.Id,
                    MovieName = i.ProjectionName,
                    MovieShortDescription = i.ShortDescirption
                };
                return itemModel;
            }
            ).ToList();

            return viewModel;
        }
    }
}
