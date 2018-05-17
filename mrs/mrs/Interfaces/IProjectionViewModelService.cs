namespace mrs.Interfaces
{
    using mrs.ViewModels.CultureObjectsHome;
    using System.Threading.Tasks;
    /// <summary>
    /// Interface for Projection View Model Service methods.
    /// </summary>
    public interface IProjectionViewModelService
    {
        /// <summary>
        /// Gets all movies for unregistered users.
        /// </summary>
        /// <returns></returns>
        Task<MoviesViewModel> GetAllProjectionsForUnregisteredUsers(long cultureObjectId);
    }
}
