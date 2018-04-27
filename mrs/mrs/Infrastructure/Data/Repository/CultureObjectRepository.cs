namespace mrs.Infrastructure.Data.Repository
{
    using mrs.ApplicationCore.Entities;
    using mrs.ApplicationCore.Interfaces.Repository;
    /// <summary>
    /// Class for CultureObjrct Repository pattern. 
    /// </summary>
    /// <seealso cref="mrs.Infrastructure.Data.EfRepository{mrs.ApplicationCore.Entities.CultureObject}" />
    /// <seealso cref="mrs.ApplicationCore.Interfaces.Repository.ICultureObjectRepository" />
    public class CultureObjectRepository : EfRepository<CultureObject>,ICultureObjectRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CultureObjectRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public CultureObjectRepository(MrsContext dbContext):base(dbContext)
        {

        }
    }
}
