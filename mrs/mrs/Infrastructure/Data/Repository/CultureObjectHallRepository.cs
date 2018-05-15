namespace mrs.Infrastructure.Data.Repository
{
    using mrs.ApplicationCore.Entities;
    using mrs.ApplicationCore.Interfaces.Repository;
    /// <summary>
    /// Class for CultureObjectHall Repository pattern. 
    /// </summary>
    /// <seealso cref="mrs.Infrastructure.Data.EfRepository{mrs.ApplicationCore.Entities.CultureObjectHall}" />
    /// <seealso cref="mrs.ApplicationCore.Interfaces.Repository.ICultureObjectHallRepository" />
    public class CultureObjectHallRepository : EfRepository<CultureObjectHall>, ICultureObjectHallRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CultureObjectHallRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public CultureObjectHallRepository(MrsContext dbContext) : base(dbContext)
        {

        }
    }
}

