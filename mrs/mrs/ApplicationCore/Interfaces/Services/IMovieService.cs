namespace mrs.ApplicationCore.Interfaces.Services
{
    using mrs.ViewModels.CultureObjectsHome;
    using System.Threading.Tasks;

    public interface IMovieService
    {
        Task<MoviesViewModel> GetMoviesViewModel();
    }
}
