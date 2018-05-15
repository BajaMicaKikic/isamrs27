namespace mrs.Infrastructure.Data.Repository
{
    using mrs.ApplicationCore.Entities;
    using mrs.ApplicationCore.Interfaces.Repository;
    /// Class for Screening Repository pattern. 
    public class ScreeningRepository : EfRepository<Screening>, IScreeningRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScreeningRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public ScreeningRepository(MrsContext dbContext) : base(dbContext)
        {
        }
    }
}

