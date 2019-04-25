namespace mrs.Infrastructure.Data.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using mrs.ApplicationCore.Entities;
    using mrs.ApplicationCore.Interfaces.Repository;
    using System.Linq;
    using System;
    using mrs.ViewModels;
    using mrs.ViewModels.Reservation;

    /// <summary>
    /// Class for Seat Repository pattern. 
    /// </summary>
    /// <seealso cref="mrs.Infrastructure.Data.EfRepository{mrs.ApplicationCore.Entities.Seat}" />
    /// <seealso cref="mrs.ApplicationCore.Interfaces.Repository.ISeatRepository" />
    public class SeatRepository : EfRepository<Seat>, ISeatRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SeatRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public SeatRepository(MrsContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Seat>> GetSeatByHallSegmentIdAsync(long HallSegmentId)
        {
            MrsContext mrs = new MrsContext();
            List<Seat> seats = await ListAllAsync();           
            List<SeatReservation> seatReservations = mrs.SeatReservations.ToList();
            /* Upit za slobodna mesta
             SELECT seats.SeatId,seats.SeatNumber FROM seats LEFT JOIN seatreservation on seats.SeatId=seatreservation.SeatId 
             where (seatreservation.IsActive=0 AND seatreservation.IsReserved=0)  or seatreservation.SeatId is null 
             */
            // var xx = seatReservations.FindAll(s => s.IsActive == false && s.IsReserved == false);
            var query = (from aa in seats
                         join bb in seatReservations.Where(s => s.IsReserved == true && s.IsActive == true)
                         on aa.Id equals bb.SeatId into cc
                         from x in cc.DefaultIfEmpty()
                         where x == null
                         select new Seat
                         {
                             Id=(int)aa.Id,
                             SeatNumber = aa.SeatNumber,
                             HallSegmentId=(int) aa.HallSegmentId
                         }).ToList();

            var seatList = query.Where(s => s.HallSegmentId == HallSegmentId);

            return seatList.ToList();
        }
    }
}
