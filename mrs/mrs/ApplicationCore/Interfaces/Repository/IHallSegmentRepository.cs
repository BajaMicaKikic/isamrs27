namespace mrs.ApplicationCore.Interfaces.Repository
{
    using mrs.ApplicationCore.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for Hall Segment Repository pattern.
    /// </summary>
    /// <seealso cref="mrs.ApplicationCore.Interfaces.IRepository{mrs.ApplicationCore.Entities.HallSegment}" />
    /// <seealso cref="mrs.ApplicationCore.Interfaces.IAsyncRepository{mrs.ApplicationCore.Entities.HallSegment}" />
    public interface IHallSegmentRepository : IRepository<HallSegment>, IAsyncRepository<HallSegment>
    {
        Task<List<HallSegment>> GetHallSegmentByCOHIdAsync(long CultureObjectHallId);
    }
}
