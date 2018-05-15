namespace mrs.ApplicationCore.Interfaces.Repository
{
    using mrs.ApplicationCore.Entities;
    /// <summary>
    /// Interface for Hall Segment Repository pattern.
    /// </summary>
    /// <seealso cref="mrs.ApplicationCore.Interfaces.IRepository{mrs.ApplicationCore.Entities.HallSegment}" />
    /// <seealso cref="mrs.ApplicationCore.Interfaces.IAsyncRepository{mrs.ApplicationCore.Entities.HallSegment}" />
    public interface IHallSegmentRepository : IRepository<HallSegment>, IAsyncRepository<HallSegment>
    {
        // Add method signatures.
    }
}
