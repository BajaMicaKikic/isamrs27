namespace mrs.Infrastructure.Data.Repository
{
    using mrs.ApplicationCore.Entities;
    using mrs.ApplicationCore.Interfaces.Repository;
    /// <summary>
    /// Class for Seat Reservation Repository pattern. 
    /// </summary>
    /// <seealso cref="mrs.Infrastructure.Data.EfRepository{mrs.ApplicationCore.Entities.SeatReservation}" />
    /// <seealso cref="mrs.ApplicationCore.Interfaces.Repository.ISeatReservationRepository" />
    public class SeatReservationRepository : EfRepository<SeatReservation>, ISeatReservationRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SeatReservationRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public SeatReservationRepository(MrsContext dbContext) : base(dbContext)
        {
        }
    }
}
