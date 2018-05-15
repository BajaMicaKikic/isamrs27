namespace mrs.Infrastructure.Data.Repository
{
    using mrs.ApplicationCore.Entities;
    using mrs.ApplicationCore.Interfaces.Repository;
    /// <summary>
    /// Class for Hall Segment Repository pattern. 
    /// </summary>
    /// <seealso cref="mrs.Infrastructure.Data.EfRepository{mrs.ApplicationCore.Entities.HallSegment}" />
    /// <seealso cref="mrs.ApplicationCore.Interfaces.Repository.IHallSegmentRepository" />
    public class HallSegmentRepository : EfRepository<HallSegment>, IHallSegmentRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HallSegmentRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public HallSegmentRepository(MrsContext dbContext) : base(dbContext)
        {

        }
    }
}

