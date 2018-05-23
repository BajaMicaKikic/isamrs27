using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using mrs.ApplicationCore.Entities;
using mrs.ViewModels.CultureObjectsHome;

namespace mrs.ViewModels.Reservation
{
    public class ReservationItemViewModel
    {
        public string Objeat { get; set; }
        public string Sala{ get; set; }
        public SelectList MoviesList { get; set; }
        public SelectList TheaterList { get; set; }
        public SelectList HallList { get; set; }
    }
}
