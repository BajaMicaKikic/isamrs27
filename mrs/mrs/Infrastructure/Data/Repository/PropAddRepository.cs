namespace mrs.Infrastructure.Data.Repository
{
    using mrs.ApplicationCore.Entities;
    using mrs.ApplicationCore.Interfaces.Repository;
    /// <summary>
    /// Class for Projection Repository pattern. 
    /// </summary>
    /// <seealso cref="mrs.Infrastructure.Data.EfRepository{mrs.ApplicationCore.Entities.PropAd}" />
    /// <seealso cref="mrs.ApplicationCore.Interfaces.Repository.IPropAdRepository" />
    public class PropAddRepository:EfRepository<PropAd>,IPropAdRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropAddRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public PropAddRepository(MrsContext dbContext) : base(dbContext)
        { }
    }
}
