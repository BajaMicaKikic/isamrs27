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
        public int CultureObjectId { get; set; }
        public string CultureObjectName { get; set; }
        public int CultureObjectHallId { get; set; }
        public string CultureObjectHallName { get; set; }
        public SelectList MoviesList { get; set; }
        public SelectList TheaterList { get; set; }
        public SelectList HallList { get; set; }
        public int ScreeningId { get; set; }
        public int ProjectionId{ get; set; }
        public SelectList ScreeningList { get; set; }
        public DateTime ScreeningStartDateTime { get; set; }
        public string ProjectionName { get; set; }
        public SelectList ProjectionList { get; set; }
        public int HallSegmentId { get; set; }
        public string HallSegmentName { get; set; }
        public SelectList HallSegmentList { get; set; }
        public int SeatId { get; set; }
        public string SeatNumber { get; set; }
        public SelectList SeatList { get; set; }
        public int UserId { get; set; }
    }
}
