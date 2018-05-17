namespace mrs.ApplicationCore.Entities
{
    using System;
    using System.Collections.Generic;

    public class CultureObjectHall : BaseEntity
    {
        public CultureObjectHall()
        { }

        public string HallName { get; set; }
        public int SeatsNo { get; set; }
        public long CultureObjectId { get; set; }

        public CultureObject CultureObject { get; set; }
        private List<HallSegment> _hallSegment = new List<HallSegment>();
        public ICollection<HallSegment> HallSegments
        {
            get { return _hallSegment; }
            set { _hallSegment = (List<HallSegment>)value; }
        }
        private List<Screening> _screenings = new List<Screening>();
        public ICollection<Screening> Screenings
        {
            get { return _screenings; }
            set { _screenings = (List<Screening>)value; }
        }
    }
    public class HallSegment:BaseEntity
    {
        public string HallSegmentName { get; set; }
        public bool IsOpen { get; set; }
        //ToDo: Number of Seats is not at proper place, This is wrong implementation.
        public int SeatsNo { get; set; }
        public long CultureObjectHallId { get; set; }

        public CultureObjectHall CultureObjecsHall { get; set; }
        private List<Seat> _seats = new List<Seat>();
        public ICollection<Seat> Seats
        {
            get { return _seats; }
            set { _seats = (List<Seat>)value; }
        }
    }
    public class Screening : BaseEntity
    {
        public DateTime ScreenStartDateTime { get; set; }
        public long CultureObjectHallId { get; set; }
        public long ProjectionId { get; set; }

        public CultureObjectHall CultureObjecsHall { get; set; }
        public Projection Projection { get; set; }
        private List<SeatReservation> _seatReservations = new List<SeatReservation>();
        public ICollection<SeatReservation> SeatReservations
        {
            get { return _seatReservations; }
            set { _seatReservations = (List<SeatReservation>)value; }
        }
    }
    public class Seat : BaseEntity
    {
        public string SeatNumber { get; set; }
        public int Row { get; set; }
        public long HallSegmentId { get; set; }

        public HallSegment HallSegment { get; set; }
        private List<SeatReservation> _seatReservations = new List<SeatReservation>();
        public ICollection<SeatReservation> SeatReservations
        {
            get { return _seatReservations; }
            set { _seatReservations = (List<SeatReservation>)value; }
        }
    }
    public class SeatReservation : BaseEntity
    {
        public bool IsReserved { get; set; }
        public bool IsPaid { get; set; }
        public bool IsActive { get; set; }

        public long ScreeningId { get; set; }
        public long SeatId { get; set; }

        public Screening Screening { get; set; }
        public Seat Seat { get; set; }
    }
}
