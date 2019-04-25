namespace mrs.ApplicationCore.Interfaces.Repository
{
    using mrs.ApplicationCore.Entities;
    /// <summary>
    /// Interface for Seat Reservation Repository pattern.
    /// </summary>
    /// <seealso cref="mrs.ApplicationCore.Interfaces.IRepository{mrs.ApplicationCore.Entities.SeatReservation}" />
    /// <seealso cref="mrs.ApplicationCore.Interfaces.IAsyncRepository{mrs.ApplicationCore.Entities.SeatReservation}" />
    public interface ISeatReservationRepository : IRepository<SeatReservation>, IAsyncRepository<SeatReservation>
    {
        // Add method signatures.
    }
}
