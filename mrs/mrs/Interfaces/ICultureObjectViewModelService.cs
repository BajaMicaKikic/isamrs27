namespace mrs.Interfaces
{
    using mrs.ViewModels.CultureObjectsHome;
    using System.Collections.Generic;
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
        /// <summary>
        /// Gets all screenings for unregistered users.
        /// </summary>
        /// <param name="cultureObjectId">The culture object identifier.</param>
        /// <param name="projectionId">The projection identifier.</param>
        /// <returns></returns>
        Task<List<ScreeningViewModel>> GetAllScreeningsForUnregisteredUsers(long cultureObjectId, long projectionId);
    }
}
