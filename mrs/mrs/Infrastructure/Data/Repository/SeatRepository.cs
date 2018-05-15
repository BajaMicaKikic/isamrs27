namespace mrs.Infrastructure.Data.Repository
{
    using mrs.ApplicationCore.Entities;
    using mrs.ApplicationCore.Interfaces.Repository;
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
    }
}
