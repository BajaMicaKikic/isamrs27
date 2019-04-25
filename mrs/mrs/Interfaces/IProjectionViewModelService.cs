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
        /// Gets all projections for unregistered users.
        /// </summary>
        /// <param name="cultureObjectId">The culture object identifier.</param>
        /// <returns></returns>
        Task<MoviesViewModel> GetAllProjectionsForUnregisteredUsers(long cultureObjectId);
    }
}
