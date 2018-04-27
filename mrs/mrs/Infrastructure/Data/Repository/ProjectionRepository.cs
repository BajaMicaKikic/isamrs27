namespace mrs.Infrastructure.Data.Repository
{
    using mrs.ApplicationCore.Entities;
    using mrs.ApplicationCore.Interfaces.Repository;
    /// <summary>
    /// Class for Projection Repository pattern. 
    /// </summary>
    /// <seealso cref="mrs.Infrastructure.Data.EfRepository{mrs.ApplicationCore.Entities.Projection}" />
    /// <seealso cref="mrs.ApplicationCore.Interfaces.Repository.IProjectionRepository" />
    public class ProjectionRepository : EfRepository<Projection>, IProjectionRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectionRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public ProjectionRepository(MrsContext dbContext) : base(dbContext)
        {

        }
    }
}
