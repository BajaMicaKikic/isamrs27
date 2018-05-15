using mrs.ViewModels.CultureObjectsHome;
using System.Threading.Tasks;

namespace mrs.Interfaces
{
    public interface ICultureObjectViewModelService
    {
        Task<CinemasViewModel> GetAllCinemasForUnregisteredUsers();
        Task<CinemasViewModel> GetAllTheatersForUnregisteredUsers();
    }
}
