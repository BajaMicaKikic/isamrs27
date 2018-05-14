namespace mrs.Interfaces
{
    using mrs.ViewModels.CultureObjectsHome;
    using System.Threading.Tasks;

    public interface IProjectionViewModelService
    {
        Task<MoviesViewModel> GetAllMoviesForUnregisteredUsers();
    }
}
