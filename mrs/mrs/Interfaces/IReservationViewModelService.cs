using mrs.ViewModels.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mrs.Interfaces
{
    public interface IReservationViewModelService
    {
        Task<ReservationViewModel> setReservation();
    }
}
