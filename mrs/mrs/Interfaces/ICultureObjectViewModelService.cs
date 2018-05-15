namespace mrs.Interfaces
{
    using mrs.ViewModels.CultureObjectsHome;
    using System.Threading.Tasks;
    /// <summary>
    /// Interface for Culture Object View Model Service methods.
    /// </summary>
    public interface ICultureObjectViewModelService
    {
        /// <summary>
        /// Gets all cinemas for unregistered users.
        /// </summary>
        /// <returns></returns>
        Task<CinemasViewModel> GetAllCinemasForUnregisteredUsers();
        /// <summary>
        /// Gets all theaters for unregistered users.
        /// </summary>
        /// <returns></returns>
        Task<CinemasViewModel> GetAllTheatersForUnregisteredUsers();
    }
}
